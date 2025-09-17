namespace BinarySerializer.UbiArt
{
    public enum BundlePlatform : uint
    {
        PC = 0,
        X360 = 1,
        PS3 = 2,
        // 3 is unused
        IPAD = 4,     // Unused (Rayman Origins for iPad was canceled)
        CTR = 5,
        WII = 6,      // Also VITA for Rayman Legends and Child of Light
        WIIU = 7,     // Also VITA for Rayman Origins
        ORBIS = 8,    // Also WIIU for Just Dance
        DURANGO = 9,
        NX = 10,      // Also IOS for Rayman Adventures, ANDROID for Valiant Hearts and CTR for Gravity Falls
        ANDROID = 11, // Also NX for Just Dance
        MACOS = 12,
    }
}