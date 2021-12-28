namespace BinarySerializer.UbiArt
{
    public class LocalisationId : BinarySerializable
    {
        public uint ID { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            ID = s.Serialize<uint>(ID, name: nameof(ID));
        }
    }
}