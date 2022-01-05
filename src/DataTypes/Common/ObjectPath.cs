namespace BinarySerializer.UbiArt
{
    public class ObjectPath : BinarySerializable
    {
        public Level[] Levels { get; set; }
        public string Id { get; set; }
        public bool Absolute { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            if (s.GetSettings<UbiArtSettings>().Game == Game.RaymanOrigins)
            {
                Id = s.SerializeObject<String8>(Id, name: nameof(Id));
            }
            else
            {
                Levels = s.SerializeUbiArtObjectArray<Level>(Levels, name: nameof(Levels));
                Id = s.SerializeObject<String8>(Id, name: nameof(Id));
                Absolute = s.SerializeUbiArtBool(Absolute, name: nameof(Absolute));
            }
        }

        public class Level : BinarySerializable
        {
            public string Name { get; set; }
            public bool Parent { get; set; }

            public override void SerializeImpl(SerializerObject s)
            {
                Name = s.SerializeObject<String8>(Name, name: nameof(Name));
                Parent = s.SerializeUbiArtBool(Parent);
            }
        }
    }
}