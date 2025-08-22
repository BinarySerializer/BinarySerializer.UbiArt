namespace BinarySerializer.UbiArt
{
    // https://github.com/vgmstream/vgmstream/blob/master/src/meta/ubi_raki.c
    public class Raki : BinarySerializable
    {
        // Header
        public uint Version { get; set; }
        public uint Compress { get; set; }
        public string Platform { get; set; }
        public string Format { get; set; }
        public int NonDataSize { get; set; }
        public int DataOffset { get; set; }
        public RakiFlags Flags { get; set; }

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
                    NonDataSize = offset;
                    DataOffset = offset;
                }

                offset += chunkHeader.ChunkSize;
            }
        }

        public override void SerializeImpl(SerializerObject s)
        {
            Version = s.Serialize<uint>(Version, name: nameof(Version));

            if (Version is not (11 or 15))
                throw new UnsupportedFormatVersionException(this, $"RAKI version {Version} is not supported");

            // The endian is dependent on the platform
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();
            Endian endian = settings.Platform switch
            {
                UbiArt.Platform.PC => Endian.Little,
                UbiArt.Platform.PlayStation4 => Endian.Little,
                _ => throw new BinarySerializableException(this, $"Serializing RAKI is not currently supported for the platform {settings.Platform}")
            };
            s.DoEndian(endian, () =>
            {
                s.SerializeMagicString("RAKI", 4);
                Compress = s.Serialize<uint>(Compress, name: nameof(Compress));
                Platform = s.SerializeString(Platform, length: 4, name: nameof(Platform));
                Format = s.SerializeString(Format, length: 4, name: nameof(Format));
                NonDataSize = s.Serialize<int>(NonDataSize, name: nameof(NonDataSize));
                DataOffset = s.Serialize<int>(DataOffset, name: nameof(DataOffset));
                ChunkHeaders = s.SerializeArraySize<RakiChunkHeader, uint>(ChunkHeaders, name: nameof(ChunkHeaders));
                Flags = s.Serialize<RakiFlags>(Flags, name: nameof(Flags));

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