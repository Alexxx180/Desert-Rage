using DesertRage.Model.Locations.Map;
using DesertRage.Model.Stats;
using DesertRage.Model.Stats.Enemy;
using System.Collections.Generic;
using static DesertRage.Helpers.Paths.OST;

namespace DesertRage.Model.Locations
{
    public class Location
    {
        public string Name { get; set; }
        public string[] Map { get; set; }

        public string BackCover { get; set; }

        public Dictionary<string, string> TileCodes { get; set; }
        public Dictionary<string, MapObject> MapItems { get; set; }

        public void CompeteTask(int taskNo)
        {
            Tasks.Complete(taskNo);
        }

        public void CompleteOther(int taskNo)
        {
            Other.Complete(taskNo);
        }

        public static Foe[] GetFoes()
        {
            Foe[] foes = new Foe[]
            {
                new Foe
                {
                    No = EnemyBestiary.Spider,
                    Name = "Паук",
                    Icon = "/Resources/Images/Fight/Enemies/Spider/Idle.svg",
                    Description = "Этот паук так долго питался гнильем, что сам стал разносчиком заразы. И вовсе не хочется проверять, что он может взяться за что-то посвежее...",
                    Action = "/Resources/Images/Fight/Enemies/Spider/Action.svg",
                    Size = new Position(1),
                    Death = Sounds.SpiderDied,
                    Stats = new BattleStats {
                        Attack = 25,
                        Defence = 3,
                        Speed = 10,
                    },
                    Agility = 0,
                    Hp = new Bar(65),
                    Experience = 5
                },
                new Foe
                {
                    No = EnemyBestiary.Mummy,
                    Name = "Мумия",
                    Icon = "/Resources/Images/Fight/Enemies/Mummy/Idle.svg",
                    Description = "Непохоже, что кто-то рассказал этому бедалаге как снять бинты. Хотя стойте... Это же ходячий бинт!",
                    Action = "/Resources/Images/Fight/Enemies/Mummy/Action.svg",
                    Size = new Position(2),
                    Death = Sounds.MummyDied,
                    Hp = new Bar(83),
                    Stats = new BattleStats {
                        Attack = 32,
                        Defence = 7,
                        Speed = 17,
                    },
                    Agility = 2,
                    Experience = 7
                },
                new Foe
                {
                    No = EnemyBestiary.Zombie,
                    Name = "Зомби",
                    Icon = "/Resources/Images/Fight/Enemies/Zombie/Idle.svg",
                    Description = "Многие действительно считали зомби мертвецом, способным словно гепард гоняться за людьми? Бросьте, это же почти полностью разложившийся труп. Он умоляет о том, чтобы его добили.",
                    Action = "/Resources/Images/Fight/Enemies/Zombie/Action.svg",
                    Size = new Position(2, 1),
                    Death = Sounds.ZombieDied,
                    Hp = new Bar(83),
                    Stats = new BattleStats {
                        Attack = 41,
                        Defence = 5,
                        Speed = 25,
                    },
                    Agility = 5,
                    Experience = 11
                },
                new Foe
                {
                    No = EnemyBestiary.Bones,
                    Name = "Страж",
                    Icon = "/Resources/Images/Fight/Enemies/Bones/Idle.svg",
                    Description = "Он не кажется таким уж безобидным. Спустя такой стаж охраны у него будет к вам серьезный разговор.",
                    Action = "/Resources/Images/Fight/Enemies/Bones/Action.svg",
                    Size = new Position(2),
                    Death = Sounds.BonesDied,
                    Hp = new Bar(125),
                    Stats = new BattleStats {
                        Attack = 50,
                        Defence = 15,
                        Speed = 35,
                    },
                    Agility = 7,
                    Experience = 15
                },
                new Foe
                {
                    No = EnemyBestiary.Vulture,
                    Name = "Стервятник",
                    Icon = "/Resources/Images/Fight/Enemies/Vulture/Idle.svg",
                    Description = "Это птица? Это винтокрыл? Нет, это ручной гусь Гоша, которого хозяева снова оставили голодным одного.",
                    Action = "/Resources/Images/Fight/Enemies/Vulture/Action.svg",
                    Size = new Position(1),
                    Death = Sounds.VultureDied,
                    Hp = new Bar(250),
                    Stats = new BattleStats {
                        Attack = 45,
                        Defence = 25,
                        Speed = 65,
                    },
                    Agility = 30,
                    Experience = 35
                },
                new Foe
                {
                    No = EnemyBestiary.Ghoul,
                    Name = "Гуль",
                    Icon = "/Resources/Images/Fight/Enemies/Ghoul/Idle.svg",
                    Description = "Страшный тип. На глаза к такому лучше точно не попадаться.",
                    Action = "/Resources/Images/Fight/Enemies/Ghoul/Action.svg",
                    Size = new Position(1, 2),
                    Death = Sounds.GhoulDied,
                    Hp = new Bar(306),
                    Stats = new BattleStats {
                        Attack = 80,
                        Defence = 40,
                        Speed = 30,
                    },
                    Agility = 20,
                    Experience = 75
                },
                new Foe
                {
                    No = EnemyBestiary.GrimReaper,
                    Name = "Жнец",
                    Icon = "/Resources/Images/Fight/Enemies/GrimReaper/Idle.svg",
                    Description = "У него хорошая коса за плечами, вот только не видно ни одного поля с пшеницей посреди пустыни...",
                    Action = "/Resources/Images/Fight/Enemies/GrimReaper/Action.svg",
                    Size = new Position(2),
                    Death = Sounds.GrimReaperDied,
                    Hp = new Bar(272),
                    Stats = new BattleStats {
                        Attack = 100,
                        Defence = 20,
                        Speed = 45,
                    },
                    Agility = 60,
                    Experience = 100
                },
                new Foe
                {
                    No = EnemyBestiary.Scarab,
                    Name = "Скарабей",
                    Icon = "/Resources/Images/Fight/Enemies/Scarab/Idle.svg",
                    Description = "Этот скарабей решил подняться, выполняя работенку посложнее своих жучьих обязанностей.",
                    Action = "/Resources/Images/Fight/Enemies/Scarab/Action.svg",
                    Size = new Position(1),
                    Death = Sounds.ScarabDied,
                    Hp = new Bar(100),
                    Stats = new BattleStats {
                        Attack = 75,
                        Defence = 80,
                        Speed = 80,
                    },
                    Agility = 80,
                    Experience = 60
                },
                new Foe
                {
                    No = EnemyBestiary.KillerMole,
                    Name = "Моль-убийца",
                    Icon = "/Resources/Images/Fight/Enemies/KillerMole/Idle.svg",
                    Description = "Такую прелесть точно не захочется найти в своем шкафу.",
                    Action = "/Resources/Images/Fight/Enemies/KillerMole/Action.svg",
                    Size = new Position(1),
                    Death = Sounds.KillerMoleDied,
                    Hp = new Bar(400),
                    Stats = new BattleStats {
                        Attack = 150,
                        Defence = 100,
                        Speed = 100,
                    },
                    Agility = 75,
                    Experience = 175
                },
                new Foe
                {
                    No = EnemyBestiary.Imp,
                    Name = "Прислужник",
                    Icon = "/Resources/Images/Fight/Enemies/Imp/Idle.svg",
                    Description = "Коварный, безжалостный, этот бес явно не хочет не званых гостей.",
                    Action = "/Resources/Images/Fight/Enemies/Imp/Action.svg",
                    Size = new Position(1),
                    Death = Sounds.ImpDied,
                    Hp = new Bar(600),
                    Stats = new BattleStats {
                        Attack = 125,
                        Defence = 105,
                        Speed = 90,
                    },
                    Agility = 140,
                    Experience = 180
                },
                new Foe
                {
                    No = EnemyBestiary.Worm,
                    Name = "Песчаный червь",
                    Icon = "/Resources/Images/Fight/Enemies/Worm/Idle.svg",
                    Description = "Этот пожиратель настолько огромный, что торчит только его хвост. Самое время малость его укоротить...",
                    Action = "/Resources/Images/Fight/Enemies/Worm/Action.svg",
                    Size = new Position(2),
                    Death = Sounds.WormDied,
                    Hp = new Bar(950),
                    Stats = new BattleStats {
                        Attack = 160,
                        Defence = 70,
                        Speed = 130,
                    },
                    Agility = 70,
                    Experience = 200
                },
                new Foe
                {
                    No = EnemyBestiary.Master,
                    Name = "Мастер",
                    Icon = "/Resources/Images/Fight/Enemies/Master/Idle.svg",
                    Description = "Знатока своего дела видно сразу. Но, к сожалению, сговорчивостью он точно не выделяется.",
                    Action = "/Resources/Images/Fight/Enemies/Master/Action.svg",
                    Size = new Position(1),
                    Death = Sounds.MasterDied,
                    Hp = new Bar(760),
                    Stats = new BattleStats {
                        Attack = 160,
                        Defence = 150,
                        Speed = 150,
                    },
                    Agility = 150,
                    Experience = 255
                },
                new Boss
                {
                    No = EnemyBestiary.Pharaoh,
                    Name = "Фараон",
                    Icon = "/Resources/Images/Fight/Bosses/Pharaoh/Idle.svg",
                    Description = "Страшно представить, что станет с тем, кто лежал замурованным так долго...",
                    Action = "/Resources/Images/Fight/Bosses/Pharaoh/Action.svg",
                    Size = new Position(2, 3),
                    Death = Sounds.PharaohLost,
                    Hp = new Bar(500),
                    Stats = new BattleStats {
                        Attack = 75,
                        Defence = 40,
                        Speed = 40,
                    },
                    Agility = 35,
                    Experience = 100
                },
                new Boss
                {
                    No = EnemyBestiary.Rock,
                    Name = "Рок",
                    Icon = "/Resources/Images/Fight/Bosses/Rock/Idle.svg",
                    Description = "Сразу видно: человек не пропускал физкультуру.",
                    Action = "/Resources/Images/Fight/Bosses/Rock/Action.svg",
                    Size = new Position(1, 2),
                    Death = Sounds.RockLost,
                    Hp = new Bar(2000),
                    Stats = new BattleStats {
                        Attack = 170,
                        Defence = 120,
                        Speed = 90,
                    },
                    Agility = 140,
                    Experience = 200
                },
                new Boss
                {
                    No = EnemyBestiary.TheRuler,
                    Name = "Владыка",
                    Icon = "/Resources/Images/Fight/Bosses/TheRuler/Idle.svg",
                    Description = "Кто-то не выспался =). Где артефакты, Билли?",
                    Action = "/Resources/Images/Fight/Bosses/TheRuler/Action.svg",
                    Size = new Position(2, 3),
                    Death = Sounds.TheRulerLost,
                    Hp = new Bar(10000),
                    Stats = new BattleStats {
                        Attack = 255,
                        Defence = 255,
                        Speed = 255,
                    },
                    Agility = 255,
                    Experience = 255
                },
                new Boss
                {
                    No = EnemyBestiary.UghZan,
                    Name = "Угх-Зан I",
                    Icon = "/Resources/Images/Fight/Bosses/UghZan/Idle.svg",
                    Description = "Так-так-так, кто тут у нас?",
                    Action = "/Resources/Images/Fight/Bosses/UghZan/Action.svg",
                    Size = new Position(2, 3),
                    Death = Sounds.UghZanLost,
                    Hp = new Bar(350),
                    Stats = new BattleStats {
                        Attack = 100,
                        Defence = 50,
                        Speed = 50,
                    },
                    Agility = 50,
                    Experience = 150
                }
            };

            return foes;
        }

        internal Quests Tasks { get; set; }
        internal Quests Other { get; set; }

        public Foe[] StageFoes { get; set; }
        public Boss StageBoss { get; set; }
    }
}