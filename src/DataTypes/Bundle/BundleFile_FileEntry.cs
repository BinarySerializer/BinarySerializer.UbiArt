using System;

namespace BinarySerializer.UbiArt
{
    // NOTE: This is actually a a value pair with the first value being the header (FileHeaderRuntime) and the second the path. However
    //       due to Origins storing the path differently we serialize it all as one class for now.

    /// <summary>
    /// The data used for a file entry within an IPK file
    /// </summary>
    public class BundleFile_FileEntry : BinarySerializable
    {
        #region Public Properties

        public uint Pre_BundleVersion { get; set; }

        public uint OffsetsCount { get; set; }
        public uint FileSize { get; set; }
        public uint CompressedSize { get; set; }
        public long TimeStamp { get; set; } // LastTimeWriteAccess
        public DateTimeOffset TimeStampDateTimeOffset
        {
            get => DateTimeOffset.FromFileTime(TimeStamp);
            set => TimeStamp = value.ToFileTime();
        }
        public ulong[] Offsets { get; set; } // Can be multiple for less seeking
        public Path Path { get; set; }

        public bool IsCompressed => CompressedSize != 0;
        public uint ArchiveSize => IsCompressed ? CompressedSize : FileSize;

        #endregion

        #region Public Methods

        public override void SerializeImpl(SerializerObject s)
        {
            // 3DS file entries can not be serialized separately
            if (Pre_BundleVersion == 4)
                throw new BinarySerializableException(this, $"Bundles with version 4 do not use {nameof(BundleFile_FileEntry)}");

            // Serialize header values
            OffsetsCount = s.Serialize<uint>(OffsetsCount, name: nameof(OffsetsCount));
            FileSize = s.Serialize<uint>(FileSize, name: nameof(FileSize));
            CompressedSize = s.Serialize<uint>(CompressedSize, name: nameof(CompressedSize));
            TimeStamp = s.Serialize<long>(TimeStamp, name: nameof(TimeStamp));
            Offsets = s.SerializeArray<ulong>(Offsets, (int)OffsetsCount, name: nameof(Offsets));

            // For any game after Origins the path is in the standard format
            if (Pre_BundleVersion >= 5)
                Path = s.SerializeObject<Path>(Path, name: nameof(Path));
            else
                Path = new Path(s.SerializeObject<String16>(Path?.FullPath, name: nameof(Path)));
        }

        #endregion
    }
}