using System;
using System.Text;

namespace BinarySerializer.UbiArt
{
    public class SaveGameFile<T> : BinarySerializable
        where T : BinarySerializable, new()
    {
        public string Name { get; set; }
        public uint SaveCodeCRC { get; set; } // Constant in final release since the save structure is always the same
        public uint SaveDataLength { get; set; }
        public bool Read { get; set; }
        public T CONTENT { get; set; }
        public byte[] Footer { get; set; }

        public byte Switch_Byte_00 { get; set; }
        public byte[] Switch_Bytes_81 { get; set; } // Padding?
        public uint Switch_SaveHeaderCRC { get; set; } // TODO: Should probably process this when serializing

        public uint PS3_Uint_80 { get; set; }
        public uint PS3_Uint_88 { get; set; } // Seems unused?
        public uint PS3_Uint_8C { get; set; }
        public uint PS3_Uint_98 { get; set; } // Some flags?

        public uint Xbox360_Uint_80 { get; set; }
        public uint Xbox360_Uint_84 { get; set; }
        public uint Xbox360_Uint_90 { get; set; }
        public uint Xbox360_Uint_94 { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

            s.DoEndian(settings.Game switch
            {
                Game.RaymanOrigins when settings.Platform is Platform.PC => Endian.Little,
                Game.RaymanLegends when settings.Platform is Platform.PC => Endian.Little,
                Game.RaymanLegends when settings.Platform is Platform.PlayStation3 => Endian.Big,
                Game.RaymanLegends when settings.Platform is Platform.Xbox360 => Endian.Big,
                Game.RaymanLegends when settings.Platform is Platform.NintendoSwitch => Endian.Little,
                _ => throw new ArgumentOutOfRangeException()
            }, () =>
            {
                ChecksumCustomCRC32Processor headerProcessor = null;

                if (settings.Game == Game.RaymanLegends && settings.Platform == Platform.NintendoSwitch)
                {
                    headerProcessor = new ChecksumCustomCRC32Processor(new ChecksumCustomCRC32Processor.CRCParameters(
                        hashSize: 32,
                        poly: 0x04C11DB7,
                        init: 0xFFFFFFFF,
                        refIn: false,
                        refOut: false,
                        xorOut: 0xFFFFFFFF));
                    s.BeginProcessed(headerProcessor);

                    Switch_Byte_00 = s.Serialize<byte>(Switch_Byte_00, name: nameof(Switch_Byte_00));
                }

                Name = s.SerializeString(Name, length: settings.Game switch
                {
                    Game.RaymanOrigins when settings.Platform is Platform.PC => 520,
                    Game.RaymanLegends when settings.Platform is Platform.PC => 520,
                    Game.RaymanLegends when settings.Platform is Platform.PlayStation3 => 128,
                    Game.RaymanLegends when settings.Platform is Platform.Xbox360 => 128,
                    Game.RaymanLegends when settings.Platform is Platform.NintendoSwitch => 128,
                    _ => throw new ArgumentOutOfRangeException()
                }, encoding: settings.Game switch
                {
                    Game.RaymanOrigins when settings.Platform is Platform.PC => Encoding.Unicode,
                    Game.RaymanLegends when settings.Platform is Platform.PC => Encoding.Unicode,
                    Game.RaymanLegends when settings.Platform is Platform.PlayStation3 => Encoding.UTF8,
                    Game.RaymanLegends when settings.Platform is Platform.Xbox360 => Encoding.UTF8,
                    Game.RaymanLegends when settings.Platform is Platform.NintendoSwitch => Encoding.UTF8,
                    _ => throw new ArgumentOutOfRangeException()
                }, name: nameof(Name));

                if (settings.Game == Game.RaymanLegends && settings.Platform == Platform.NintendoSwitch)
                    Switch_Bytes_81 = s.SerializeArray<byte>(Switch_Bytes_81, 3, name: nameof(Switch_Bytes_81));

                ChecksumCustomCRC32Processor processor = new(new ChecksumCustomCRC32Processor.CRCParameters(
                    hashSize: 32,
                    poly: 0x04C11DB7,
                    init: 0xFFFFFFFF,
                    refIn: false,
                    refOut: false,
                    xorOut: 0xFFFFFFFF));

                if (settings.Game == Game.RaymanLegends && settings.Platform == Platform.PlayStation3)
                {
                    PS3_Uint_80 = s.Serialize<uint>(PS3_Uint_80, name: nameof(PS3_Uint_80));
                    SaveDataLength = s.Serialize<uint>(SaveDataLength, name: nameof(SaveDataLength));
                    PS3_Uint_88 = s.Serialize<uint>(PS3_Uint_88, name: nameof(PS3_Uint_88));
                    PS3_Uint_8C = s.Serialize<uint>(PS3_Uint_8C, name: nameof(PS3_Uint_8C));
                    processor.Serialize<uint>(s, "SaveDataCRC");
                    SaveCodeCRC = s.Serialize<uint>(SaveCodeCRC, name: nameof(SaveCodeCRC));
                    PS3_Uint_98 = s.Serialize<uint>(PS3_Uint_98, name: nameof(PS3_Uint_98));
                }
                else if (settings.Game == Game.RaymanLegends && settings.Platform == Platform.Xbox360)
                {
                    Xbox360_Uint_80 = s.Serialize<uint>(Xbox360_Uint_80, name: nameof(Xbox360_Uint_80));
                    Xbox360_Uint_84 = s.Serialize<uint>(Xbox360_Uint_84, name: nameof(Xbox360_Uint_84));
                    processor.Serialize<uint>(s, "SaveDataCRC");
                    SaveDataLength = s.Serialize<uint>(SaveDataLength, name: nameof(SaveDataLength));
                    Xbox360_Uint_90 = s.Serialize<uint>(Xbox360_Uint_90, name: nameof(Xbox360_Uint_90));
                    Xbox360_Uint_94 = s.Serialize<uint>(Xbox360_Uint_94, name: nameof(Xbox360_Uint_94));
                }
                else if (settings.Game == Game.RaymanLegends && settings.Platform == Platform.NintendoSwitch)
                {
                    processor.Serialize<uint>(s, "SaveDataCRC");
                    headerProcessor.IsActive = false;
                    headerProcessor.Serialize<uint>(s, "SaveHeaderCRC");
                }
                else
                {
                    SaveCodeCRC = s.Serialize<uint>(SaveCodeCRC, name: nameof(SaveCodeCRC));
                    processor.Serialize<uint>(s, "SaveDataCRC");
                }

                s.DoProcessed(processor, () =>
                {
                    s.DoEndian(settings.Endian, () =>
                    {
                        Read = s.SerializeUbiArtBool(Read, name: nameof(Read));
                        CONTENT = s.SerializeObject<T>(CONTENT, name: nameof(CONTENT));
                    });

                    // Need to serialize the save data crc value, so activate it before ending the DoProcessed
                    if (headerProcessor != null)
                        headerProcessor.IsActive = true;
                });

                // Now serialize the save header crc
                if (headerProcessor != null)
                    s.EndProcessed(headerProcessor);

                Footer = s.SerializeArray<byte>(Footer, settings.Game switch
                {
                    Game.RaymanOrigins when settings.Platform is Platform.PC => 288,
                    Game.RaymanLegends when settings.Platform is Platform.PC => 400,
                    Game.RaymanLegends when settings.Platform is Platform.PlayStation3 => 0,
                    Game.RaymanLegends when settings.Platform is Platform.Xbox360 => 0,
                    Game.RaymanLegends when settings.Platform is Platform.NintendoSwitch => 0,
                    _ => throw new ArgumentOutOfRangeException()
                }, name: nameof(Footer));

                // Padded with a total length of 0x40000
                if (settings.Game == Game.RaymanLegends && settings.Platform is Platform.PlayStation3 or Platform.Xbox360)
                    s.SerializePadding(Offset + 0x40000 - s.CurrentPointer);
            });
        }
    }
}