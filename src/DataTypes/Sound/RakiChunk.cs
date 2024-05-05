using BinarySerializer.Audio.RIFF;

namespace BinarySerializer.UbiArt
{
    public class RakiChunk : BinarySerializable
    {
        public RakiChunkHeader Pre_Header { get; set; }

        public RIFF_ChunkData Data { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Data = Pre_Header.Identifier switch
            {
                "fmt " => serializeData<RIFF_Chunk_Format>(),
                "data" => serializeData<RIFF_Chunk_Data>(),

                // TODO: Some tracks also have MARK and STRG (always used together)

                _ => s.SerializeObject<RIFF_Chunk_Unknown>((RIFF_Chunk_Unknown)Data, onPreSerialize: x =>
                {
                    x.Pre_ChunkSize = Pre_Header.ChunkSize;
                    x.Pre_Identifier = Pre_Header.Identifier;
                }, name: nameof(Data)),
            };

            RIFF_ChunkData serializeData<T>() 
                where T : RIFF_ChunkData, new()
            {
                return s.SerializeObject<T>((T)Data, onPreSerialize: d => d.Pre_ChunkSize = Pre_Header.ChunkSize, name: nameof(Data));
            }
        }
    }
}