namespace BinarySerializer.UbiArt
{
    /// <summary>
    /// The save file data used for Rayman Fiesta Run
    /// </summary>
    public class FiestaRun_SaveData : BinarySerializable
    {
        public ushort Version { get; set; } // 1-2
        
        public FiestaRun_SaveDataLevel[] LevelInfos_Land1 { get; set; } // Normal levels
        public uint[] LevelTimes { get; set; } // Livid Dead
        
        public uint LumsGlobalCounter { get; set; }
        
        public FiestaRun_ShopItems<ushort> ShopItems_1 { get; set; }
        public FiestaRun_ShopItems<ushort> ShopItems_2 { get; set; }
        public FiestaRun_ShopItems<byte> ShopItems_3 { get; set; }

        public bool IsAllLevelsLocked { get; set; }
        public bool[] Tutorials { get; set; }
        public bool[] TutorialLevelsVisited { get; set; }
        public bool StateCommandeInverser { get; set; } // Invert on-screen buttons

        public bool MustStartIntro { get; set; }
        public byte PersistentGameCountInfos { get; set; }

        public uint Score1 { get; set; } // Max is 29999
        public ushort Score2 { get; set; } // Max is 19
        public ushort Score3 { get; set; } // Max is 215

        public bool RJRSaveRecovered { get; set; } // iOS only
        public ushort LumsCounterFromRJR { get; set; } // iOS only

        public uint GlobalTimerPlay { get; set; }
        public uint GlobalShopTimerPlay { get; set; }
        public uint GlobalLevelsTimerPlay { get; set; }

        public uint HardCurrencySpent { get; set; }
        public uint SoftCurrencySpent { get; set; }

        public uint NbPrimaryStoreVisits { get; set; }
        public uint NbrOfSession { get; set; }
        public uint NbrOfGadgetsBought { get; set; }
        public uint NbrItemBought { get; set; }

        public bool NoelPopUp { get; set; }

        public FiestaRun_SaveDataLevel[] LevelInfos_Land2 { get; set; } // Candy Land
        
        public bool NightMareVisited { get; set; }
        public bool NightMareFinished { get; set; }
        public bool TutoNightMarePopUp { get; set; }
        
        public byte LastPlayedNightMareLevelIdx { get; set; }
        public byte MaxNightMareLevelIdx { get; set; }
        public byte CurrentNightMareLevelIdx { get; set; }
        public byte BestTryNightMareLevelIdx { get; set; }
        
        public bool IsLandSwitcherVisited { get; set; }
        public bool IsShownNewGadgetsRule { get; set; }
        public bool Unknown { get; set; } // byte_A2A9DC
        public bool PhoenixEquipedInNM { get; set; }
        public bool IsPermanentGadgetInfoDisplayed { get; set; }
        public bool IsChineseLanguageSet { get; set; }

        public FiestaRun_ShopItems<ushort> ShopItems_4 { get; set; }

        public byte CurrentCandyIslandIdx { get; set; }
        public bool HairlicoLocked { get; set; }

        public bool iCloudSaveLoadViewed { get; set; }
        public byte NbLvlsPlayedSinceLastUpdate { get; set; }

