namespace BinarySerializer.UbiArt
{
    public class FilePackMaster : BinarySerializable
    {
        public uint Pre_BundleVersion { get; set; }

        public BundleFile_FileEntry[] Files { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Files = s.SerializeArraySize<BundleFile_FileEntry, uint>(Files, name: nameof(Files));
            Files = s.SerializeObjectArray<BundleFile_FileEntry>(Files, Files.Length, x => x.Pre_BundleVersion = Pre_BundleVersion, name: nameof(Files));
        }
    }
}