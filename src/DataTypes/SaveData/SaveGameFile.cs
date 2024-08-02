using System;
using System.Text;

namespace BinarySerializer.UbiArt
{
    public class SaveGameFile<T> : BinarySerializable
        where T : BinarySerializable, new()
    {
        public string Name { get; set; }
        public uint SaveCodeCRC { get; set; } // Constant in final release since the save structure is always the same
        public bool Read { get; set; }
        public T CONTENT { get; set; }
        public byte[] Footer { get; set; }

        public uint PS3_Uint_80 { get; set; }
        public uint PS3_SaveDataLength { get; set; }
        public uint PS3_Uint_88 { get; set; } // Seems unused?
        public uint PS3_Uint_8C { get; set; }
        public uint PS3_Uint_98 { get; set; } // Some flags?

        public override void SerializeImpl(SerializerObject s)
        {
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

            s.DoEndian(settings.Game switch
            {
                Game.RaymanOrigins when settings.Platform is Platform.PC => Endian.Little,
                Game.RaymanLegends when settings.Platform is Platform.PC => Endian.Little,
                Game.RaymanLegends when settings.Platform is Platform.PlayStation3 => Endian.Big,
                _ => throw new ArgumentOutOfRangeException()
            }, () =>
            {
                Name = s.SerializeString(Name, length: settings.Game switch
                {
                    Game.RaymanOrigins when settings.Platform is Platform.PC => 520,
                    Game.RaymanLegends when settings.Platform is Platform.PC => 520,
                    Game.RaymanLegends when settings.Platform is Platform.PlayStation3 => 128,
                    _ => throw new ArgumentOutOfRangeException()
                }, encoding: settings.Game switch
                {
                    Game.RaymanOrigins when settings.Platform is Platform.PC => Encoding.Unicode,
                    Game.RaymanLegends when settings.Platform is Platform.PC => Encoding.Unicode,
                    Game.RaymanLegends when settings.Platform is Platform.PlayStation3 => Encoding.UTF8,
                    _ => throw new ArgumentOutOfRangeException()
                }, name: nameof(Name));

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
                    PS3_SaveDataLength = s.Serialize<uint>(PS3_SaveDataLength, name: nameof(PS3_SaveDataLength));
                    PS3_Uint_88 = s.Serialize<uint>(PS3_Uint_88, name: nameof(PS3_Uint_88));
                    PS3_Uint_8C = s.Serialize<uint>(PS3_Uint_8C, name: nameof(PS3_Uint_8C));
                    processor.Serialize<uint>(s, "SaveDataCRC");
                    SaveCodeCRC = s.Serialize<uint>(SaveCodeCRC, name: nameof(SaveCodeCRC));
                    PS3_Uint_98 = s.Serialize<uint>(PS3_Uint_98, name: nameof(PS3_Uint_98));
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
                });
                Footer = s.SerializeArray<byte>(Footer, settings.Game switch
                {
                    Game.RaymanOrigins when settings.Platform is Platform.PC => 288,
                    Game.RaymanLegends when settings.Platform is Platform.PC => 400,
                    Game.RaymanLegends when settings.Platform is Platform.PlayStation3 => 0,
                    _ => throw new ArgumentOutOfRangeException()
                }, name: nameof(Footer));

                // Padded with a total length of 0x40000
                if (settings.Game == Game.RaymanLegends && settings.Platform == Platform.PlayStation3)
                    s.Goto(Offset + 0x40000);
            });
        }
    }
}