        public bool[] UnknownFlags { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            Version = s.Serialize<ushort>(Version, name: nameof(Version));
            LevelInfos_Land1 = s.SerializeObjectArray<FiestaRun_SaveDataLevel>(LevelInfos_Land1, 2 * 40, name: nameof(LevelInfos_Land1));
            LevelTimes = s.SerializeArray<uint>(LevelTimes, 4, name: nameof(LevelTimes));
            LumsGlobalCounter = s.Serialize<uint>(LumsGlobalCounter, name: nameof(LumsGlobalCounter));

            // TODO: Old counts don't match with Windows Preload Edition (version 1)
            ShopItems_1 = s.SerializeObject<FiestaRun_ShopItems<ushort>>(ShopItems_1, x =>
            {
                x.Pre_Count = 15;
                x.Pre_HasHeroes = true;
                x.Pre_HasUnknownItems = true;
                x.Pre_OldCount = 12;
                x.Pre_StartIndex = 0;
            }, name: nameof(ShopItems_1));
            ShopItems_2 = s.SerializeObject<FiestaRun_ShopItems<ushort>>(ShopItems_2, x =>
            {
                x.Pre_Count = 12;
                x.Pre_HasHeroes = true;
                x.Pre_HasUnknownItems = true;
                x.Pre_OldCount = 9;
                x.Pre_StartIndex = 0;
            }, name: nameof(ShopItems_2));
            ShopItems_3 = s.SerializeObject<FiestaRun_ShopItems<byte>>(ShopItems_3, x =>
            {
                x.Pre_Count = 8;
                x.Pre_HasHeroes = false;
                x.Pre_HasUnknownItems = true;
                x.Pre_OldCount = 100;
                x.Pre_StartIndex = 0;
            }, name: nameof(ShopItems_3));

            s.DoBits<ushort>(b =>
            {
                IsAllLevelsLocked = b.SerializeBits<bool>(IsAllLevelsLocked, 1, name: nameof(IsAllLevelsLocked));

                Tutorials ??= new bool[5];

                for (int i = 0; i < Tutorials.Length; i++)
                    Tutorials[i] = b.SerializeBits<bool>(Tutorials[i], 1, name: $"{nameof(Tutorials)}[{i}]");

                TutorialLevelsVisited ??= new bool[9];

                for (int i = 0; i < TutorialLevelsVisited.Length; i++)
                    TutorialLevelsVisited[i] = b.SerializeBits<bool>(TutorialLevelsVisited[i], 1, name: $"{nameof(TutorialLevelsVisited)}[{i}]");

                StateCommandeInverser = b.SerializeBits<bool>(StateCommandeInverser, 1, name: nameof(StateCommandeInverser));
            });

            MustStartIntro = s.Serialize<bool>(MustStartIntro, name: nameof(MustStartIntro));
            PersistentGameCountInfos = s.Serialize<byte>(PersistentGameCountInfos, name: nameof(PersistentGameCountInfos));

            Score1 = s.Serialize<uint>(Score1, name: nameof(Score1));
            Score2 = s.Serialize<ushort>(Score2, name: nameof(Score2));
            Score3 = s.Serialize<ushort>(Score3, name: nameof(Score3));

            RJRSaveRecovered = s.Serialize<bool>(RJRSaveRecovered, name: nameof(RJRSaveRecovered));
            LumsCounterFromRJR = s.Serialize<ushort>(LumsCounterFromRJR, name: nameof(LumsCounterFromRJR));

            GlobalTimerPlay = s.Serialize<uint>(GlobalTimerPlay, name: nameof(GlobalTimerPlay));
            GlobalShopTimerPlay = s.Serialize<uint>(GlobalShopTimerPlay, name: nameof(GlobalShopTimerPlay));
            GlobalLevelsTimerPlay = s.Serialize<uint>(GlobalLevelsTimerPlay, name: nameof(GlobalLevelsTimerPlay));

            HardCurrencySpent = s.Serialize<uint>(HardCurrencySpent, name: nameof(HardCurrencySpent));
            SoftCurrencySpent = s.Serialize<uint>(SoftCurrencySpent, name: nameof(SoftCurrencySpent));

            NbPrimaryStoreVisits = s.Serialize<uint>(NbPrimaryStoreVisits, name: nameof(NbPrimaryStoreVisits));
            NbrOfSession = s.Serialize<uint>(NbrOfSession, name: nameof(NbrOfSession));
            NbrOfGadgetsBought = s.Serialize<uint>(NbrOfGadgetsBought, name: nameof(NbrOfGadgetsBought));
            NbrItemBought = s.Serialize<uint>(NbrItemBought, name: nameof(NbrItemBought));

            if (s.Serialize<byte>(172, name: "SaveCheck") != 172)
                throw new BinarySerializableException(this, "Save check value is invalid");

            NoelPopUp = s.Serialize<bool>(NoelPopUp, name: nameof(NoelPopUp));

            if (Version >= 2)
            {
                LevelInfos_Land2 = s.SerializeObjectArray<FiestaRun_SaveDataLevel>(LevelInfos_Land2, 2 * 40, name: nameof(LevelInfos_Land2));

                NightMareVisited = s.Serialize<bool>(NightMareVisited, name: nameof(NightMareVisited));
                NightMareFinished = s.Serialize<bool>(NightMareFinished, name: nameof(NightMareFinished));
                TutoNightMarePopUp = s.Serialize<bool>(TutoNightMarePopUp, name: nameof(TutoNightMarePopUp));
                LastPlayedNightMareLevelIdx = s.Serialize<byte>(LastPlayedNightMareLevelIdx, name: nameof(LastPlayedNightMareLevelIdx));
                MaxNightMareLevelIdx = s.Serialize<byte>(MaxNightMareLevelIdx, name: nameof(MaxNightMareLevelIdx));
                CurrentNightMareLevelIdx = s.Serialize<byte>(CurrentNightMareLevelIdx, name: nameof(CurrentNightMareLevelIdx));
                BestTryNightMareLevelIdx = s.Serialize<byte>(BestTryNightMareLevelIdx, name: nameof(BestTryNightMareLevelIdx));

                s.DoBits<byte>(b =>
                {
                    IsLandSwitcherVisited = b.SerializeBits<bool>(IsLandSwitcherVisited, 1, name: nameof(IsLandSwitcherVisited));
                    IsShownNewGadgetsRule = b.SerializeBits<bool>(IsShownNewGadgetsRule, 1, name: nameof(IsShownNewGadgetsRule));
                    Unknown = b.SerializeBits<bool>(Unknown, 1, name: nameof(Unknown));
                    PhoenixEquipedInNM = b.SerializeBits<bool>(PhoenixEquipedInNM, 1, name: nameof(PhoenixEquipedInNM));
                    IsPermanentGadgetInfoDisplayed = b.SerializeBits<bool>(IsPermanentGadgetInfoDisplayed, 1, name: nameof(IsPermanentGadgetInfoDisplayed));
                    IsChineseLanguageSet = b.SerializeBits<bool>(IsChineseLanguageSet, 1, name: nameof(IsChineseLanguageSet));
                });

                ShopItems_4 = s.SerializeObject<FiestaRun_ShopItems<ushort>>(ShopItems_4, x =>
                {
                    x.Pre_Count = 16;
                    x.Pre_HasHeroes = true;
                    x.Pre_HasUnknownItems = true;
                    x.Pre_OldCount = 100;
                    x.Pre_StartIndex = 12;
                }, name: nameof(ShopItems_4));

                CurrentCandyIslandIdx = s.Serialize<byte>(CurrentCandyIslandIdx, name: nameof(CurrentCandyIslandIdx));
                HairlicoLocked = s.Serialize<bool>(HairlicoLocked, name: nameof(HairlicoLocked));

                s.DoBits<byte>(b =>
                {
                    iCloudSaveLoadViewed = b.SerializeBits<bool>(iCloudSaveLoadViewed, 1, name: nameof(iCloudSaveLoadViewed));
                    NbLvlsPlayedSinceLastUpdate = b.SerializeBits<byte>(NbLvlsPlayedSinceLastUpdate, 4, name: nameof(NbLvlsPlayedSinceLastUpdate));
                });
                
                s.DoBits<long>(b =>
                {
                    UnknownFlags ??= new bool[2 * 6];

                    for (int i = 0; i < UnknownFlags.Length; i++)
                        UnknownFlags[i] = b.SerializeBits<bool>(UnknownFlags[i], 1, name: $"{nameof(UnknownFlags)}[{i}]");
                });
            }
        }
    }
}