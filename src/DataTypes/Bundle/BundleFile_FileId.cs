namespace BinarySerializer.UbiArt
{
    public class BundleFile_FileId : BinarySerializable
    {
        public int Id { get; set; } // Index
        public StringID PathStringId { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Id = s.Serialize<int>(Id, name: nameof(Id));
            PathStringId = s.SerializeObject<StringID>(PathStringId, name: nameof(PathStringId));
        }
    }
}