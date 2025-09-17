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

        public uint Count { get; set; }
        public uint OriginalSize { get; set; }
        public uint CompressedSize { get; set; }
        public long FlushTime { get; set; } // LastTimeWriteAccess
        public DateTimeOffset FlushTimeDateTimeOffset
        {
            get => DateTimeOffset.FromFileTime(FlushTime);
            set => FlushTime = value.ToFileTime();
        }
        public ulong[] Positions { get; set; } // Can have multiple offsets for less seeking
        public Path Path { get; set; }

        public bool IsCompressed => CompressedSize != 0;
        public uint ArchiveSize => IsCompressed ? CompressedSize : OriginalSize;

        #endregion

        #region Public Methods

        public override void SerializeImpl(SerializerObject s)
        {
            // Serialize header values
            if (Pre_BundleVersion != 4)
                Count = s.Serialize<uint>(Count, name: nameof(Count));
            else
                Count = 1;

            OriginalSize = s.Serialize<uint>(OriginalSize, name: nameof(OriginalSize));
            CompressedSize = s.Serialize<uint>(CompressedSize, name: nameof(CompressedSize));
            FlushTime = s.Serialize<long>(FlushTime, name: nameof(FlushTime));
            Positions = s.SerializeArray<ulong>(Positions, (int)Count, name: nameof(Positions));

            if (Pre_BundleVersion == 4)
                return;

            // For any game after Origins the path is in the standard format
            if (Pre_BundleVersion >= 5)
                Path = s.SerializeObject<Path>(Path, name: nameof(Path));
            else
                Path = new Path(s.SerializeObject<String16>(Path?.FullPath, name: nameof(Path)));
        }

        #endregion
    }
}