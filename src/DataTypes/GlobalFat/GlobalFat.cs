namespace BinarySerializer.UbiArt
{
    public class GlobalFat : BinarySerializable
    {
        public BundleDescriptor[] Bundles { get; set; }
        public FileDescriptor[] Files { get; set; }
        public FolderDescriptor[] Folders { get; set; }
        public FileAdditionalDescriptor[] FilesAdditional { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

            if (settings.Game == Game.RaymanOrigins)
            {
                Files = s.SerializeUbiArtObjectArray<FileDescriptor>(Files, name: nameof(Files));
                Bundles = s.SerializeUbiArtObjectArray<BundleDescriptor>(Bundles, name: nameof(Bundles));
                Folders = s.SerializeUbiArtObjectArray<FolderDescriptor>(Folders, name: nameof(Folders));
            }
            else
            {
                Bundles = s.SerializeUbiArtObjectArray<BundleDescriptor>(Bundles, name: nameof(Bundles));
                Files = s.SerializeUbiArtObjectArray<FileDescriptor>(Files, name: nameof(Files));

                if (settings.Game == Game.RaymanLegends)
                {
                    Folders = s.SerializeUbiArtObjectArray<FolderDescriptor>(Folders, name: nameof(Folders));
                    FilesAdditional = s.SerializeObjectArray<FileAdditionalDescriptor>(FilesAdditional, Files.Length, name: nameof(FilesAdditional));
                }
            }
        }
    }
}