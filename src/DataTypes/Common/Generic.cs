namespace BinarySerializer.UbiArt
{
    public class Generic<T> : BinarySerializable
        where T : BinarySerializable, new()
    {
        public StringID Name { get; set; }
        public T Object { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Name = s.SerializeObject<StringID>(Name, name: nameof(Name));
            Object = s.SerializeObject<T>(Object, name: nameof(Object));
        }
    }
}