using System;

namespace BinarySerializer.UbiArt
{
    [Flags]
    public enum RakiFlags : uint
    {
        None = 0, // Usually used for sfx
        IsStreamed = 1 << 0, // Usually used for ambience and music
        IsMusic = 1 << 1, // Used for music
    }
}