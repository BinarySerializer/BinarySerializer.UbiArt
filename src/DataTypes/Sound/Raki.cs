namespace BinarySerializer.UbiArt
{
    // https://github.com/vgmstream/vgmstream/blob/master/src/meta/ubi_raki.c
    public class Raki : BinarySerializable
    {
        // Header
        public uint Version { get; set; }
        public uint Uint_08 { get; set; } // Always 0
        public string Platform { get; set; }
        public string Format { get; set; }
        public int DataOffset1 { get; set; }
        public int DataOffset2 { get; set; }
        public uint Uint_20 { get; set; } // Sound type? For Legends it seems to be 0 = sfx, 1 = ambience, 3 = music?

        // Chunks (usually just fmt and data, but more complex tracks, like for music levels, have more chunks)
        public RakiChunkHeader[] ChunkHeaders { get; set; }
        public RakiChunk[] Chunks { get; set; }

        public void CalculateOffsets()
        {
            int offset = 36; // Header
            offset += ChunkHeaders.Length * 12; // Chunk headers

            // Allocate each chunk
            foreach (RakiChunkHeader chunkHeader in ChunkHeaders)
            {
                chunkHeader.ChunkOffset = offset;

                if (chunkHeader.Identifier == "data")
                {
                    DataOffset1 = offset;
                    DataOffset2 = offset;
                }

                offset += chunkHeader.ChunkSize;
            }
        }

        public override void SerializeImpl(SerializerObject s)
        {
            Version = s.Serialize<uint>(Version, name: nameof(Version));

            if (Version != 11)
                throw new UnsupportedFormatVersionException(this, $"RAKI version {Version} is not supported");

            // The endian is dependent on the platform
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();
            Endian endian = settings.Platform switch
            {
                UbiArt.Platform.PC => Endian.Little,
                _ => throw new BinarySerializableException(this, $"Serializing RAKI is not currently supported for the platform {settings.Platform}")
            };
            s.DoEndian(endian, () =>
            {
                s.SerializeMagicString("RAKI", 4);
                Uint_08 = s.Serialize<uint>(Uint_08, name: nameof(Uint_08));
                Platform = s.SerializeString(Platform, length: 4, name: nameof(Platform));
                Format = s.SerializeString(Format, length: 4, name: nameof(Format));
                DataOffset1 = s.Serialize<int>(DataOffset1, name: nameof(DataOffset1));
                DataOffset2 = s.Serialize<int>(DataOffset2, name: nameof(DataOffset2));
                ChunkHeaders = s.SerializeArraySize<RakiChunkHeader, uint>(ChunkHeaders, name: nameof(ChunkHeaders));
                Uint_20 = s.Serialize<uint>(Uint_20, name: nameof(Uint_20));

                ChunkHeaders = s.SerializeObjectArray<RakiChunkHeader>(ChunkHeaders, ChunkHeaders.Length, name: nameof(ChunkHeaders));

                Chunks = s.InitializeArray(Chunks, ChunkHeaders.Length);
                s.DoArray(Chunks, (obj, i, name) =>
                {
                    RakiChunkHeader header = ChunkHeaders[i];
                    s.Goto(Offset + header.ChunkOffset);
                    obj = s.SerializeObject<RakiChunk>(obj, x => x.Pre_Header = header, name: name);

                    if (obj.SerializedSize != header.ChunkSize)
                        s.SystemLogger?.LogWarning("The serialized RAKI chunk size {0} does not match the expected size {1}", obj.SerializedSize, header.ChunkSize);

                    return obj;
                });
            });
        }
    }
}