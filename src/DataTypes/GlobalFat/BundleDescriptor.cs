namespace BinarySerializer.UbiArt
{
    public class BundleDescriptor : BinarySerializable
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Id = s.Serialize<byte>(Id, name: nameof(Id));
            Name = s.SerializeObject<String8>(Name, name: nameof(Name));
        }
    }
}