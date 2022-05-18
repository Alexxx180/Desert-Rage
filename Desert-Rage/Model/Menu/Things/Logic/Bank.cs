using DesertRage.Model.Locations.Map;
using DesertRage.Model.Stats;
using DesertRage.Model.Stats.Enemy;
using DesertRage.ViewModel.Actions;
using DesertRage.ViewModel.Actions.Dependent;
using DesertRage.ViewModel.Actions.Independent;
using DesertRage.ViewModel.Battle.Actions.Dependent;
using DesertRage.ViewModel.Battle.Actions.Independent;
using System.Collections.Generic;
using static DesertRage.Helpers.Paths.OST;

namespace DesertRage.Model.Menu.Things.Logic
{
    internal class Bank
    {
        internal static Dictionary<SkillsID, ActCommand> Skills()
        {
            return new Dictionary<SkillsID, ActCommand>
            {
                {
                    SkillsID.Cure,
                    new CureCommand(
                        new SkillCommand(
                            new Skill(1.8f)
                            {
                                Name = "Лечение",
                                Value = 5,
                                Icon = "/Resources/Images/Menu/Skills/Cure.svg",
                                Description = "+ ОЗ"
                            }
                        )
                    )
                },

                {
                    SkillsID.Cure2,
                    new CureMaxCommand(
                        new SkillCommand(
                            new Skill
                            {
                                Name = "Лечение 2",
                                Value = 10,
                                Icon = "/Resources/Images/Menu/Skills/Cure2.svg",
                                Description = "100% ОЗ"
                            }
                        )
                    )
                },

                {
                    SkillsID.Antidote,
                    new StatusCommand(0, false,
                        new SkillCommand(
                            new Skill
                            {
                                Name = "Антидот",
                                Value = 3,
                                Icon = "/Resources/Images/Menu/Skills/Heal.svg",
                                Description = "- Яд"
                            }
                        )
                    )
                },


                {
                    SkillsID.BuffUp,
                    new StatusCommand(1, true,
                        new SkillCommand(
                            new Skill
                            {
                                Name = "Усиление",
                                Value = 20,
                                Icon = "/Resources/Images/Menu/Skills/AttackUp.svg",
                                Description = "Сконцентрировать всю силу"
                            }
                        )
                    )
                },

                {
                    SkillsID.Shield,
                    new StatusCommand(2, true,
                        new SkillCommand(
                            new Skill
                            {
                                Name = "Охрана",
                                Value = 15,
                                Icon = "/Resources/Images/Menu/Skills/DefenceUp.svg",
                                Description = "Повысить бдительность"
                            }
                        )
                    )
                },

                {
                    SkillsID.Learn,
                    new FightCommand(
                        new SkillCommand(
                            new Skill
                            {
                                Name = "Анализ",
                                Value = 5,
                                Icon = "/Resources/Images/Menu/Skills/Analyze.svg",
                                Description = "Изучить врага как следует"
                            }
                        )
                    )
                },


                {
                    SkillsID.Torch,
                    new FightCommand(
                        new SkillCommand(
                            new Skill(2f)
                            {
                                Name = "Факел",
                                Value = 5,
                                Icon = "/Resources/Images/Menu/Skills/Torch.svg",
                                Description = "Хорошо поджигает"
                            }
                        )
                    )
                },

                {
                    SkillsID.Whip,
                    new FightCommand(
                        new SkillCommand(
                            new Skill(3.5f)
                            {
                                Name = "Кнут",
                                Value = 7,
                                Icon = "/Resources/Images/Menu/Skills/Whip.svg",
                                Description = "Дробит кости"
                            }
                        )
                    )
                },

                {
                    SkillsID.Sling,
                    new FightCommand(
                        new SkillCommand(
                            new Skill(5f)
                            {
                                Name = "Рогатка",
                                Value = 13,
                                Icon = "/Resources/Images/Menu/Skills/Slingshot.svg",
                                Description = "От нее не скрыться"
                            }
                        )
                    )
                },


                {
                    SkillsID.Combo,
                    new FightAllCommand(
                        new SkillCommand(
                            new Skill(3f)
                            {
                                Name = "Комбо",
                                Value = 10,
                                Icon = "/Resources/Images/Menu/Skills/Combo.svg",
                                Description = "Град ударов по врагам"
                            }
                        )
                    )
                },

                {
                    SkillsID.Whirl,
                    new FightAllCommand(
                        new SkillCommand(
                            new Skill(4f)
                            {
                                Name = "Буря",
                                Value = 18,
                                Icon = "/Resources/Images/Menu/Skills/Storm.svg",
                                Description = "Неистовый порыв ветра"
                            }
                        )
                    )
                },

                {
                    SkillsID.Quake,
                    new FightAllCommand(
                        new SkillCommand(
                            new Skill(5f)
                            {
                                Name = "Обвал",
                                Value = 25,
                                Icon = "/Resources/Images/Menu/Skills/Slide.svg",
                                Description = "Усыпать противников камнями"
                            }
                        )
                    )
                },
            };
        }

