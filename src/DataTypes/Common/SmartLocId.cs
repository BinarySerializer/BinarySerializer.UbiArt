namespace BinarySerializer.UbiArt
{
    public class SmartLocId : BinarySerializable
    {
        public string DefaultText { get; set; }
        public LocalisationId LocId { get; set; }
        public bool UseText { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            DefaultText = s.SerializeObject<String8>(DefaultText, name: nameof(DefaultText));
            LocId = s.SerializeObject<LocalisationId>(LocId, name: nameof(LocId));
            UseText = s.SerializeUbiArtBool(UseText, name: nameof(UseText));
        }
    }
}