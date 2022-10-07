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
                s.SystemLogger?.LogWarning("The initial file count {0} does not match the file array size {1}", 
                    BootHeader.FilesCount, FilePack.Files.Length);

            long endOffset = s.CurrentFileOffset - Offset.FileOffset;

            if (endOffset != BootHeader.BaseOffset)
                s.SystemLogger?.LogWarning("Offset value {0} doesn't match file entry end offset {1}",
                    BootHeader.BaseOffset, endOffset);
        }
    }
}