        internal static List<ActCommand> Items()
        {
            return new List<ActCommand>()
            {
                new CureCommand(
                    new ItemCommand(
                        new Item(50, "ОЗ")
                        {
                            Name = "Бинт",
                            Value = 1,
                            Icon = "/Resources/Images/Menu/Bag/Bandage.svg",
                        }
                    )
                ),

                new StatusCommand(0, false,
                    new ItemCommand(
                        new Item
                        {
                            Name = "Антидот",
                            Description = "- Яд",
                            Icon = "/Resources/Images/Menu/Bag/Antidote.svg",
                            Value = 1
                        }
                    )
                ),

                new RestCommand(
                    new ItemCommand(
                        new Item(50, "ОД")
                        {
                            Name = "Эфир",
                            Icon = "/Resources/Images/Menu/Bag/Ether.svg",
                            Value = 1
                        }
                    )
                ),

                new RecoverCommand(
                    new ItemCommand(
                        new Item(80, "ОЗ-ОД")
                        {
                            Name = "Смесь",
                            Icon = "/Resources/Images/Menu/Bag/Mixture.svg",
                            Value = 1
                        }
                    )
                ),

                new CureCommand(
                    new ItemCommand(
                        new Item(350, "ОЗ")
                        {
                            Name = "Травы",
                            Icon = "/Resources/Images/Menu/Bag/Herbs.svg",
                            Value = 1
                        }
                    )
                ),

                new RestCommand(
                    new ItemCommand(
                        new Item(300, "ОД")
                        {
                            Name = "Бутыль эфира",
                            Icon = "/Resources/Images/Menu/Bag/EtherBottle.svg",
                            Value = 1
                        }
                    )
                ),
                
                new RecoverMaxCommand(
                    new ItemCommand(
                        new Item
                        {
                            Name = "Эликсир",
                            Value = 1,
                            Icon = "/Resources/Images/Menu/Bag/Elixir.svg",
                            Description = "100% ОЗ-ОД"
                        }
                    )
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
                        Stats = new BattleStats(25, 3, 10),
                        Special = 0,
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
                        Stats = new BattleStats(32, 7, 17),
                        Special = 2,
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
                        Stats = new BattleStats(41, 5, 25),
                        Special = 5,
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
                        Stats = new BattleStats(50, 15, 35),
                        Special = 7,
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
                        Stats = new BattleStats(45, 25, 65),
                        Special = 30,
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
                        Stats = new BattleStats(80, 40, 30),
                        Special = 20,
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
                        Stats = new BattleStats(100, 20, 45),
                        Special = 60,
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
                        Special = 80,
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
                        Stats = new BattleStats(150, 100, 100),
                        Special = 75,
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
                        Stats = new BattleStats(125, 105, 90),
                        Special = 140,
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
                        Stats = new BattleStats(160, 70, 130),
                        Special = 70,
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
                        Special = 150,
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
                        Stats = new BattleStats(75, 40, 40),
                        Special = 35,
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
                        Stats = new BattleStats(170, 120, 90),
                        Special = 140,
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
                        Special = 255,
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
                        Stats = new BattleStats(100, 100, 50),
                        Special = 50,
                        Experience = 150
                    }
                }
            };
        }
    }
}