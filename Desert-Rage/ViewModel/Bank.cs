using System.Collections.Generic;
using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Model.Menu.Things.Logic;
using DesertRage.Resources.Media.OST.Noises.Actions;
using DesertRage.Resources.Media.OST.Noises.Actions.Items;
using DesertRage.ViewModel.Battle.Components.Actions;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds.Dependent;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds.Independent;
using DesertRage.Resources.Media.OST.Sounds.Defeat.Enemies;
using DesertRage.Resources.Media.OST.Sounds.Defeat.Bosses;
using DesertRage.Resources.Media.Images.Menu.Skills;
using DesertRage.Resources.Media.Images.Menu.Items;
using EnemyImages = DesertRage.Resources.Media.Images.Battle.Enemies;
using BossImages = DesertRage.Resources.Media.Images.Battle.Bosses;
using System;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.ViewModel.Battle.Components.Strategy.Fight;
using DesertRage.Model.Locations.Battle;
using DesertRage.ViewModel.Battle.Components.Actions.Kinds.Independent.Status;

namespace DesertRage.ViewModel
{
    internal static class Bank
    {
        static Bank()
        {
            FoeEnumeration = Foes();
        }

        public static Foe[] FoeEnumeration { get; set; }


        private static T GetData<T>(string path)
        {
            return App.Processor.Read<T>(path.ToFull());
        }

