namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// The available game modes
    /// </summary>
    public enum GameMode
    {
        [GameModeInfo("Rayman Origins (PC)", Game.RaymanOrigins, Platform.PC)]
        RaymanOriginsPC,

        [GameModeInfo("Rayman Origins (PS3)", Game.RaymanOrigins, Platform.PlayStation3)]
        RaymanOriginsPS3,

        [GameModeInfo("Rayman Origins (Xbox 360)", Game.RaymanOrigins, Platform.Xbox360)]
        RaymanOriginsXbox360,

        [GameModeInfo("Rayman Origins (Wii)", Game.RaymanOrigins, Platform.Wii)]
        RaymanOriginsWii,

        [GameModeInfo("Rayman Origins (PS Vita)", Game.RaymanOrigins, Platform.PSVita)]
        RaymanOriginsPSVita,

        [GameModeInfo("Rayman Origins (3DS)", Game.RaymanOrigins, Platform.Nintendo3DS)]
        RaymanOrigins3DS,

        [GameModeInfo("Rayman Jungle Run (PC)", Game.RaymanJungleRun, Platform.PC)]
        RaymanJungleRunPC,

        [GameModeInfo("Rayman Jungle Run (Android)", Game.RaymanJungleRun, Platform.Android)]
        RaymanJungleRunAndroid,

        [GameModeInfo("Rayman Legends (PC)", Game.RaymanLegends, Platform.PC)]
        RaymanLegendsPC,

        [GameModeInfo("Rayman Legends (Xbox 360)", Game.RaymanLegends, Platform.Xbox360)]
        RaymanLegendsXbox360,

        [GameModeInfo("Rayman Legends (Wii U)", Game.RaymanLegends, Platform.WiiU)]
        RaymanLegendsWiiU,

        [GameModeInfo("Rayman Legends (PS Vita)", Game.RaymanLegends, Platform.PSVita)]
        RaymanLegendsPSVita,

        [GameModeInfo("Rayman Legends (PS4)", Game.RaymanLegends, Platform.PlayStation4)]
        RaymanLegendsPS4,

        [GameModeInfo("Rayman Legends (Switch)", Game.RaymanLegends, Platform.NintendoSwitch)]
        RaymanLegendsSwitch,

        [GameModeInfo("Rayman Fiesta Run (PC)", Game.RaymanFiestaRun, Platform.PC)]
        RaymanFiestaRunPC,

        [GameModeInfo("Rayman Fiesta Run (Android)", Game.RaymanJungleRun, Platform.Android)]
        RaymanFiestaRunAndroid,

        [GameModeInfo("Rayman Adventures (Android)", Game.RaymanAdventures, Platform.Android)]
        RaymanAdventuresAndroid,

        [GameModeInfo("Rayman Adventures (iOS)", Game.RaymanAdventures, Platform.iOS)]
        RaymanAdventuresiOS,

        [GameModeInfo("Rayman Mini (Mac)", Game.RaymanMini, Platform.Mac)]
        RaymanMiniMac,

        [GameModeInfo("Child of Light (PC)", Game.ChildOfLight, Platform.PC)]
        ChildOfLightPC,

        [GameModeInfo("Child of Light (PS Vita)", Game.ChildOfLight, Platform.PSVita)]
        ChildOfLightPSVita,

        [GameModeInfo("Valiant Hearts (Android)", Game.ValiantHearts, Platform.Android)]
        ValiantHeartsAndroid,

        [GameModeInfo("Just Dance 2017 (Wii U)", Game.JustDance2017, Platform.WiiU)]
        JustDance2017WiiU,

        [GameModeInfo("Gravity Falls (3DS)", Game.GravityFalls, Platform.Nintendo3DS)]
        GravityFalls3DS,
    }
}