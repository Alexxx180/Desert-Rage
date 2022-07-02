using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using DesertRage.Model.Locations.Battle.Stats;
using DesertRage.Model.Locations.Battle.Stats.Enemy;
using DesertRage.Model.Locations.Battle.Things.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;

namespace DesertRage.Tests.Locations.Battle.Stats.Enemy
{
    [TestClass]
    public class BossTests
    {
        [TestMethod]
        public void SetBossReturnBoss()
        {
            Boss foe = new Boss
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
                },
                ID = EnemyBestiary.Spider,
                IsLearned = true,
                Death = "Death",
                Size = new Position(3),
                Experience = 10,
                Drop = ItemsID.Bandage,
                Strategy = FightingMode.ATTACK,
                Theme = "Theme"
            };

            Boss clone = new Boss();
            clone.Set(foe);

            Assert.AreEqual(foe.Name, clone.Name);
            Assert.AreEqual(foe.Icon, clone.Icon);
            Assert.AreEqual(foe.Description, clone.Description);

            Slider hp = foe.Hp;

            Assert.AreEqual(hp.Minimum, clone.Hp.Minimum);
            Assert.AreEqual(hp.Current, clone.Hp.Current);
            Assert.AreEqual(hp.Max, clone.Hp.Max);

            Assert.AreEqual(foe.Stats, clone.Stats);
            Assert.AreEqual(foe.Action, clone.Action);

            Slider time = foe.StatusInfo[0].Time;
            Slider cloneTime = foe.StatusInfo[0].Time;

            Assert.AreEqual(time.Minimum, cloneTime.Minimum);
            Assert.AreEqual(time.Current, cloneTime.Current);
            Assert.AreEqual(time.Max, cloneTime.Max);

            Assert.AreEqual(foe.ID, clone.ID);
            Assert.AreEqual(foe.IsLearned, clone.IsLearned);
            Assert.AreEqual(foe.Death, clone.Death);
            Assert.AreEqual(foe.Size, clone.Size);
            Assert.AreEqual(foe.Experience, clone.Experience);
            Assert.AreEqual(foe.Drop, clone.Drop);
            Assert.AreEqual(foe.Strategy, clone.Strategy);
            Assert.AreEqual(foe.Theme, clone.Theme);
        }

        [TestMethod]
        public void CloneBossReturnBoss()
        {
            Boss foe = new Boss
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
                },
                ID = EnemyBestiary.Spider,
                IsLearned = true,
                Death = "Death",
                Size = new Position(3),
                Experience = 10,
                Drop = ItemsID.Bandage,
                Strategy = FightingMode.ATTACK,
                Theme = "Theme"
            };

            Boss clone = foe.Clone();

            Assert.AreEqual(foe.Name, clone.Name);
            Assert.AreEqual(foe.Icon, clone.Icon);
            Assert.AreEqual(foe.Description, clone.Description);

            Slider hp = foe.Hp;

            Assert.AreEqual(hp.Minimum, clone.Hp.Minimum);
            Assert.AreEqual(hp.Current, clone.Hp.Current);
            Assert.AreEqual(hp.Max, clone.Hp.Max);

            Assert.AreEqual(foe.Stats, clone.Stats);
            Assert.AreEqual(foe.Action, clone.Action);

            Slider time = foe.StatusInfo[0].Time;
            Slider cloneTime = foe.StatusInfo[0].Time;

            Assert.AreEqual(time.Minimum, cloneTime.Minimum);
            Assert.AreEqual(time.Current, cloneTime.Current);
            Assert.AreEqual(time.Max, cloneTime.Max);

            Assert.AreEqual(foe.ID, clone.ID);
            Assert.AreEqual(foe.IsLearned, clone.IsLearned);
            Assert.AreEqual(foe.Death, clone.Death);
            Assert.AreEqual(foe.Size, clone.Size);
            Assert.AreEqual(foe.Experience, clone.Experience);
            Assert.AreEqual(foe.Drop, clone.Drop);
            Assert.AreEqual(foe.Strategy, clone.Strategy);
            Assert.AreEqual(foe.Theme, clone.Theme);
        }
    }
}