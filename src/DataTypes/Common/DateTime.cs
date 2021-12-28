namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// Date time data
    /// </summary>
    public class DateTime : BinarySerializable
    {
        public ulong Value { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Value = s.Serialize<ulong>(Value, name: nameof(Value));
        }
    }
}