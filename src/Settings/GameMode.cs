namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// The available game modes
    /// </summary>
    public enum GameMode
    {
        [GameModeInfo("Rayman Origins (PC)", EngineVersion.RaymanOrigins, Platform.PC)]
        RaymanOriginsPC,

        [GameModeInfo("Rayman Origins (PS3)", EngineVersion.RaymanOrigins, Platform.PlayStation3)]
        RaymanOriginsPS3,

        [GameModeInfo("Rayman Origins (Xbox 360)", EngineVersion.RaymanOrigins, Platform.Xbox360)]
        RaymanOriginsXbox360,

        [GameModeInfo("Rayman Origins (Wii)", EngineVersion.RaymanOrigins, Platform.Wii)]
        RaymanOriginsWii,

        [GameModeInfo("Rayman Origins (PS Vita)", EngineVersion.RaymanOrigins, Platform.PSVita)]
        RaymanOriginsPSVita,

        [GameModeInfo("Rayman Origins (3DS)", EngineVersion.RaymanOrigins, Platform.Nintendo3DS)]
        RaymanOrigins3DS,

        [GameModeInfo("Rayman Jungle Run (PC)", EngineVersion.RaymanJungleRun, Platform.PC)]
        RaymanJungleRunPC,

        [GameModeInfo("Rayman Jungle Run (Android)", EngineVersion.RaymanJungleRun, Platform.Android)]
        RaymanJungleRunAndroid,

        [GameModeInfo("Rayman Legends (PC)", EngineVersion.RaymanLegends, Platform.PC)]
        RaymanLegendsPC,

        [GameModeInfo("Rayman Legends (Xbox 360)", EngineVersion.RaymanLegends, Platform.Xbox360)]
        RaymanLegendsXbox360,

        [GameModeInfo("Rayman Legends (Wii U)", EngineVersion.RaymanLegends, Platform.WiiU)]
        RaymanLegendsWiiU,

        [GameModeInfo("Rayman Legends (PS Vita)", EngineVersion.RaymanLegends, Platform.PSVita)]
        RaymanLegendsPSVita,

        [GameModeInfo("Rayman Legends (PS4)", EngineVersion.RaymanLegends, Platform.PlayStation4)]
        RaymanLegendsPS4,

        [GameModeInfo("Rayman Legends (Switch)", EngineVersion.RaymanLegends, Platform.NintendoSwitch)]
        RaymanLegendsSwitch,

        [GameModeInfo("Rayman Fiesta Run (PC)", EngineVersion.RaymanFiestaRun, Platform.PC)]
        RaymanFiestaRunPC,

        [GameModeInfo("Rayman Fiesta Run (Android)", EngineVersion.RaymanJungleRun, Platform.Android)]
        RaymanFiestaRunAndroid,

        [GameModeInfo("Rayman Adventures (Android)", EngineVersion.RaymanAdventures, Platform.Android)]
        RaymanAdventuresAndroid,

        [GameModeInfo("Rayman Adventures (iOS)", EngineVersion.RaymanAdventures, Platform.iOS)]
        RaymanAdventuresiOS,

        [GameModeInfo("Rayman Mini (Mac)", EngineVersion.RaymanMini, Platform.Mac)]
        RaymanMiniMac,

        [GameModeInfo("Child of Light (PC)", EngineVersion.ChildOfLight, Platform.PC)]
        ChildOfLightPC,

        [GameModeInfo("Child of Light (PS Vita)", EngineVersion.ChildOfLight, Platform.PSVita)]
        ChildOfLightPSVita,

        [GameModeInfo("Valiant Hearts (Android)", EngineVersion.ValiantHearts, Platform.Android)]
        ValiantHeartsAndroid,

        [GameModeInfo("Just Dance 2017 (Wii U)", EngineVersion.JustDance2017, Platform.WiiU)]
        JustDance2017WiiU,

        [GameModeInfo("Gravity Falls (3DS)", EngineVersion.GravityFalls, Platform.Nintendo3DS)]
        GravityFalls3DS,
    }
}