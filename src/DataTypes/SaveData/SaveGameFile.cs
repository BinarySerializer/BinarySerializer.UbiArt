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

        public override void SerializeImpl(SerializerObject s)
        {
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

            s.DoEndian(Endian.Little, () =>
            {
                Name = s.SerializeString(Name, length: 520, encoding: Encoding.Unicode, name: nameof(Name));
                SaveCodeCRC = s.Serialize<uint>(SaveCodeCRC, name: nameof(SaveCodeCRC));

                ChecksumCustomCRC32Processor processor = new(new ChecksumCustomCRC32Processor.CRCParameters(
                    hashSize: 32,
                    poly: 0x04C11DB7,
                    init: 0xFFFFFFFF,
                    refIn: false,
                    refOut: false,
                    xorOut: 0xFFFFFFFF));
                processor.Serialize<uint>(s, "SaveDataCRC");
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
                    Game.RaymanOrigins => 288,
                    Game.RaymanLegends => 400,
                    _ => throw new ArgumentOutOfRangeException()
                }, name: nameof(Footer));
            });
        }
    }
}