        private static T GetItems<T>(string path)
        {
            return GetData<T>($"/Resources/Media/Data/{path}");
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

        internal static Foe[] AllBosses()
        {
            return GetItems<Foe[]>("Opponents/Bosses.json");
        }

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
                    new ItemCommand(2)
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
                    new ItemCommand(2)
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
                    new ItemCommand(2)
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
                    new ItemCommand(2)
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
                    new ItemCommand(2)
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
                    new ItemCommand(2)
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
                    new ItemCommand(2)
                )
            };
        }

        




        //internal static Dictionary<EnemyBestiary, Foe> Foes()
        //{
        //    return new Dictionary<EnemyBestiary, Foe>
        //    {
        //        {
        //            EnemyBestiary.Spider,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Spider,
        //                Name = "Паук",
        //                Icon = EnemyImages.Spider.Idle,
        //                Description = "Этот паук так долго питался гнильем, что сам стал разносчиком заразы. И вовсе не хочется проверять, что он может взяться за что-то посвежее...",
        //                Action = EnemyImages.Spider.Action,
        //                Size = new Position(1),
        //                Death = EnemyDefeat.Spider,
        //                Stats = new BattleStats(25, 3, 10, 0),
        //                Hp = new Slider(65),
        //                Experience = 5,
        //                Strategy = FightingMode.POSION
        //            }
        //        },

        //        {
        //            EnemyBestiary.Mummy,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Mummy,
        //                Name = "Мумия",
        //                Icon = EnemyImages.Mummy.Idle,
        //                Description = "Непохоже, что кто-то рассказал этому бедолаге как снять бинты. Хотя стойте... Это же ходячий бинт!",
        //                Action = EnemyImages.Mummy.Action,
        //                Size = new Position(2),
        //                Death = EnemyDefeat.Mummy,
        //                Hp = new Slider(83),
        //                Stats = new BattleStats(32, 7, 17, 2),
        //                Experience = 7
        //            }
        //        },

        //        {
        //            EnemyBestiary.Zombie,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Zombie,
        //                Name = "Зомби",
        //                Icon = EnemyImages.Zombie.Idle,
        //                Description = "Многие действительно считали зомби мертвецом, способным словно гепард гоняться за людьми? Бросьте, это же почти полностью разложившийся труп. Он умоляет о том, чтобы его добили.",
        //                Action = EnemyImages.Zombie.Action,
        //                Size = new Position(2, 1),
        //                Death = EnemyDefeat.Zombie,
        //                Hp = new Slider(83),
        //                Stats = new BattleStats(41, 5, 25, 5),
        //                Experience = 11
        //            }
        //        },

        //        {
        //            EnemyBestiary.Bones,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Bones,
        //                Name = "Страж",
        //                Icon = EnemyImages.Bones.Idle,
        //                Description = "Он не кажется таким уж безобидным. Спустя такой стаж охраны у него будет к вам серьезный разговор.",
        //                Action = EnemyImages.Bones.Action,
        //                Size = new Position(2),
        //                Death = EnemyDefeat.Bones,
        //                Hp = new Slider(125),
        //                Stats = new BattleStats(50, 15, 35, 7),
        //                Experience = 15
        //            }
        //        },

        //        {
        //            EnemyBestiary.Vulture,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Vulture,
        //                Name = "Стервятник",
        //                Icon = EnemyImages.Vulture.Idle,
        //                Description = "Это птица? Это винтокрыл? Нет, это ручной гусь Гоша, которого хозяева снова оставили голодным одного.",
        //                Action = EnemyImages.Vulture.Action,
        //                Size = new Position(1),
        //                Death = EnemyDefeat.Vulture,
        //                Hp = new Slider(250),
        //                Stats = new BattleStats(45, 25, 65, 30),
        //                Experience = 35
        //            }
        //        },

        //        {
        //            EnemyBestiary.Ghoul,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Ghoul,
        //                Name = "Гуль",
        //                Icon = EnemyImages.Ghoul.Idle,
        //                Description = "Страшный тип. На глаза к такому лучше точно не попадаться.",
        //                Action = EnemyImages.Ghoul.Action,
        //                Size = new Position(1, 2),
        //                Death = EnemyDefeat.Ghoul,
        //                Hp = new Slider(306),
        //                Stats = new BattleStats(80, 40, 30, 20),
        //                Experience = 75
        //            }
        //        },

        //        {
        //            EnemyBestiary.GrimReaper,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.GrimReaper,
        //                Name = "Жнец",
        //                Icon = EnemyImages.GrimReaper.Idle,
        //                Description = "У него хорошая коса за плечами, вот только не видно ни одного поля с пшеницей посреди пустыни...",
        //                Action = EnemyImages.GrimReaper.Action,
        //                Size = new Position(2),
        //                Death = EnemyDefeat.GrimReaper,
        //                Hp = new Slider(272),
        //                Stats = new BattleStats(100, 20, 45, 60),
        //                Experience = 100
        //            }
        //        },

        //        {
        //            EnemyBestiary.Scarab,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Scarab,
        //                Name = "Скарабей",
        //                Icon = EnemyImages.Scarab.Idle,
        //                Description = "Этот скарабей решил подняться, выполняя работенку посложнее своих жучьих обязанностей.",
        //                Action = EnemyImages.Scarab.Action,
        //                Size = new Position(1),
        //                Death = EnemyDefeat.Scarab,
        //                Hp = new Slider(100),
        //                Stats = new BattleStats(80),
        //                Experience = 60
        //            }
        //        },

        //        {
        //            EnemyBestiary.KillerMole,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.KillerMole,
        //                Name = "Моль-убийца",
        //                Icon = EnemyImages.KillerMole.Idle,
        //                Description = "Такую прелесть точно не захочется найти в своем шкафу.",
        //                Action = EnemyImages.KillerMole.Action,
        //                Size = new Position(1),
        //                Death = EnemyDefeat.KillerMole,
        //                Hp = new Slider(400),
        //                Stats = new BattleStats(150, 100, 100, 75),
        //                Experience = 175
        //            }
        //        },

        //        {
        //            EnemyBestiary.Imp,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Imp,
        //                Name = "Прислужник",
        //                Icon = EnemyImages.Imp.Idle,
        //                Description = "Коварный, безжалостный, этот бес явно не хочет не званых гостей.",
        //                Action = EnemyImages.Imp.Action,
        //                Size = new Position(1),
        //                Death = EnemyDefeat.Imp,
        //                Hp = new Slider(600),
        //                Stats = new BattleStats(125, 105, 90, 140),
        //                Experience = 180
        //            }
        //        },

        //        {
        //            EnemyBestiary.Worm,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Worm,
        //                Name = "Песчаный червь",
        //                Icon = EnemyImages.Worm.Idle,
        //                Description = "Этот пожиратель настолько огромный, что торчит только его хвост. Самое время малость его укоротить...",
        //                Action = EnemyImages.Worm.Action,
        //                Size = new Position(2),
        //                Death = EnemyDefeat.Worm,
        //                Hp = new Slider(950),
        //                Stats = new BattleStats(160, 70, 130, 70),
        //                Experience = 200
        //            }
        //        },

        //        {
        //            EnemyBestiary.Master,
        //            new Foe
        //            {
        //                ID = EnemyBestiary.Master,
        //                Name = "Мастер",
        //                Icon = EnemyImages.Master.Idle,
        //                Description = "Знатока своего дела видно сразу. Но, к сожалению, сговорчивостью он точно не выделяется.",
        //                Action = EnemyImages.Master.Action,
        //                Size = new Position(1),
        //                Death = EnemyDefeat.Master,
        //                Hp = new Slider(760),
        //                Stats = new BattleStats(160),
        //                Experience = 255
        //            }
        //        }
        //    };
        //}

        internal static Dictionary<EnemyBestiary, Boss> Bosses()
        {
            return new Dictionary<EnemyBestiary, Boss>
            {
                {
                    EnemyBestiary.Pharaoh,
                    new Boss
                    {
                        ID = EnemyBestiary.Pharaoh,
                        Name = "Фараон",
                        Icon = BossImages.Pharaoh.Idle,
                        Description = "Страшно представить, что станет с тем, кто лежал замурованным так долго...",
                        Action = BossImages.Pharaoh.Action,
                        Size = new Position(2, 3),
                        Death = BossesDefeat.Pharaoh,
                        Hp = new Slider(500),
                        Stats = new BattleStats(75, 40, 40, 35),
                        Experience = 100
                    }
                },

                {
                    EnemyBestiary.Rock,
                    new Boss
                    {
                        ID = EnemyBestiary.Rock,
                        Name = "Рок",
                        Icon = BossImages.Friend.Idle,
                        Description = "Сразу видно: человек не пропускал физкультуру.",
                        Action = BossImages.Friend.Action,
                        Size = new Position(1, 2),
                        Death = BossesDefeat.Friend,
                        Hp = new Slider(2000),
                        Stats = new BattleStats(170, 120, 90, 140),
                        Experience = 200
                    }
                },

                {
                    EnemyBestiary.TheRuler,
                    new Boss
                    {
                        ID = EnemyBestiary.TheRuler,
                        Name = "Владыка",
                        Icon = BossImages.TheRuler.Idle,
                        Description = "Кто-то не выспался =). Где артефакты, Билли?",
                        Action = BossImages.TheRuler.Action,
                        Size = new Position(2, 3),
                        Death = BossesDefeat.TheRuler,
                        Hp = new Slider(10000),
                        Stats = new BattleStats(255),
                        Experience = 255
                    }
                },

                {
                    EnemyBestiary.UghZan,
                    new Boss
                    {
                        ID = EnemyBestiary.UghZan,
                        Name = "Угх-Зан I",
                        Icon = BossImages.UghZan.Idle,
                        Description = "Так-так-так, кто тут у нас?",
                        Action = BossImages.UghZan.Action,
                        Size = new Position(2, 3),
                        Death = BossesDefeat.UghZan,
                        Hp = new Slider(350),
                        Stats = new BattleStats(100),
                        Experience = 150
                    }
                }
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