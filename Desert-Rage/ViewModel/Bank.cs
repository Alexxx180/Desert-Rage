using System.Collections.Generic;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Menu.Things.Logic;
using System;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Stats.Player;
using System.IO;
using DesertRage.ViewModel.User.Battle.Components.Strategy.Fight;
using DesertRage.ViewModel.User.Battle.Components.Actions;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Dependent;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent.Status;
using DesertRage.ViewModel.User.Battle.Components.Actions.Kinds.Independent;
using DesertRage.Model.Locations.Battle;

namespace DesertRage.ViewModel
{
    internal static class Bank
    {
        internal const string DataDirectory = "/Resources/Media/Data";

        internal static void MakeProfile(string name)
        {
            string full = $"{DataDirectory}/Profiles/{name}".ToFull();
            Directory.CreateDirectory(full);
        }

        internal static void DropProfile(string name)
        {
            string full = $"{DataDirectory}/Profiles/{name}".ToFull();
            Directory.Delete(full, true);
        }

        #region Get Data Members
        private static T GetData<T>(string path)
        {
            string full = path.ToFull();
            return File.Exists(full) ?
                App.Processor.Read<T>(full) :
                default;
        }

        private static T GetItems<T>(string path)
        {
            return GetData<T>($"{DataDirectory}/{path}");
        }

        #region Prefab Members
        internal static string[] LoadTips()
        {
            return GetItems<string[]>($"Items/Help.json");
        }

        internal static Settings LoadPreferences()
        {
            return GetItems<Settings>($"Items/Preferences.json");
        }

        internal static Character LoadHero(string name)
        {
            return GetItems<Character>($"Characters/{name}/Beginner.json");
        }

        internal static Location LoadLevel(string name)
        {
            return GetItems<Location>($"Map/{name}.json");
        }

        internal static NextStats GetNextStats(string name)
        {
            return GetItems<NextStats>($"Characters/{name}/Next.json");
        }

        internal static Equipment[][] GetEqupment()
        {
            return GetItems<Equipment[][]>("Items/Equipment.json");
        }

        internal static Foe[] Foes()
        {
            return GetItems<Foe[]>("Opponents/Foes.json");
        }

        internal static Boss[] Bosses()
        {
            return GetItems<Boss[]>("Opponents/Bosses.json");
        }
        #endregion

        #region Profile Members
        private static T GetProfileItems<T>(string name)
        {
            return GetItems<T>($"Profiles/{name}.json");
        }

        internal static Character LoadProfileHero(string name)
        {
            return GetProfileItems<Character>($"{name}/Hero");
        }

        internal static Location LoadProfileLevel(string name)
        {
            return GetProfileItems<Location>($"{name}/Level");
        }

        internal static Settings LoadProfilePreferences(string name)
        {
            return GetProfileItems<Settings>($"{name}/Preferences");
        }
        #endregion
        
        #endregion

        #region Set Data Members
        private static void SetData<T>(string path, T data)
        {
            string full = path.ToFull();
            System.Diagnostics.Trace.WriteLine(full);
            App.Processor.Write(full, data);
        }

        private static void SetItems<T>(string path, T items)
        {
            SetData($"{DataDirectory}/{path}.json", items);
        }

        #region Prefab Members
        internal static void SavePreferences(Settings preferences)
        {
            SetItems($"Items/Preferences", preferences);
        }
        #endregion

        #region Profile Members
        private static void
            SetProfileItems<T>(string name, T profileItems)
        {
            SetItems($"Profiles/{name}", profileItems);
        }

        internal static void
            SaveProfileHero(string name, Character hero)
        {
            SetProfileItems($"{name}/Hero", hero);
        }

        internal static void
            SaveProfileLevel(string name, Location level)
        {
            SetProfileItems($"{name}/Level", level);
        }

        internal static void
            SaveProfilePreferences(string name, Settings preferences)
        {
            SetProfileItems($"{name}/Preferences", preferences);
        }
        #endregion

        #endregion

        internal static IParticipantFight[] Fights()
        {
            return new IParticipantFight[]
            {
                new Attack(),
                new Poison(new Position(8, 1))
            };
        }

