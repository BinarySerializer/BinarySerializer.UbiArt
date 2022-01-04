namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// The archive data used for IPK files
    /// </summary>
    public class BundleFile : BinarySerializable
    {
        public BundleBootHeader BootHeader { get; set; }
        public FilePackMaster FilePack { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            BootHeader = s.SerializeObject<BundleBootHeader>(BootHeader, name: nameof(BootHeader));
            FilePack = s.SerializeObject<FilePackMaster>(FilePack, x => x.Pre_BundleVersion = BootHeader.Version, name: nameof(FilePack));

            // NOTE: So far this only appears to be the case for the bundle_pc32.ipk file used in Child of Light
            if (FilePack.Files.Length != BootHeader.FilesCount)
                s.LogWarning($"The initial file count {BootHeader.FilesCount} does not match the file array size {FilePack.Files.Length}");

            long endOffset = s.CurrentFileOffset - Offset.FileOffset;

            if (endOffset != BootHeader.BaseOffset)
                s.LogWarning($"Offset value {BootHeader.BaseOffset} doesn't match file entry end offset {endOffset}");
        }
    }
}