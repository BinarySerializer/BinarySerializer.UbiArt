namespace BinarySerializer.UbiArt
{
    public class FilePackMaster : BinarySerializable
    {
        public uint Pre_BundleVersion { get; set; }

        public BundleFile_FileEntry[] Files { get; set; }

        // Only for Origins 3DS (version 4)
        public BundleFile_FileId[] FileIds { get; set; }
        public String16[] FilePaths { get; set; }
        public uint[] Reserved { get; set; } // Always 0-filled

        public override void SerializeImpl(SerializerObject s)
        {
            Files = s.SerializeArraySize<BundleFile_FileEntry, uint>(Files, name: nameof(Files));
            Files = s.SerializeObjectArray<BundleFile_FileEntry>(Files, Files.Length, x => x.Pre_BundleVersion = Pre_BundleVersion, name: nameof(Files));

            if (Pre_BundleVersion == 4)
            {
                FileIds = s.SerializeObjectArray<BundleFile_FileId>(FileIds, Files.Length, name: nameof(FileIds));
                FilePaths = s.SerializeObjectArray<String16>(FilePaths, Files.Length, name: nameof(FilePaths));
                Reserved = s.SerializeArray<uint>(Reserved, Files.Length, name: nameof(Reserved));
            }
        }
    }
}