        internal static Dictionary<SkillsID, ConsumeCommand> AllSkills()
        {
            return new Dictionary<SkillsID, ConsumeCommand>
            {
                {
                    SkillsID.Cure,
                    new ConsumeCommand(
                        new CureCommand(
                            new SpecialFormula(1.8f),
                            new NoiseUnit
                            {
                                Name = "Лечение",
                                Description = "+ ОЗ",
                                Icon = "/Resources/Media/Images/Menu/Skills/Cure.svg",
                                Noise = "Actions/Cure.mp3"
                            }
                        ),
                        new SkillCommand(5)
                    )
                },

                {
                    SkillsID.Cure2,
                    new ConsumeCommand(
                        new CureMaxCommand(
                            new NoiseUnit
                            {
                                Name = "Лечение 2",
                                Description = "100% ОЗ",
                                Icon = "/Resources/Media/Images/Menu/Skills/Cure2.svg",
                                Noise = "Actions/Cure2.mp3"
                            }
                        ),
                        new SkillCommand(10)
                    )
                },

                {
                    SkillsID.Antidote,
                    new ConsumeCommand(
                        new RemoveStatus(
                            StatusID.POISON,
                            new NoiseUnit
                            {
                                Name = "Антидот",
                                Description = "- Яд",
                                Icon = "/Resources/Media/Images/Menu/Skills/Heal.svg",
                                Noise = "Actions/Heal.mp3"
                            }
                        ),
                        new SkillCommand(3)
                    )
                },

                {
                    SkillsID.Learn,
                    new ConsumeCommand(
                        new LearnCommand(
                            new NoiseUnit
                            {
                                Name = "Анализ",
                                Description = "Изучить врага как следует",
                                Icon = "/Resources/Media/Images/Menu/Skills/Analyze.svg",
                                Noise = "Actions/Scan.mp3"
                            }
                        ),
                        new SkillCommand(0)
                    )
                },

                {
                    SkillsID.BuffUp,
                    new ConsumeCommand(
                        new ApplyStatus(
                            StatusID.REINFORCEMENT,
                            new NoiseUnit
                            {
                                Name = "Усиление",
                                Description = "Сконцентрировать всю силу",
                                Icon = "/Resources/Media/Images/Menu/Skills/AttackUp.svg",
                                Noise = "Actions/PowerBoost.mp3"
                            }
                        ),
                        new SkillCommand(20)
                    )
                },

                {
                    SkillsID.Shield,
                    new ConsumeCommand(
                        new ApplyStatus(
                            StatusID.SHIELD,
                            new NoiseUnit
                            {
                                Name = "Охрана",
                                Description = "Повысить бдительность",
                                Icon = "/Resources/Media/Images/Menu/Skills/DefenceUp.svg",
                                Noise = "Actions/DefenceBoost.mp3"
                            }
                        ),
                        new SkillCommand(15)
                    )
                },

                {
                    SkillsID.Torch,
                    new ConsumeCommand(
                        new FightCommand(
                            new SpecialFormula(2f),
                            new NoiseUnit
                            {
                                Name = "Факел",
                                Description = "Хорошо поджигает",
                                Icon = "/Resources/Media/Images/Menu/Skills/Torch.svg",
                                Noise = "Actions/Torch.mp3"
                            }
                        ),
                        new SkillCommand(5)
                    )
                },

                {
                    SkillsID.Whip,
                    new ConsumeCommand(
                        new FightCommand(
                            new SpecialFormula(3.5f),
                            new NoiseUnit
                            {
                                Name = "Кнут",
                                Description = "Дробит кости",
                                Icon = "/Resources/Media/Images/Menu/Skills/Whip.svg",
                                Noise = "Actions/Whip.mp3"
                            }
                        ),
                        new SkillCommand(7)
                    )
                },

                {
                    SkillsID.Sling,
                    new ConsumeCommand(
                        new FightCommand(
                            new SpecialFormula(5f),
                            new NoiseUnit
                            {
                                Name = "Рогатка",
                                Description = "От нее не скрыться",
                                Icon = "/Resources/Media/Images/Menu/Skills/Slingshot.svg",
                                Noise = "Actions/Sling.mp3"
                            }
                        ),
                        new SkillCommand(13)
                    )
                },

                {
                    SkillsID.Combo,
                    new ConsumeCommand(
                        new FightAllCommand(
                            new SpecialFormula(3f),
                            new NoiseUnit
                            {
                                Name = "Комбо",
                                Description = "Град ударов по врагам",
                                Icon = "/Resources/Media/Images/Menu/Skills/Combo.svg",
                                Noise = "Actions/Combo.mp3"
                            }
                        ),
                        new SkillCommand(10)
                    )
                },

                {
                    SkillsID.Whirl,
                    new ConsumeCommand(
                        new FightAllCommand(
                            new SpecialFormula(4f),
                            new NoiseUnit
                            {
                                Name = "Буря",
                                Description = "Неистовый порыв ветра",
                                Icon = "/Resources/Media/Images/Menu/Skills/Storm.svg",
                                Noise = "Actions/Wind.mp3"
                            }
                        ),
                        new SkillCommand(18)
                    )
                },

                {
                    SkillsID.Quake,
                    new ConsumeCommand(
                        new FightAllCommand(
                            new SpecialFormula(5f),
                            new NoiseUnit
                            {
                                Name = "Обвал",
                                Description = "Усыпать противников камнями",
                                Icon = "/Resources/Media/Images/Menu/Skills/Slide.svg",
                                Noise = "Actions/Quake.mp3"
                            }
                        ),
                        new SkillCommand(25)
                    )
                },
            };
        }

