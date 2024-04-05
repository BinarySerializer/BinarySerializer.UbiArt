namespace BinarySerializer.UbiArt
{
    public class FileAdditionalDescriptor : BinarySerializable
    {
        public StringID Id { get; set; }
        public ushort Folder { get; set; }
        public string FileName { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Id = s.SerializeObject<StringID>(Id, name: nameof(Id));
            Folder = s.Serialize<ushort>(Folder, name: nameof(Folder));
            FileName = s.SerializeObject<String8>(FileName, name: nameof(FileName));
        }
    }
}