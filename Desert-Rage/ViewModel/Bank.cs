using System.Collections.Generic;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.Resources.Media.OST.Noises.Actions;
using DesertRage.Resources.Media.OST.Noises.Actions.Items;
using DesertRage.ViewModel.Battle.Components.Actions;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds.Dependent;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds.Independent;
using DesertRage.Resources.Media.Images.Menu.Skills;
using DesertRage.Resources.Media.Images.Menu.Items;
using System;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.ViewModel.Battle.Components.Strategy.Fight;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds.Independent.Status;
using System.IO;

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
                                Icon = Skills.Cure,
                                Noise = ActionNoises.Cure
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
                                Icon = Skills.Cure2,
                                Noise = ActionNoises.Cure2
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
                                Icon = Skills.Heal,
                                Noise = ActionNoises.Heal
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
                                Icon = Skills.Analyze,
                                Noise = ActionNoises.Scan
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
                                Icon = Skills.AttackUp,
                                Noise = ActionNoises.PowerBoost
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
                                Icon = Skills.DefenceUp,
                                Noise = ActionNoises.DefenceBoost
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
                                Icon = Skills.Torch,
                                Noise = ActionNoises.Torch
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
                                Icon = Skills.Whip,
                                Noise = ActionNoises.Whip
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
                                Icon = Skills.Slingshot,
                                Noise = ActionNoises.Sling
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
                                Icon = Skills.Combo,
                                Noise = ActionNoises.Combo
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
                                Icon = Skills.Storm,
                                Noise = ActionNoises.Wind
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
                                Icon = Skills.Slide,
                                Noise = ActionNoises.Quake
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
                        new NoiseUnit(50, "ОЗ")
                        {
                            Name = "Бинт",
                            Icon = Items.Bandage,
                            Noise = ActionNoises.Cure
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
                            Icon = Items.Antidote,
                            Noise = ActionNoises.Heal
                        }
                    ),
                    new ItemCommand(ItemsID.Antidote)
                ),

                new ConsumeCommand(
                    new RestCommand(
                        new ItemFormula(50),
                        new NoiseUnit(50, "ОД")
                        {
                            Name = "Эфир",
                            Icon = Items.Ether,
                            Noise = ActionNoises.Control
                        }
                    ),
                    new ItemCommand(ItemsID.Ether)
                ),

                new ConsumeCommand(
                    new RecoverCommand(
                        new ItemFormula(80),
                        new NoiseUnit(80, "ОЗ-ОД")
                        {
                            Name = "Смесь",
                            Icon = Items.Mixture,
                            Noise = ItemNoises.Mixture
                        }
                    ),
                    new ItemCommand(ItemsID.Mixture)
                ),

                new ConsumeCommand(
                    new CureCommand(
                        new ItemFormula(350),
                        new NoiseUnit(350, "ОЗ")
                        {
                            Name = "Травы",
                            Icon = Items.Herbs,
                            Noise = ActionNoises.Cure
                        }
                    ),
                    new ItemCommand(ItemsID.Herbs)
                ),

                new ConsumeCommand(
                    new RestCommand(
                        new ItemFormula(300),
                        new NoiseUnit(300, "ОД")
                        {
                            Name = "Бутыль эфира",
                            Icon = Items.EtherBottle,
                            Noise = ActionNoises.Control
                        }
                    ),
                    new ItemCommand(ItemsID.EtherBottle)
                ),

                new ConsumeCommand(
                    new RecoverMaxCommand(
                        new NoiseUnit("100% ОЗ-ОД")
                        {
                            Name = "Эликсир",
                            Icon = Items.Elixir,
                            Noise = ItemNoises.Mixture
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