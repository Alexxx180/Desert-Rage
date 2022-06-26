using DesertRage.Model.Helpers;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Things.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

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
                Status = new BitArray
                    (new bool[] { true, false }),
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

            Assert.AreEqual(item.Status[0], clone.Status[0]);
            Assert.AreEqual(item.Status[1], clone.Status[1]);

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
                Status = new BitArray
                    (new bool[] { true, false }),
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

            Assert.AreEqual(item.Status[0], clone.Status[0]);
            Assert.AreEqual(item.Status[1], clone.Status[1]);

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
                }
            };
            unit.SetStatus(StatusID.DEFENCE, true);
            unit.SetStatus(StatusID.SHIELD, true);

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
        public void HealStatusBattleUnitReturnZero()
        {
            BattleUnit unit = new BattleUnit
            {
                StatusInfo = new Status[]
                {
                    new Status
                    {
                        Time = new Slider(50, 100)
                    }
                }
            };

            unit.HealStatus(0);
            Assert.AreEqual(0, unit.StatusInfo[0].Time.Current);
        }

        [TestMethod]
        public void SetStatusBattleUnitReturnTrue()
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

            unit.SetStatus(true);
            for (byte i = 0; i < unit.Status.Length; i++)
                Assert.AreEqual(true, unit.Status[i]);
        }

        [TestMethod]
        public void SetStatusBattleUnitReturnFalse()
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

            unit.SetStatus(false);
            for (byte i = 0; i < unit.Status.Length; i++)
                Assert.AreEqual(false, unit.Status[i]);
        }

        [TestMethod]
        public void SetStatusIntBattleUnitReturnTrue()
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

            unit.SetStatus(0, true);
            Assert.AreEqual(true, unit.Status[0]);
        }

        [TestMethod]
        public void SetStatusIntBattleUnitReturnFalse()
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

            unit.SetStatus(0, false);
            Assert.AreEqual(false, unit.Status[0]);
        }

        [TestMethod]
        public void SetStatusStatusIDBattleUnitReturnTrue()
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

            StatusID id = StatusID.POISON;
            unit.SetStatus(id, true);
            Assert.AreEqual(true, unit.Status[id.Int()]);
        }

        [TestMethod]
        public void SetStatusStatusIDBattleUnitReturnFalse()
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

            StatusID id = StatusID.POISON;
            unit.SetStatus(id, false);
            Assert.AreEqual(false, unit.Status[id.Int()]);
        }

        [TestMethod]
        public void BoostBattleUnitReturnTwo()
        {
            BattleUnit unit = new BattleUnit
            {
                Status = new BitArray(2)
            };

            StatusID id = StatusID.POISON;
            unit.SetStatus(id, true);
            Assert.AreEqual(2, unit.Boost(id));
        }

        [TestMethod]
        public void BoostArrayBattleUnitReturnTwo()
        {
            BattleUnit unit = new BattleUnit
            {
                Status = new BitArray(2)
            };

            StatusID id1 = StatusID.POISON;
            unit.SetStatus(id1, true);
            StatusID id2 = StatusID.REINFORCEMENT;
            unit.SetStatus(id2, true);
            Assert.AreEqual(4, unit.Boost(id1, id2));
        }
    }
}