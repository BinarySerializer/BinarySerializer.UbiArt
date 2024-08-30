namespace BinarySerializer.UbiArt
{
    public class GameManagerConfig_Template : BinarySerializable
    {
        public Path[] debugMenuMapList;
        public Path gameTextFilePath;
        public Path loading;
        public Generic<PlayerIDInfo>[] playerIDInfo;
        public PlayerIDInfo[] playerIDInfoRO;
        public String8[] familyList;
        public Path cameraShakeConfig;
        public float cutSceneDefaultUnskippableDurationFirstTime;
        public uint maxLocalPlayers;
        public uint maxOnlinePlayers;
        public string DRCPlayerFamilyName;
        public uint maxBonusTeensy;
        public TeaKey key;
        public Color textHighlightColor;
        public String16[] debugMenuMapListRO;
        public String16[] mapListPressConf;
        public String16[] menus;
        public Path[] luaIncludes;
        public Path[] inputs;
        public MusicTheme[] musicThemes;
        public Path baseMap;
        public Path game2dWorld;
        public String16 gameTextFilePathOrigins;
        public Path mainMenuBackMap;
        public Path mainMenuBackMapForDebugSaves;
        public Path worldMap;
        public Path splash1Map;
        public Path levelEndedMap;
        public Path menuSoundMap;
        public int usePressConfMenu;
        public float TEMP_threshold;
        public int TEMP_useshake;
        public float TEMP_delay;
        public int TEMP_runUseB;
        public int TEMP_runUseShake;
        public float TEMP_swimMaxSpeed;
        public float TEMP_swimSmooth;
        public float TEMP_runTimerStop;
        public Path iconsButtonPath;
        public Path gpeIconsPath;

        public override void SerializeImpl(SerializerObject s)
        {
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

            if (settings.Game == Game.RaymanOrigins)
            {
                debugMenuMapListRO = s.SerializeUbiArtObjectArray<String16>(debugMenuMapListRO, name: "debugMenuMapList");
                mapListPressConf = s.SerializeUbiArtObjectArray<String16>(mapListPressConf, name: "mapListPressConf");
                menus = s.SerializeUbiArtObjectArray<String16>(menus, name: "menus");
                luaIncludes = s.SerializeUbiArtObjectArray<Path>(luaIncludes, name: "luaIncludes");
                inputs = s.SerializeUbiArtObjectArray<Path>(inputs, name: "inputs");
                musicThemes = s.SerializeUbiArtObjectArray<MusicTheme>(musicThemes, name: "musicThemes");
                baseMap = s.SerializeObject<Path>(baseMap, name: "baseMap");
                game2dWorld = s.SerializeObject<Path>(game2dWorld, name: "game2dWorld");
                gameTextFilePathOrigins = s.SerializeObject<String16>(gameTextFilePathOrigins, name: "gameTextFilePath");
                mainMenuBackMap = s.SerializeObject<Path>(mainMenuBackMap, name: "mainMenuBackMap");
                mainMenuBackMapForDebugSaves = s.SerializeObject<Path>(mainMenuBackMapForDebugSaves, name: "mainMenuBackMapForDebugSaves");
                worldMap = s.SerializeObject<Path>(worldMap, name: "worldMap");
                splash1Map = s.SerializeObject<Path>(splash1Map, name: "splash1Map");
                levelEndedMap = s.SerializeObject<Path>(levelEndedMap, name: "levelEndedMap");
                menuSoundMap = s.SerializeObject<Path>(menuSoundMap, name: "menuSoundMap");
                loading = s.SerializeObject<Path>(loading, name: "loading");
                usePressConfMenu = s.Serialize<int>(usePressConfMenu, name: "usePressConfMenu");
                playerIDInfoRO = s.SerializeUbiArtObjectArray<PlayerIDInfo>(playerIDInfoRO, name: "playerIDInfo");
                familyList = s.SerializeUbiArtObjectArray<String8>(familyList, name: "familyList");
                cameraShakeConfig = s.SerializeObject<Path>(cameraShakeConfig, name: "cameraShakeConfig");
                cutSceneDefaultUnskippableDurationFirstTime = s.Serialize<float>(cutSceneDefaultUnskippableDurationFirstTime, name: "cutSceneDefaultUnskippableDurationFirstTime");
                TEMP_threshold = s.Serialize<float>(TEMP_threshold, name: "TEMP_threshold");
                TEMP_useshake = s.Serialize<int>(TEMP_useshake, name: "TEMP_useshake");
                TEMP_delay = s.Serialize<float>(TEMP_delay, name: "TEMP_delay");
                TEMP_runUseB = s.Serialize<int>(TEMP_runUseB, name: "TEMP_runUseB");
                TEMP_runUseShake = s.Serialize<int>(TEMP_runUseShake, name: "TEMP_runUseShake");
                TEMP_swimMaxSpeed = s.Serialize<float>(TEMP_swimMaxSpeed, name: "TEMP_swimMaxSpeed");
                TEMP_swimSmooth = s.Serialize<float>(TEMP_swimSmooth, name: "TEMP_swimSmooth");
                TEMP_runTimerStop = s.Serialize<float>(TEMP_runTimerStop, name: "TEMP_runTimerStop");
                iconsButtonPath = s.SerializeObject<Path>(iconsButtonPath, name: "iconsButtonPath");
                gpeIconsPath = s.SerializeObject<Path>(gpeIconsPath, name: "gpeIconsPath");
            }
        }
    }

    public class MusicTheme : BinarySerializable
    {
        public StringID theme;
        public string path;

        public override void SerializeImpl(SerializerObject s)
        {
            theme = s.SerializeObject<StringID>(theme, name: "theme");
            path = s.SerializeObject<String16>(path, name: "path");
        }
    }

    public class PlayerIDInfo : BinarySerializable
    {
        public string id;
        public string family;
        public uint lineIdName;
        public uint lineIdDescription;
        public uint costumeIconAnimationId;
        public GameScreenInfo[] gameScreens;
        public GameScreenInfo defaultGameScreenInfo;
        public ActorInfo actorInfo;
        public Color deathBubbleColor = Color.White;

        public override void SerializeImpl(SerializerObject s)
        {
            UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

            if (settings.Game == Game.RaymanOrigins)
            {
                id = s.SerializeObject<String8>(id, name: "id");
                family = s.SerializeObject<String8>(family, name: "family");
                deathBubbleColor = s.SerializeObject<Color>(deathBubbleColor, name: "deathBubbleColor");
                gameScreens = s.SerializeUbiArtObjectArray<GameScreenInfo>(gameScreens, name: "gameScreens");
            }
            else if (settings.Game == Game.RaymanLegends)
            {
                id = s.SerializeObject<String8>(id, name: "id");
                family = s.SerializeObject<String8>(family, name: "family");
                gameScreens = s.SerializeUbiArtObjectArray<GameScreenInfo>(gameScreens, name: "gameScreens");
                defaultGameScreenInfo = s.SerializeObject<PlayerIDInfo.GameScreenInfo>(defaultGameScreenInfo, name: "defaultGameScreenInfo");
            }
            else if (settings.Game == Game.ChildOfLight)
            {
            }
            else if (settings.Game == Game.ValiantHearts)
            {
                actorInfo = s.SerializeObject<PlayerIDInfo.ActorInfo>(actorInfo, name: "actorInfo");
                id = s.SerializeObject<String8>(id, name: "id");
                family = s.SerializeObject<String8>(family, name: "family");
                gameScreens = s.SerializeUbiArtObjectArray<GameScreenInfo>(gameScreens, name: "gameScreens");
                defaultGameScreenInfo = s.SerializeObject<PlayerIDInfo.GameScreenInfo>(defaultGameScreenInfo, name: "defaultGameScreenInfo");
            }
            else
            {
                actorInfo = s.SerializeObject<PlayerIDInfo.ActorInfo>(actorInfo, name: "actorInfo");
                id = s.SerializeObject<String8>(id, name: "id");
                family = s.SerializeObject<String8>(family, name: "family");
                lineIdName = s.Serialize<uint>(lineIdName, name: "lineIdName");
                lineIdDescription = s.Serialize<uint>(lineIdDescription, name: "lineIdDescription");
                costumeIconAnimationId = s.Serialize<uint>(costumeIconAnimationId, name: "costumeIconAnimationId");
                gameScreens = s.SerializeUbiArtObjectArray<GameScreenInfo>(gameScreens, name: "gameScreens");
                defaultGameScreenInfo = s.SerializeObject<PlayerIDInfo.GameScreenInfo>(defaultGameScreenInfo, name: "defaultGameScreenInfo");
            }
        }

        public class ActorInfo : BinarySerializable
        {
            public Path file;
            public bool isAlwaysActive;
            public bool isPlayable;
            public uint[] gameModes;
            public bool isDynamicallyLoaded;
            public uint mainGameMode = uint.MaxValue;

            public override void SerializeImpl(SerializerObject s)
            {
                UbiArtSettings settings = s.GetRequiredSettings<UbiArtSettings>();

                file = s.SerializeObject<Path>(file, name: "file");
                isAlwaysActive = s.SerializeUbiArtBool(isAlwaysActive, name: "isAlwaysActive");
                isPlayable = s.SerializeUbiArtBool(isPlayable, name: "isPlayable");
                gameModes = s.SerializeUbiArtArray<uint>(gameModes, name: "gameModes");
                
                if (settings.Game != Game.RaymanOrigins)
                {
                    isDynamicallyLoaded = s.SerializeUbiArtBool(isDynamicallyLoaded, name: "isDynamicallyLoaded");
                    mainGameMode = s.Serialize<uint>(mainGameMode, name: "mainGameMode");
                }
            }
        }

        public partial class GameScreenInfo : BinarySerializable
        {
            public StringID gameScreen;
            public ActorInfo[] actors;

            public override void SerializeImpl(SerializerObject s)
            {
                gameScreen = s.SerializeObject<StringID>(gameScreen, name: "gameScreen");
                actors = s.SerializeUbiArtObjectArray<ActorInfo>(actors, name: "actors");
            }
        }
    }

    public class Color : BinarySerializable
    {
        public float b;
        public float g;
        public float r;
        public float a;

        public Color()
        {
        }
        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public override void SerializeImpl(SerializerObject s)
        {
            b = s.Serialize<float>(b);
            g = s.Serialize<float>(g);
            r = s.Serialize<float>(r);
            a = s.Serialize<float>(a);
        }

        public Color Alpha(float alpha) => new Color(r, g, b, alpha);

        public static Color Black => new Color(0, 0, 0, 1f);
        public static Color White => new Color(1, 1, 1, 1f);
        public static Color Red => new Color(1, 0, 0, 1f);
        public static Color Green => new Color(0, 1, 0, 1f);
        public static Color Blue => new Color(0, 0, 1, 1f);
        public static Color Grey => new Color(0.5f, 0.5f, 0.5f, 1f);
        public static Color Zero => new Color(0, 0, 0, 0);
        public static Color operator *(Color a, float b) => new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        public static Color operator *(Color a, Color b) => new Color(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);

        public override string ToString()
        {
            return $"Color({r}, {g}, {b}, {a})";
        }
    }

    public partial class TeaKey : BinarySerializable
    {
        public uint Key1;
        public uint Key2;
        public uint Key3;
        public uint Key4;

        public override void SerializeImpl(SerializerObject s)
        {
            Key1 = s.Serialize<uint>(Key1, name: "Key1");
            Key2 = s.Serialize<uint>(Key2, name: "Key2");
            Key3 = s.Serialize<uint>(Key3, name: "Key3");
            Key4 = s.Serialize<uint>(Key4, name: "Key4");
        }
    }
}