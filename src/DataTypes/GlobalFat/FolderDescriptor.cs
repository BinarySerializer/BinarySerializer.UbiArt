namespace BinarySerializer.UbiArt
{
    public class FolderDescriptor : BinarySerializable
    {
        public string Path { get; set; }
        public ushort Id { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Path = s.SerializeObject<String8>(Path, name: nameof(Path));
            Id = s.Serialize<ushort>(Id, name: nameof(Id));
        }
    }
}