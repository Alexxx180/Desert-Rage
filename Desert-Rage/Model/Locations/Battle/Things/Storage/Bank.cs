using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Things;
using DesertRage.Model.Locations.Battle.Things.Storage;
using DesertRage.Resources.OST.Noises.Actions;
using DesertRage.Resources.OST.Noises.Actions.Items;
using DesertRage.ViewModel.Battle;
using DesertRage.ViewModel.Battle.Actions;
using DesertRage.ViewModel.Battle.Actions.Kinds;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent;
using DesertRage.ViewModel.Battle.Actions.Kinds.Dependent.Dependency;
using DesertRage.ViewModel.Battle.Actions.Kinds.Independent;
using System.Collections.Generic;
using static DesertRage.Helpers.Paths.OST;

namespace DesertRage.Model.Menu.Things.Logic
{
    internal class Bank
    {
        internal static Dictionary<SkillsID, ConsumeCommand> Skills()
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
                                Icon = "/Resources/Images/Menu/Skills/Cure.svg",
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
                                Icon = "/Resources/Images/Menu/Skills/Cure2.svg",
                                Noise = ActionNoises.Cure2
                            }
                        ),
                        new SkillCommand(10)
                    )
                },

                {
                    SkillsID.Antidote,
                    new ConsumeCommand(
                        new StatusCommand(
                            StatusID.POISON, false,
                            new NoiseUnit
                            {
                                Name = "Антидот",
                                Description = "- Яд",
                                Icon = "/Resources/Images/Menu/Skills/Heal.svg",
                                Noise = ActionNoises.Heal
                            }
                        ),
                        new SkillCommand(3)
                    )
                },


                {
                    SkillsID.BuffUp,
                    new ConsumeCommand(
                        new StatusCommand(
                            StatusID.REINFORCEMENT, true,
                            new NoiseUnit
                            {
                                Name = "Усиление",
                                Description = "Сконцентрировать всю силу",
                                Icon = "/Resources/Images/Menu/Skills/AttackUp.svg",
                                Noise = ActionNoises.PowerBoost
                            }
                        ),
                        new SkillCommand(20)
                    )
                },

                {
                    SkillsID.Shield,
                    new ConsumeCommand(
                        new StatusCommand(
                            StatusID.SHIELD, true,
                            new NoiseUnit
                            {
                                Name = "Охрана",
                                Description = "Повысить бдительность",
                                Icon = "/Resources/Images/Menu/Skills/DefenceUp.svg",
                                Noise = ActionNoises.DefenceBoost
                            }
                        ),
                        new SkillCommand(15)
                    )
                },

                {
                    SkillsID.Learn,
                    new ConsumeCommand(
                        new FightCommand(
                            new SpecialFormula(0),
                            new NoiseUnit
                            {
                                Name = "Анализ",
                                Description = "Изучить врага как следует",
                                Icon = "/Resources/Images/Menu/Skills/Analyze.svg",
                                Noise = ActionNoises.Scan
                            }
                        ),
                        new SkillCommand(5)
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
                                Icon = "/Resources/Images/Menu/Skills/Torch.svg",
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
                                Icon = "/Resources/Images/Menu/Skills/Whip.svg",
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
                                Icon = "/Resources/Images/Menu/Skills/Slingshot.svg",
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
                                Icon = "/Resources/Images/Menu/Skills/Combo.svg",
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
                                Icon = "/Resources/Images/Menu/Skills/Storm.svg",
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
                                Icon = "/Resources/Images/Menu/Skills/Slide.svg",
                                Noise = ActionNoises.Quake
                            }
                        ),
                        new SkillCommand(25)
                    )
                },
            };
        }

        internal static List<ConsumeCommand> Items()
        {
            return new List<ConsumeCommand>()
            {
                new ConsumeCommand(
                    new CureCommand(
                        new ItemFormula(50),
                        new NoiseUnit(50, "ОЗ")
                        {
                            Name = "Бинт",
                            Icon = "/Resources/Images/Menu/Bag/Bandage.svg",
                            Noise = ActionNoises.Cure
                        }
                    ),
                    new ItemCommand(2)
                ),

                new ConsumeCommand(
                    new StatusCommand(
                        StatusID.POISON, false,
                        new NoiseUnit
                        {
                            Name = "Антидот",
                            Description = "- Яд",
                            Icon = "/Resources/Images/Menu/Bag/Antidote.svg",
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
                            Icon = "/Resources/Images/Menu/Bag/Ether.svg",
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
                            Icon = "/Resources/Images/Menu/Bag/Mixture.svg",
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
                            Icon = "/Resources/Images/Menu/Bag/Herbs.svg",
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
                            Icon = "/Resources/Images/Menu/Bag/EtherBottle.svg",
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
                            Icon = "/Resources/Images/Menu/Bag/Elixir.svg",
                            Noise = ItemNoises.Mixture
                        }
                    ),
                    new ItemCommand(2)
                )
            };
        }

        internal static Dictionary<EnemyBestiary, Foe> Foes()
        {
            return new Dictionary<EnemyBestiary, Foe>
            {
                {
                    EnemyBestiary.Spider,
                    new Foe
                    {
                        Name = "Паук",
                        Icon = "/Resources/Images/Fight/Enemies/Spider/Idle.svg",
                        Description = "Этот паук так долго питался гнильем, что сам стал разносчиком заразы. И вовсе не хочется проверять, что он может взяться за что-то посвежее...",
                        Action = "/Resources/Images/Fight/Enemies/Spider/Action.svg",
                        Size = new Position(1),
                        Death = Sounds.SpiderDied,
                        Stats = new BattleStats(25, 3, 10, 0),
                        Hp = new Bar(65),
                        Experience = 5
                    }
                },

                {
                    EnemyBestiary.Mummy,
                    new Foe
                    {
                        Name = "Мумия",
                        Icon = "/Resources/Images/Fight/Enemies/Mummy/Idle.svg",
                        Description = "Непохоже, что кто-то рассказал этому бедолаге как снять бинты. Хотя стойте... Это же ходячий бинт!",
                        Action = "/Resources/Images/Fight/Enemies/Mummy/Action.svg",
                        Size = new Position(2),
                        Death = Sounds.MummyDied,
                        Hp = new Bar(83),
                        Stats = new BattleStats(32, 7, 17, 2),
                        Experience = 7
                    }
                },

                {
                    EnemyBestiary.Zombie,
                    new Foe
                    {
                        Name = "Зомби",
                        Icon = "/Resources/Images/Fight/Enemies/Zombie/Idle.svg",
                        Description = "Многие действительно считали зомби мертвецом, способным словно гепард гоняться за людьми? Бросьте, это же почти полностью разложившийся труп. Он умоляет о том, чтобы его добили.",
                        Action = "/Resources/Images/Fight/Enemies/Zombie/Action.svg",
                        Size = new Position(2, 1),
                        Death = Sounds.ZombieDied,
                        Hp = new Bar(83),
                        Stats = new BattleStats(41, 5, 25, 5),
                        Experience = 11
                    }
                },

                {
                    EnemyBestiary.Bones,
                    new Foe
                    {
                        Name = "Страж",
                        Icon = "/Resources/Images/Fight/Enemies/Bones/Idle.svg",
                        Description = "Он не кажется таким уж безобидным. Спустя такой стаж охраны у него будет к вам серьезный разговор.",
                        Action = "/Resources/Images/Fight/Enemies/Bones/Action.svg",
                        Size = new Position(2),
                        Death = Sounds.BonesDied,
                        Hp = new Bar(125),
                        Stats = new BattleStats(50, 15, 35, 7),
                        Experience = 15
                    }
                },

                {
                    EnemyBestiary.Vulture,
                    new Foe
                    {
                        Name = "Стервятник",
                        Icon = "/Resources/Images/Fight/Enemies/Vulture/Idle.svg",
                        Description = "Это птица? Это винтокрыл? Нет, это ручной гусь Гоша, которого хозяева снова оставили голодным одного.",
                        Action = "/Resources/Images/Fight/Enemies/Vulture/Action.svg",
                        Size = new Position(1),
                        Death = Sounds.VultureDied,
                        Hp = new Bar(250),
                        Stats = new BattleStats(45, 25, 65, 30),
                        Experience = 35
                    }
                },

                {
                    EnemyBestiary.Ghoul,
                    new Foe
                    {
                        Name = "Гуль",
                        Icon = "/Resources/Images/Fight/Enemies/Ghoul/Idle.svg",
                        Description = "Страшный тип. На глаза к такому лучше точно не попадаться.",
                        Action = "/Resources/Images/Fight/Enemies/Ghoul/Action.svg",
                        Size = new Position(1, 2),
                        Death = Sounds.GhoulDied,
                        Hp = new Bar(306),
                        Stats = new BattleStats(80, 40, 30, 20),
                        Experience = 75
                    }
                },

                {
                    EnemyBestiary.GrimReaper,
                    new Foe
                    {
                        Name = "Жнец",
                        Icon = "/Resources/Images/Fight/Enemies/GrimReaper/Idle.svg",
                        Description = "У него хорошая коса за плечами, вот только не видно ни одного поля с пшеницей посреди пустыни...",
                        Action = "/Resources/Images/Fight/Enemies/GrimReaper/Action.svg",
                        Size = new Position(2),
                        Death = Sounds.GrimReaperDied,
                        Hp = new Bar(272),
                        Stats = new BattleStats(100, 20, 45, 60),
                        Experience = 100
                    }
                },

                {
                    EnemyBestiary.Scarab,
                    new Foe
                    {
                        Name = "Скарабей",
                        Icon = "/Resources/Images/Fight/Enemies/Scarab/Idle.svg",
                        Description = "Этот скарабей решил подняться, выполняя работенку посложнее своих жучьих обязанностей.",
                        Action = "/Resources/Images/Fight/Enemies/Scarab/Action.svg",
                        Size = new Position(1),
                        Death = Sounds.ScarabDied,
                        Hp = new Bar(100),
                        Stats = new BattleStats(80),
                        Experience = 60
                    }
                },

                {
                    EnemyBestiary.KillerMole,
                    new Foe
                    {
                        Name = "Моль-убийца",
                        Icon = "/Resources/Images/Fight/Enemies/KillerMole/Idle.svg",
                        Description = "Такую прелесть точно не захочется найти в своем шкафу.",
                        Action = "/Resources/Images/Fight/Enemies/KillerMole/Action.svg",
                        Size = new Position(1),
                        Death = Sounds.KillerMoleDied,
                        Hp = new Bar(400),
                        Stats = new BattleStats(150, 100, 100, 75),
                        Experience = 175
                    }
                },

                {
                    EnemyBestiary.Imp,
                    new Foe
                    {
                        Name = "Прислужник",
                        Icon = "/Resources/Images/Fight/Enemies/Imp/Idle.svg",
                        Description = "Коварный, безжалостный, этот бес явно не хочет не званых гостей.",
                        Action = "/Resources/Images/Fight/Enemies/Imp/Action.svg",
                        Size = new Position(1),
                        Death = Sounds.ImpDied,
                        Hp = new Bar(600),
                        Stats = new BattleStats(125, 105, 90, 140),
                        Experience = 180
                    }
                },

                {
                    EnemyBestiary.Worm,
                    new Foe
                    {
                        Name = "Песчаный червь",
                        Icon = "/Resources/Images/Fight/Enemies/Worm/Idle.svg",
                        Description = "Этот пожиратель настолько огромный, что торчит только его хвост. Самое время малость его укоротить...",
                        Action = "/Resources/Images/Fight/Enemies/Worm/Action.svg",
                        Size = new Position(2),
                        Death = Sounds.WormDied,
                        Hp = new Bar(950),
                        Stats = new BattleStats(160, 70, 130, 70),
                        Experience = 200
                    }
                },

                {
                    EnemyBestiary.Master,
                    new Foe
                    {
                        Name = "Мастер",
                        Icon = "/Resources/Images/Fight/Enemies/Master/Idle.svg",
                        Description = "Знатока своего дела видно сразу. Но, к сожалению, сговорчивостью он точно не выделяется.",
                        Action = "/Resources/Images/Fight/Enemies/Master/Action.svg",
                        Size = new Position(1),
                        Death = Sounds.MasterDied,
                        Hp = new Bar(760),
                        Stats = new BattleStats(160),
                        Experience = 255
                    }
                }
            };
        }

        internal static Dictionary<EnemyBestiary, Boss> Bosses()
        {
            return new Dictionary<EnemyBestiary, Boss>
            {
                {
                    EnemyBestiary.Pharaoh,
                    new Boss
                    {
                        Name = "Фараон",
                        Icon = "/Resources/Images/Fight/Bosses/Pharaoh/Idle.svg",
                        Description = "Страшно представить, что станет с тем, кто лежал замурованным так долго...",
                        Action = "/Resources/Images/Fight/Bosses/Pharaoh/Action.svg",
                        Size = new Position(2, 3),
                        Death = Sounds.PharaohLost,
                        Hp = new Bar(500),
                        Stats = new BattleStats(75, 40, 40, 35),
                        Experience = 100
                    }
                },

                {
                    EnemyBestiary.Rock,
                    new Boss
                    {
                        Name = "Рок",
                        Icon = "/Resources/Images/Fight/Bosses/Rock/Idle.svg",
                        Description = "Сразу видно: человек не пропускал физкультуру.",
                        Action = "/Resources/Images/Fight/Bosses/Rock/Action.svg",
                        Size = new Position(1, 2),
                        Death = Sounds.RockLost,
                        Hp = new Bar(2000),
                        Stats = new BattleStats(170, 120, 90, 140),
                        Experience = 200
                    }
                },

                {
                    EnemyBestiary.TheRuler,
                    new Boss
                    {
                        Name = "Владыка",
                        Icon = "/Resources/Images/Fight/Bosses/TheRuler/Idle.svg",
                        Description = "Кто-то не выспался =). Где артефакты, Билли?",
                        Action = "/Resources/Images/Fight/Bosses/TheRuler/Action.svg",
                        Size = new Position(2, 3),
                        Death = Sounds.TheRulerLost,
                        Hp = new Bar(10000),
                        Stats = new BattleStats(255),
                        Experience = 255
                    }
                },

                {
                    EnemyBestiary.UghZan,
                    new Boss
                    {
                        Name = "Угх-Зан I",
                        Icon = "/Resources/Images/Fight/Bosses/UghZan/Idle.svg",
                        Description = "Так-так-так, кто тут у нас?",
                        Action = "/Resources/Images/Fight/Bosses/UghZan/Action.svg",
                        Size = new Position(2, 3),
                        Death = Sounds.UghZanLost,
                        Hp = new Bar(350),
                        Stats = new BattleStats(100),
                        Experience = 150
                    }
                }
            };
        }
    }
}