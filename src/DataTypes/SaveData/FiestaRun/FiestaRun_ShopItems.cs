namespace BinarySerializer.UbiArt
{
    public class FiestaRun_ShopItems<T> : BinarySerializable
    {
        public bool Pre_HasHeroes { get; set; } // a6
        public bool Pre_HasUnknownItems { get; set; } // a7
        public int Pre_Count { get; set; } // a3
        public int Pre_OldCount { get; set; } // a8
        public int Pre_StartIndex { get; set; } // a9

        public HeroState[] HeroStates { get; set; }
        public bool[] Flags_1 { get; set; }
        public bool[] Flags_2 { get; set; }
        public bool[] Flags_3 { get; set; }
        public bool[] Flags_4 { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            // For legacy support the game has increased all hero state values by 4 in the new version
            bool isNewVersion = false;

            // Heroes
            if (Pre_HasHeroes)
            {
                int heroIndex = Pre_StartIndex;

                HeroStates = s.SerializeArrayUntil<HeroState>(HeroStates, x =>
                {
                    if ((byte)x > 4)
                        isNewVersion = true;

                    heroIndex++;

                    return heroIndex >= Pre_Count || 
                           heroIndex >= Pre_OldCount && !isNewVersion;
                }, name: nameof(HeroStates));
            }

            if (Pre_HasUnknownItems)
            {
                int count = Pre_Count;

                if (!isNewVersion && Pre_OldCount < Pre_Count)
                    count = Pre_OldCount;

                s.DoBits<T>(b =>
                {
                    Flags_1 ??= new bool[count - Pre_StartIndex];

                    for (int i = 0; i < Flags_1.Length; i++)
                        Flags_1[i] = b.SerializeBits<bool>(Flags_1[i], 1, name: $"{nameof(Flags_1)}[{i}]");
                });
            }

            s.DoBits<T>(b =>
            {
                Flags_2 ??= new bool[Pre_Count - Pre_StartIndex];

                for (int i = 0; i < Flags_2.Length; i++)
                    Flags_2[i] = b.SerializeBits<bool>(Flags_2[i], 1, name: $"{nameof(Flags_2)}[{i}]");
            });

            s.DoBits<T>(b =>
            {
                Flags_3 ??= new bool[Pre_Count - Pre_StartIndex];

                for (int i = 0; i < Flags_3.Length; i++)
                    Flags_3[i] = b.SerializeBits<bool>(Flags_3[i], 1, name: $"{nameof(Flags_3)}[{i}]");
            });

            s.DoBits<T>(b =>
            {
                Flags_4 ??= new bool[Pre_Count - Pre_StartIndex];

                for (int i = 0; i < Flags_4.Length; i++)
                    Flags_4[i] = b.SerializeBits<bool>(Flags_4[i], 1, name: $"{nameof(Flags_4)}[{i}]");
            });
        }

        public enum HeroState : byte
        {
            // Old version
            Old_NotAvailable = 0,
            Old_HeroState_1 = 1,
            Old_HeroState_2 = 2,
            Old_Current = 3,
            Old_HeroState_4 = 4,

            // New version
            NotAvailable = 5,
            HeroState_1 = 6,
            HeroState_2 = 7,
            Current = 8,
            HeroState_4 = 9,
        }
    }
}