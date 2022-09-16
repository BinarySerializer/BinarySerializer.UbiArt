using System;

namespace BinarySerializer.UbiArt
{
    public class FiestaRun_ShopItems<T> : BinarySerializable
        where T : struct
    {
        public ushort Pre_Version { get; set; }
        public bool Pre_HasStates { get; set; } // a6
        public bool Pre_HasUnknownItems { get; set; } // a7
        public int Pre_Count { get; set; } // a3
        public int Pre_OldCount { get; set; } // a8
        public int Pre_StartIndex { get; set; } // a9

        public ItemState[] States { get; set; }
        public bool[] ExclamationFlags { get; set; }

        // Version 2 and above only
        public bool[] Flags_2 { get; set; }
        public bool[] Flags_3 { get; set; }
        public bool[] Flags_4 { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            // For legacy support the game has increased all state values by 4 in the new version
            bool isNewVersion = false;

            // Heroes
            if (Pre_HasStates)
            {
                int stateIndex = Pre_StartIndex;

                States = s.SerializeArrayUntil<ItemState>(States, x =>
                {
                    if ((byte)x > 4)
                        isNewVersion = true;

                    if (!Enum.IsDefined(typeof(ItemState), x))
                        throw new Exception($"Invalid item state value: {x}");

                    stateIndex++;

                    return stateIndex >= Pre_Count || 
                           stateIndex >= Pre_OldCount && !isNewVersion;
                }, name: nameof(States));
            }

            if (Pre_HasUnknownItems)
            {
                int count = Pre_Count;

                if (!isNewVersion && Pre_OldCount < Pre_Count)
                    count = Pre_OldCount;

                s.DoBits<T>(b =>
                {
                    ExclamationFlags ??= new bool[count - Pre_StartIndex];

                    for (int i = 0; i < ExclamationFlags.Length; i++)
                        ExclamationFlags[i] = b.SerializeBits<bool>(ExclamationFlags[i], 1, name: $"{nameof(ExclamationFlags)}[{i}]");
                });
            }

            if (Pre_Version < 2)
                return;

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

        public enum ItemState : byte
        {
            // Old version
            Old_NotPurchased = 0,
            Old_Hidden = 1,
            Old_Purchased = 2,
            Old_Current = 3,
            Old_State_4 = 4, // ?

            // New version
            NotPurchased = 5,
            Hidden = 6,
            Purchased = 7,
            Current = 8,
            State_4 = 9, // ?
        }
    }
}