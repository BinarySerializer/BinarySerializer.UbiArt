namespace BinarySerializer.UbiArt
{
    public class TextureCooked : BinarySerializable
    {
        #region Public Properties

        public long Pre_FileSize { get; set; }
        public bool Pre_SerializeImageData { get; set; } = true;

        public uint Version { get; set; }
        public uint Signature { get; set; }
        public uint HdrSize { get; set; }

        public uint TextureSize { get; set; } // Size in bytes. Always 0 on PS Vita. On Wii U this does not match the actual size.

        public ushort Width { get; set; }
        public ushort Height { get; set; }

        public ushort UnknownX { get; set; }
        public ushort UnknownY { get; set; }

        public uint Unknown6 { get; set; }

        public uint TextureSize2 { get; set; } // Same as TextureSize?

        public uint Unknown0 { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }

        public TextureCooked_Xbox360Header Header_Xbox360 { get; set; }

        public byte[] ImageData { get; set; }

        #endregion

        #region Public Methods

        public override void SerializeImpl(SerializerObject s)
        {
            Version = s.Serialize<uint>(Version, name: nameof(Version));
            Signature = s.Serialize<uint>(Signature, name: nameof(Signature));

            if (Signature != 0x54455800) // TEX
                throw new BinarySerializableException(this, "The file signature does not match TEX");

            HdrSize = s.Serialize<uint>(HdrSize, name: nameof(HdrSize));

            TextureSize = s.Serialize<uint>(TextureSize, name: nameof(TextureSize));
            Width = s.Serialize<ushort>(Width, name: nameof(Width));
            Height = s.Serialize<ushort>(Height, name: nameof(Height));
            UnknownX = s.Serialize<ushort>(UnknownX, name: nameof(UnknownX));
            UnknownY = s.Serialize<ushort>(UnknownY, name: nameof(UnknownY));

            if (Version == 16 || Version == 17)
                Unknown6 = s.Serialize<uint>(Unknown6, name: nameof(Unknown6));

            TextureSize2 = s.Serialize<uint>(TextureSize2, name: nameof(TextureSize2));

            Unknown0 = s.Serialize<uint>(Unknown0, name: nameof(Unknown0));
            Unknown1 = s.Serialize<uint>(Unknown1, name: nameof(Unknown1));
            Unknown2 = s.Serialize<uint>(Unknown2, name: nameof(Unknown2));

            if (Version > 10)
                Unknown3 = s.Serialize<uint>(Unknown3, name: nameof(Unknown3));

            Unknown4 = s.Serialize<uint>(Unknown4, name: nameof(Unknown4));

            if (Version > 10)
                Unknown5 = s.Serialize<uint>(Unknown5, name: nameof(Unknown5));

            if (s.GetSettings<UbiArtSettings>().Platform == Platform.Xbox360)
                Header_Xbox360 = s.SerializeObject<TextureCooked_Xbox360Header>(Header_Xbox360, name: nameof(Header_Xbox360));

            if (Pre_SerializeImageData)
                ImageData = s.SerializeArray<byte>(ImageData, Pre_FileSize - (s.CurrentFileOffset - Offset.FileOffset), name: nameof(ImageData));
        }

        #endregion
    }
}