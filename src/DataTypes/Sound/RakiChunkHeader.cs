using System.Text;

namespace BinarySerializer.UbiArt
{
    public class RakiChunkHeader : BinarySerializable
    {
        public string Identifier { get; set; }
        public int ChunkOffset { get; set; }
        public int ChunkSize { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Identifier = s.SerializeString(Identifier, 4, Encoding.ASCII, name: nameof(Identifier));
            ChunkOffset = s.Serialize<int>(ChunkOffset, name: nameof(ChunkOffset));
            ChunkSize = s.Serialize<int>(ChunkSize, name: nameof(ChunkSize));
        }
    }
}