        internal static List<ConsumeCommand> AllItems()
        {
            return new List<ConsumeCommand>()
            {
                new ConsumeCommand(
                    new CureCommand(
                        new ItemFormula(50),
                        new NoiseUnit()
                        {
                            Name = "Бинт",
                            Description = "+50 ОЗ",
                            Icon = "/Resources/Media/Images/Menu/Items/Bandage.svg",
                            Noise = "Actions/Cure.mp3"
                        }
                    ),
                    new ItemCommand(ItemsID.Bandage)
                ),

                new ConsumeCommand(
                    new RemoveStatus(
                        StatusID.POISON,
                        new NoiseUnit
                        {
                            Name = "Антидот",
                            Description = "- Яд",
                            Icon = "/Resources/Media/Images/Menu/Items/Antidote.svg",
                            Noise = "Actions/Heal.mp3"
                        }
                    ),
                    new ItemCommand(ItemsID.Antidote)
                ),

                new ConsumeCommand(
                    new RestCommand(
                        new ItemFormula(50),
                        new NoiseUnit()
                        {
                            Name = "Эфир",
                            Description = "50 ОД",
                            Icon = "/Resources/Media/Images/Menu/Items/Ether.svg",
                            Noise = "Actions/Control.mp3"
                        }
                    ),
                    new ItemCommand(ItemsID.Ether)
                ),

                new ConsumeCommand(
                    new RecoverCommand(
                        new ItemFormula(80),
                        new NoiseUnit()
                        {
                            Name = "Смесь",
                            Description = "+80 ОЗ-ОД",
                            Icon = "/Resources/Media/Images/Menu/Items/Mixture.svg",
                            Noise = "Actions/Items/Mixture.mp3"
                        }
                    ),
                    new ItemCommand(ItemsID.Mixture)
                ),

                new ConsumeCommand(
                    new CureCommand(
                        new ItemFormula(350),
                        new NoiseUnit()
                        {
                            Name = "Травы",
                            Description = "+350 ОЗ",
                            Icon = "/Resources/Media/Images/Menu/Items/Herbs.svg",
                            Noise = "Actions/Cure.mp3"
                        }
                    ),
                    new ItemCommand(ItemsID.Herbs)
                ),

                new ConsumeCommand(
                    new RestCommand(
                        new ItemFormula(300),
                        new NoiseUnit()
                        {
                            Name = "Бутыль эфира",
                            Description = "+300 ОД",
                            Icon = "/Resources/Media/Images/Menu/Items/EtherBottle.svg",
                            Noise = "Actions/Control.mp3"
                        }
                    ),
                    new ItemCommand(ItemsID.EtherBottle)
                ),

                new ConsumeCommand(
                    new RecoverMaxCommand(
                        new NoiseUnit()
                        {
                            Name = "Эликсир",
                            Description = "100% ОЗ-ОД",
                            Icon = "/Resources/Media/Images/Menu/Items/Elixir.svg",
                            Noise = "Actions/Items/Mixture.mp3"
                        }
                    ),
                    new ItemCommand(ItemsID.Elixir)
                )
            };
        }

        public static string ToFull(this string path)
        {
            return Environment.CurrentDirectory + path;
        }

        public static void ForEach<T, TParam>
            (this IEnumerable<T> collection, in
            Action<T, TParam> method, TParam parameter)
        {
            foreach (T @object in collection)
            {
                method(@object, parameter);
            }
        }
    }
}