using System;

namespace BinarySerializer.UbiArt
{
    public class FiestaRun_ShopItems<T> : BinarySerializable
        where T : struct
    {
        public ushort Pre_Version { get; set; }
        public bool Pre_HasStatus { get; set; }
        public bool Pre_HasNewUnlocks { get; set; }
        public int Pre_Count { get; set; }
        public int Pre_OldCount { get; set; }
        public int Pre_StartIndex { get; set; }

        public ItemStatus[] Status { get; set; }
        public bool[] IsNewUnlockFlags { get; set; }

        // Version 2 and above only
        public bool[] IsOwnedFlags { get; set; }
        public bool[] IsFirstShownFlags { get; set; }
        public bool[] UnknownFlags { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            // For legacy support the game has increased all state values by 4 in the new version
            bool isNewVersion = false;

            if (Pre_HasStatus)
            {
                int statusIndex = Pre_StartIndex;

                Status = s.SerializeArrayUntil<ItemStatus>(Status, x =>
                {
                    if ((byte)x > 4)
                        isNewVersion = true;

                    if (!Enum.IsDefined(typeof(ItemStatus), x))
                        throw new Exception($"Invalid item status value: {x}");

                    statusIndex++;

                    return statusIndex >= Pre_Count || 
                           statusIndex >= Pre_OldCount && !isNewVersion;
                }, name: nameof(Status));
            }

            if (Pre_HasNewUnlocks)
            {
                int count = Pre_Count;

                if (!isNewVersion && Pre_OldCount < Pre_Count)
                    count = Pre_OldCount;

                s.DoBits<T>(b =>
                {
                    IsNewUnlockFlags ??= new bool[count - Pre_StartIndex];

                    for (int i = 0; i < IsNewUnlockFlags.Length; i++)
                        IsNewUnlockFlags[i] = b.SerializeBits<bool>(IsNewUnlockFlags[i], 1, name: $"{nameof(IsNewUnlockFlags)}[{i}]");
                });
            }

            if (Pre_Version < 2)
                return;

            s.DoBits<T>(b =>
            {
                IsOwnedFlags ??= new bool[Pre_Count - Pre_StartIndex];

                for (int i = 0; i < IsOwnedFlags.Length; i++)
                    IsOwnedFlags[i] = b.SerializeBits<bool>(IsOwnedFlags[i], 1, name: $"{nameof(IsOwnedFlags)}[{i}]");
            });

            s.DoBits<T>(b =>
            {
                IsFirstShownFlags ??= new bool[Pre_Count - Pre_StartIndex];

                for (int i = 0; i < IsFirstShownFlags.Length; i++)
                    IsFirstShownFlags[i] = b.SerializeBits<bool>(IsFirstShownFlags[i], 1, name: $"{nameof(IsFirstShownFlags)}[{i}]");
            });

            s.DoBits<T>(b =>
            {
                UnknownFlags ??= new bool[Pre_Count - Pre_StartIndex];

                for (int i = 0; i < UnknownFlags.Length; i++)
                    UnknownFlags[i] = b.SerializeBits<bool>(UnknownFlags[i], 1, name: $"{nameof(UnknownFlags)}[{i}]");
            });
        }

        public enum ItemStatus : byte
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