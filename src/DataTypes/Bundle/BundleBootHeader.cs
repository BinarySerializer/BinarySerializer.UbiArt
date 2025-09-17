namespace BinarySerializer.UbiArt
{
    public class BundleBootHeader : BinarySerializable
    {
        public uint Version { get; set; }
        public uint Dlc { get; set; } // Unknown, but DLC related
        public BundlePlatform PlatformSupported { get; set; }
        public uint FilesStart { get; set; }
        public uint FilesCount { get; set; }
        public bool Compressed { get; set; }
        public bool BinaryScene { get; set; }
        public bool BinaryLogic { get; set; }
        public bool ValiantHeartsBool { get; set; } // Unknown
        public uint DataSignature { get; set; }
        public uint EngineSignature { get; set; }
        public uint EngineVersion { get; set; }
        public uint BlockSize { get; set; }
        public uint BlockCompressedSize { get; set; }

        public bool IsBlockCompressed => BlockSize != 0;
        public bool SupportsCompressedBlock => Version >= 6;

        public static IStreamEncoder GetEncoder(uint bundleVersion, long decompressedSize)
        {
            // Use LZMA
            if (bundleVersion >= 8)
                return new SevenZipEncoder(decompressedSize);
            // Use ZLib
            else
                return new ZLibEncoder();
        }

        public override void SerializeImpl(SerializerObject s)
        {
            // Serialize and verify the magic number
            s.SerializeMagic(0x50EC12BA);

            // Serialize the version
            Version = s.Serialize<uint>(Version, name: nameof(Version));

            if (Version >= 8)
                Dlc = s.Serialize<uint>(Dlc, name: nameof(Dlc));

            PlatformSupported = s.Serialize<BundlePlatform>(PlatformSupported, name: nameof(PlatformSupported));

            FilesStart = s.Serialize<uint>(FilesStart, name: nameof(FilesStart));
            FilesCount = s.Serialize<uint>(FilesCount, name: nameof(FilesCount));

            Compressed = s.SerializeUbiArtBool(Compressed, name: nameof(Compressed));
            BinaryScene = s.SerializeUbiArtBool(BinaryScene, name: nameof(BinaryScene));
            BinaryLogic = s.SerializeUbiArtBool(BinaryLogic, name: nameof(BinaryLogic));

            if (s.GetRequiredSettings<UbiArtSettings>().Game == Game.ValiantHearts)
                ValiantHeartsBool = s.SerializeUbiArtBool(ValiantHeartsBool, name: nameof(ValiantHeartsBool));

            DataSignature = s.Serialize<uint>(DataSignature, name: nameof(DataSignature));

            EngineSignature = s.Serialize<uint>(EngineSignature, name: nameof(EngineSignature));
            EngineVersion = s.Serialize<uint>(EngineVersion, name: nameof(EngineVersion));

            if (SupportsCompressedBlock)
            {
                BlockSize = s.Serialize<uint>(BlockSize, name: nameof(BlockSize));
                BlockCompressedSize = s.Serialize<uint>(BlockCompressedSize, name: nameof(BlockCompressedSize));
            }
        }
    }
}