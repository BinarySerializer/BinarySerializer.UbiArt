namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// The level progress data for Rayman Fiesta Run
    /// </summary>
    public class FiestaRun_SaveDataLevel : BinarySerializable
    {
        public byte Lums { get; set; } // Last amount of Lums earned in the level. Max is 100.
        public byte Electoons { get; set; } // 0-4

        public bool Flag0 { get; set; } // Hidden/not unlocked?
        public bool HasCrown { get; set; }
        public bool Flag2 { get; set; } // Played level?

        public ushort Ushort_0A { get; set; }
        public ushort Ushort_0C { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Lums = s.Serialize<byte>(Lums, name: nameof(Lums));
            Electoons = s.Serialize<byte>(Electoons, name: nameof(Electoons));
            s.DoBits<long>(b =>
            {
                Flag0 = b.SerializeBits<bool>(Flag0, 1, name: nameof(Flag0));
                HasCrown = b.SerializeBits<bool>(HasCrown, 1, name: nameof(HasCrown));
                Flag2 = b.SerializeBits<bool>(Flag2, 1, name: nameof(Flag2));
            });
            Ushort_0A = s.Serialize<ushort>(Ushort_0A, name: nameof(Ushort_0A));
            Ushort_0C = s.Serialize<ushort>(Ushort_0C, name: nameof(Ushort_0C));
        }
    }
}