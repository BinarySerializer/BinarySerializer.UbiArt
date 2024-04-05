namespace BinarySerializer.UbiArt
{
    public class FileDescriptor : BinarySerializable
    {
        public StringID Id { get; set; }
        public ushort Folder { get; set; }
        public string FileName { get; set; }
        public byte[] Bundles { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

            if (settings.Game == Game.RaymanOrigins)
            {
                Folder = s.Serialize<ushort>(Folder, name: nameof(Folder));
                FileName = s.SerializeObject<String8>(FileName, name: nameof(FileName));
                Bundles = s.SerializeUbiArtArray(Bundles, name: nameof(Bundles));
            }
            else
            {
                Id = s.SerializeObject<StringID>(Id, name: nameof(Id));
                Bundles = s.SerializeUbiArtArray(Bundles, name: nameof(Bundles));
            }
        }
    }
}