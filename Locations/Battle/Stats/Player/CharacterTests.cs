using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Things.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player;
using DesertRage.Model.Helpers;

namespace DesertRage.Tests.Locations.Battle.Stats.Player
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void ActCharacterReturnFive()
        {
            Character hero = new Character
            {
                Ap = new Slider(10, 100)
            };

            hero.Act(5);
            Assert.AreEqual(5, hero.Ap.Current);
        }

        [TestMethod]
        public void CanActCharacterReturnTrue()
        {
            Character hero = new Character
            {
                Ap = new Slider(1, 100)
            };

            Assert.AreEqual(true, hero.CanAct(1));
        }

        [TestMethod]
        public void CanActCharacterReturnFalse()
        {
            Character hero = new Character
            {
                Ap = new Slider(1, 100)
            };

            Assert.AreEqual(false, hero.CanAct(2));
        }

        [TestMethod]
        public void RestCharacterReturnOneHundred()
        {
            Character hero = new Character
            {
                Ap = new Slider(4, 100)
            };

            hero.Rest();
            Assert.AreEqual(100, hero.Ap.Current);
        }

        [TestMethod]
        public void RestIntCharacterReturnOneHundred()
        {
            Character hero = new Character
            {
                Ap = new Slider(4, 100)
            };

            hero.Rest(20);
            Assert.AreEqual(24, hero.Ap.Current);
        }

        [TestMethod]
        public void LearnCharacterReturnTrue()
        {
            Character hero = new Character
            {
                Learned = new HashSet<EnemyBestiary>()
            };

            EnemyBestiary id = EnemyBestiary.Pharaoh;
            hero.Learn(id);
            Assert.AreEqual(true, hero.Learned.Contains(id));
        }

        [TestMethod]
        public void LearnCharacterReturnFalse()
        {
            Character hero = new Character
            {
                Learned = new HashSet<EnemyBestiary>()
            };

            EnemyBestiary id = EnemyBestiary.Pharaoh;
            Assert.AreEqual(false, hero.Learned.Contains(id));
        }

        [TestMethod]
        public void ChargeExperienceCharacterReturnThree()
        {
            Character hero = new Character
            {
                Level = 1,
                Experience = new Slider(0, 10),
                ToNextLevel = new Bar[]
                {
                    new Bar(0, 10),
                    new Bar(0, 15),
                    new Bar(0, 20),
                },
                Learned = new HashSet<EnemyBestiary>()
            };

            Assert.AreEqual(3, hero.ChargeExperience(25));
        }

        [TestMethod]
        public void LevelUpCharacterReturnLevelThreeStats()
        {
            Character hero = new Character
            {
                Level = 1,
                Hp = new Slider(100),
                Ap = new Slider(100),
                Stats = new BattleStats(10),
                Experience = new Slider(0, 100),
                Learned = new HashSet<EnemyBestiary>()
            };

            NextStats bank = new NextStats
            {
                Hp = new Bar[]
                {
                    new Bar(100),
                    new Bar(200),
                    new Bar(300)
                },
                Ap = new Bar[]
                {
                    new Bar(100),
                    new Bar(200),
                    new Bar(300)
                },
                Stats = new BattleStats[]
                {
                    new BattleStats(10),
                    new BattleStats(20),
                    new BattleStats(30),
                }
            };

            byte nextLevel = 3;
            hero.LevelUp(bank, nextLevel);

            nextLevel--;
            Assert.AreEqual(bank.Hp[nextLevel].Minimum, hero.Hp.Minimum);
            Assert.AreEqual(bank.Hp[nextLevel].Current, hero.Hp.Current);
            Assert.AreEqual(bank.Hp[nextLevel].Max, hero.Hp.Max);

            Assert.AreEqual(bank.Ap[nextLevel].Minimum, hero.Ap.Minimum);
            Assert.AreEqual(bank.Ap[nextLevel].Current, hero.Ap.Current);
            Assert.AreEqual(bank.Ap[nextLevel].Max, hero.Ap.Max);

            Assert.AreEqual(bank.Stats[nextLevel], hero.Stats);
        }

        [TestMethod]
        public void SetStatusStatusIDCharacterReturnTrue()
        {
            Character unit = new Character
            {
                StatusInfo = new Status[]
                {
                    new Status
                    {
                        Time = new Slider(50, 100)
                    },
                    new Status
                    {
                        Time = new Slider(50, 100)
                    }
                }
            };

            StatusID id = StatusID.POISON;
            unit.SetStatus(id, true);
            Assert.AreEqual(true, unit.Status[id.Int()]);
        }

        [TestMethod]
        public void SetStatusStatusIDCharacterReturnFalse()
        {
            Character unit = new Character
            {
                StatusInfo = new Status[]
                {
                    new Status
                    {
                        Time = new Slider(50, 100)
                    },
                    new Status
                    {
                        Time = new Slider(50, 100)
                    }
                }
            };

            StatusID id = StatusID.POISON;
            unit.SetStatus(id, false);
            Assert.AreEqual(false, unit.Status[id.Int()]);
        }

        [TestMethod]
        public void SetPlaceCharacterReturnFiveAndTen()
        {
            Character hero = new Character
            {
                Place = new Position(2, 4)
            };

            Position warp = new Position(5, 10);
            hero.SetPlace(warp);
            Assert.AreEqual(warp, hero.Place);
        }

        [TestMethod]
        public void IsBattleCharacterReturnTrue()
        {
            Character hero = new Character
            {
                ToBattle = 1
            };

            Assert.AreEqual(true, hero.IsBattle());
        }

        [TestMethod]
        public void IsBattleCharacterReturnFalse()
        {
            Character hero = new Character
            {
                ToBattle = 2
            };

            Assert.AreEqual(false, hero.IsBattle());
        }

        [TestMethod]
        public void GoNoWallCharacterReturnThreeAndOne()
        {
            char[][] map = new char[][]
            {
                ".....".ToCharArray(),
                ".....".ToCharArray(),
                ".....".ToCharArray(),
                ".....".ToCharArray(),
                ".....".ToCharArray()
            };

            Character hero = new Character
            {
                Walk = 0,
                Pose = 0,
                Step = new Position[]
                {
                    new Position(0, -1)
                },
                MapImage = "",
                Place = new Position(3, 2),
                GoingImage = new string[][]
                {
                    new string[] { "UP" }
                },
                WalkThrough = new HashSet<char> { '.' }
            };

            hero.Go(map, 0);
            Assert.AreEqual(0, hero.Pose);
            Assert.AreEqual(0, hero.Walk);
            Assert.AreEqual("UP", hero.MapImage);

            Assert.AreEqual(new Position(3, 1), hero.Place);
        }

        [TestMethod]
        public void GoWallCharacterReturnThreeAndTwo()
        {
            char[][] map = new char[][]
            {
                ".....".ToCharArray(),
                ".HHH.".ToCharArray(),
                ".HH..".ToCharArray(),
                ".....".ToCharArray(),
                ".....".ToCharArray()
            };

            Character hero = new Character
            {
                Walk = 0,
                Pose = 0,
                Step = new Position[]
                {
                    new Position(0, -1)
                },
                MapImage = "",
                Place = new Position(3, 2),
                GoingImage = new string[][]
                {
                    new string[] { "UP" }
                },
                WalkThrough = new HashSet<char> { '.' }
            };

            hero.Go(map, 0);
            Assert.AreEqual(0, hero.Pose);
            Assert.AreEqual(0, hero.Walk);
            Assert.AreEqual("UP", hero.MapImage);

            Assert.AreEqual(new Position(3, 2), hero.Place);
        }

        [TestMethod]
        public void StandCharacterReturnImage()
        {
            Character hero = new Character
            {
                Pose = 0,
                StandImage = new string[] { "Image" },
                MapImage = ""
            };

            hero.Stand();
            Assert.AreEqual("Image", hero.MapImage);
        }
    }
}