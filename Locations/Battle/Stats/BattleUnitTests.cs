using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Things.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesertRage.Tests.Locations.Battle.Stats
{
    [TestClass]
    public class BattleUnitTests
    {
        [TestMethod]
        public void SetStatusTimingBattleUnitReturnOne()
        {
            BattleUnit unit = new BattleUnit();

            unit.SetStatusTiming(1);
            for (byte i = 0; i < unit.StatusInfo.Length; i++)
            {
                Slider time = unit.StatusInfo[i].Time;

                Assert.AreEqual(0, time.Minimum);
                Assert.AreEqual(1, time.Max);
            }
        }

        [TestMethod]
        public void SetBattleUnitReturnItem()
        {
            BattleUnit item = new BattleUnit
            {
                Name = "Name",
                Icon = "Icon",
                Description = "Description",
                Hp = new Slider(1, 500, 999),
                Stats = new BattleStats(50),
                Action = "Action",
                StatusInfo = new Status[]
                {
                    new Status
                    {
                        Time = new Slider(1, 50, 200)
                    }
                }
            };

            BattleUnit clone = new BattleUnit();
            clone.Set(item);

            Assert.AreEqual(item.Name, clone.Name);
            Assert.AreEqual(item.Icon, clone.Icon);
            Assert.AreEqual(item.Description, clone.Description);

            Slider hp = item.Hp;

            Assert.AreEqual(hp.Minimum, clone.Hp.Minimum);
            Assert.AreEqual(hp.Current, clone.Hp.Current);
            Assert.AreEqual(hp.Max, clone.Hp.Max);

            Assert.AreEqual(item.Stats, clone.Stats);
            Assert.AreEqual(item.Action, clone.Action);

            Slider time = item.StatusInfo[0].Time;
            Slider cloneTime = item.StatusInfo[0].Time;

            Assert.AreEqual(time.Minimum, cloneTime.Minimum);
            Assert.AreEqual(time.Current, cloneTime.Current);
            Assert.AreEqual(time.Max, cloneTime.Max);
        }

        [TestMethod]
        public void CloneBattleUnitReturnItem()
        {
            BattleUnit item = new BattleUnit
            {
                Name = "Name",
                Icon = "Icon",
                Description = "Description",
                Hp = new Slider(1, 500, 999),
                Stats = new BattleStats(50),
                Action = "Action",
                StatusInfo = new Status[]
                {
                    new Status
                    {
                        Time = new Slider(1, 50, 200)
                    }
                }
            };

            BattleUnit clone = item.Clone();

            Assert.AreEqual(item.Name, clone.Name);
            Assert.AreEqual(item.Icon, clone.Icon);
            Assert.AreEqual(item.Description, clone.Description);

            Slider hp = item.Hp;

            Assert.AreEqual(hp.Minimum, clone.Hp.Minimum);
            Assert.AreEqual(hp.Current, clone.Hp.Current);
            Assert.AreEqual(hp.Max, clone.Hp.Max);

            Assert.AreEqual(item.Stats, clone.Stats);
            Assert.AreEqual(item.Action, clone.Action);

            Slider time = item.StatusInfo[0].Time;
            Slider cloneTime = item.StatusInfo[0].Time;

            Assert.AreEqual(time.Minimum, cloneTime.Minimum);
            Assert.AreEqual(time.Current, cloneTime.Current);
            Assert.AreEqual(time.Max, cloneTime.Max);
        }

        [TestMethod]
        public void AnihillateBattleUnitReturnZero()
        {
            BattleUnit unit = new BattleUnit
            {
                Hp = new Slider(999)
            };

            unit.Annihilate();
            Assert.AreEqual(0, unit.Hp.Current);
        }

        [TestMethod]
        public void HitNoBoostsBattleUnitReturnSeventyFive()
        {
            BattleUnit unit = new BattleUnit
            {
                Hp = new Slider(100),
                Stats = new BattleStats
                {
                    Defence = 50
                }
            };

            unit.Hit(75);
            Assert.AreEqual(75, unit.Hp.Current);
        }

        [TestMethod]
        public void HitBoostsBattleUnitReturnNintyFour()
        {
            BattleUnit unit = new BattleUnit
            {
                Hp = new Slider(100),
                Stats = new BattleStats
                {
                    Defence = 50
                },
                StatusInfo = new Status[]
                {
                    new Status
                    {
                        Time = new Slider(0, 100),
                    },
                    new Status
                    {
                        Time = new Slider(0, 100),
                    },
                    new Status
                    {
                        Time = new Slider(0, 100),
                    },
                    new Status
                    {
                        Time = new Slider(0, 100),
                    },
                    new Status
                    {
                        Time = new Slider(0, 100),
                    }
                }
            };

            unit.MakeStatus(StatusID.DEFENCE.Int());
            unit.MakeStatus(StatusID.SHIELD.Int());

            unit.Hit(75);
            Assert.AreEqual(94, unit.Hp.Current);
        }

        [TestMethod]
        public void CureBattleUnitReturnOneHundred()
        {
            BattleUnit unit = new BattleUnit
            {
                Hp = new Slider(50, 100),
            };

            unit.Cure();
            Assert.AreEqual(100, unit.Hp.Current);
        }

        [TestMethod]
        public void CureBattleUnitReturnSeventyFive()
        {
            BattleUnit unit = new BattleUnit
            {
                Hp = new Slider(50, 100),
            };

            unit.Cure(25);
            Assert.AreEqual(75, unit.Hp.Current);
        }

        [TestMethod]
        public void MakeStatusBattleUnitReturnFalse()
        {
            BattleUnit unit = new BattleUnit
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

            int id = StatusID.POISON.Int();
            unit.MakeStatus(id);
            Assert.AreEqual(false, unit.NoStatus(id));
        }

        [TestMethod]
        public void HealStatusBattleUnitReturnTrue()
        {
            BattleUnit unit = new BattleUnit
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

            int id = StatusID.POISON.Int();
            unit.HealStatus(id);
            Assert.AreEqual(true, unit.NoStatus(id));
        }

        [TestMethod]
        public void BoostBattleUnitReturnOne()
        {
            BattleUnit unit = new BattleUnit
            {
                StatusInfo = new Status[]
                {
                    new Status()
                    {
                        Time = new Slider(0, 100)
                    }
                }
            };

            StatusID poison = StatusID.POISON;
            
            Assert.AreEqual(1, unit.Boost(poison));
        }

        [TestMethod]
        public void BoostBattleUnitReturnTwo()
        {
            BattleUnit unit = new BattleUnit
            {
                StatusInfo = new Status[]
                {
                    new Status()
                    {
                        Time = new Slider(0, 100)
                    },
                    new Status()
                    {
                        Time = new Slider(0, 100)
                    }
                }
            };

            StatusID poison = StatusID.POISON;
            unit.MakeStatus(poison.Int());
            Assert.AreEqual(2, unit.Boost(poison));
        }

        [TestMethod]
        public void BoostArrayBattleUnitReturnFour()
        {
            BattleUnit unit = new BattleUnit
            {
                StatusInfo = new Status[]
                {
                    new Status()
                    {
                        Time = new Slider(0, 100)
                    },
                    new Status()
                    {
                        Time = new Slider(0, 100)
                    }
                }
            };

            StatusID id1 = StatusID.POISON;
            StatusID id2 = StatusID.REINFORCEMENT;

            unit.MakeStatus(id1.Int());
            unit.MakeStatus(id2.Int());
            Assert.AreEqual(4, unit.Boost(id1, id2));
        }
    }
}