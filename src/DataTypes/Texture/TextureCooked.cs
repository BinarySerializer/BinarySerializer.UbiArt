namespace BinarySerializer.UbiArt
{
    public class TextureCooked : BinarySerializable
    {
        #region Public Properties

        public long Pre_FileSize { get; set; }
        public bool Pre_SerializeRawData { get; set; } = true;

        public uint Version { get; set; }

        public uint RawDataStartOffset { get; set; }
        public uint RawDataSize { get; set; }

        public ushort Width { get; set; }
        public ushort Height { get; set; }

        public ushort Depth { get; set; }
        public byte Bpp { get; set; }
        public TextureType Type { get; set; }

        public uint V16_Uint_18 { get; set; }

        public uint MemorySize { get; set; }
        public uint UncompressedSize { get; set; }

        public uint OpaquePixelsCount { get; set; }
        public uint HolePixelsCount { get; set; }

        public uint CrcTextureConfig { get; set; }

        public TextureWrapMode WrapModeX { get; set; }
        public TextureWrapMode WrapModeY { get; set; }

        public TextureCooked_Xbox360Header Header_Xbox360 { get; set; }
        public byte[] RawData { get; set; }

        #endregion

        #region Public Methods

        public override void SerializeImpl(SerializerObject s)
        {
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

            if (settings.Game != Game.RaymanOrigins)
            {
                Version = s.Serialize<uint>(Version, name: nameof(Version));
                
                s.SerializeMagicString("TEX", 4, name: "Signature");

                RawDataStartOffset = s.Serialize<uint>(RawDataStartOffset, name: nameof(RawDataStartOffset));
                RawDataSize = s.Serialize<uint>(RawDataSize, name: nameof(RawDataSize));

                Width = s.Serialize<ushort>(Width, name: nameof(Width));
                Height = s.Serialize<ushort>(Height, name: nameof(Height));

                Depth = s.Serialize<ushort>(Depth, name: nameof(Depth));
                Bpp = s.Serialize<byte>(Bpp, name: nameof(Bpp));
                Type = s.Serialize<TextureType>(Type, name: nameof(Type));

                if (Version is 16 or 17)
                    V16_Uint_18 = s.Serialize<uint>(V16_Uint_18, name: nameof(V16_Uint_18));

                MemorySize = s.Serialize<uint>(MemorySize, name: nameof(MemorySize));
                UncompressedSize = s.Serialize<uint>(UncompressedSize, name: nameof(UncompressedSize));

                OpaquePixelsCount = s.Serialize<uint>(OpaquePixelsCount, name: nameof(OpaquePixelsCount));
                HolePixelsCount = s.Serialize<uint>(HolePixelsCount, name: nameof(HolePixelsCount));

                if (Version > 10)
                    CrcTextureConfig = s.Serialize<uint>(CrcTextureConfig, name: nameof(CrcTextureConfig));

                WrapModeX = s.Serialize<TextureWrapMode>(WrapModeX, name: nameof(WrapModeX));
                WrapModeY = s.Serialize<TextureWrapMode>(WrapModeY, name: nameof(WrapModeY));

                s.SerializePadding(2);

                if (Version > 10)
                    s.SerializeMagic<int>(0x00010203, name: "Remap");
            }

            // TODO: This should be serialized as part of the image data since it's part of the Xbox 360 texture file
            if (s.GetRequiredSettings<UbiArtSettings>().Platform == Platform.Xbox360)
                Header_Xbox360 = s.SerializeObject<TextureCooked_Xbox360Header>(Header_Xbox360, name: nameof(Header_Xbox360));

            if (Pre_SerializeRawData)
                RawData = s.SerializeArray<byte>(RawData, Pre_FileSize - (s.CurrentFileOffset - Offset.FileOffset), name: nameof(RawData));
        }

        #endregion
    }
}