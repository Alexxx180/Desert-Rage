using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
using DesertRage.Model.Locations.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DesertRage.Tests.Locations
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void SetChapterLocationReturnChapter()
        {
            Location current = new Location
            {
                Area = new Floor()
            };

            Floor floor = new Floor
            {
                NextChapter = "NextChapter",
                Map = new char[][] { "...".ToCharArray() },
                BackCover = "BackCover",
                BattleBack = "BattleBack",
                MusicPeace = "MusicPeace",
                MusicFight = "MusicFight",
                Start = new Position(5, 3),
                Danger = new Chip(2, 6),
                StageFoes = new EnemyBestiary[] { EnemyBestiary.Spider },
                Bosses = new Dictionary<string, EnemyBestiary>
                {
                    { "1:0", EnemyBestiary.Pharaoh }
                },
                Gates = new Dictionary<string, Position>
                {
                    { "3:0", new Position(1, 1) }
                },
                Warps = new Dictionary<string, Position>
                {
                    { "4:0", new Position(1, 2) }
                },
                Equipment = new Dictionary<string, ArmoryElement>
                {
                    { "5:0", new ArmoryElement(ArmoryKind.Hands, Sets.EMPTY) }
                },
                TileCodes = new Dictionary<string, string>
                {
                    { ".", "Path to image" }
                },
                IsTimeChamber = true,
            };

            Location next = new Location
            {
                Name = "Name",
                Area = floor,
                Messages = new Dictionary<string, string>
                {
                    { "2:0", "Message" }
                }
            };

            current.Set(next);

            Assert.AreEqual(next.Name, current.Name);
            Assert.AreEqual(next.Area.NextChapter, current.Area.NextChapter);
            Assert.AreEqual(next.Area.Map, current.Area.Map);
            Assert.AreEqual(next.Area.BackCover, current.Area.BackCover);
            Assert.AreEqual(next.Area.BattleBack, current.Area.BattleBack);
            Assert.AreEqual(next.Area.MusicPeace, current.Area.MusicPeace);
            Assert.AreEqual(next.Area.MusicFight, current.Area.MusicFight);
            Assert.AreEqual(next.Area.Start, current.Area.Start);
            Assert.AreEqual(next.Area.Danger.X, current.Area.Danger.X);
            Assert.AreEqual(next.Area.Danger.Y, current.Area.Danger.Y);
            Assert.AreEqual(next.Area.StageFoes[0], current.Area.StageFoes[0]);
            Assert.AreEqual(next.Area.Bosses["1:0"], current.Area.Bosses["1:0"]);
            Assert.AreEqual(next.Messages["2:0"], current.Messages["2:0"]);
            Assert.AreEqual(next.Area.Gates["3:0"], current.Area.Gates["3:0"]);
            Assert.AreEqual(next.Area.Warps["4:0"], current.Area.Warps["4:0"]);
            Assert.AreEqual(next.Area.Equipment["5:0"], current.Area.Equipment["5:0"]);
            Assert.AreEqual(next.Area.TileCodes["."], current.Area.TileCodes["."]);
            Assert.AreEqual(next.Area.IsTimeChamber, current.Area.IsTimeChamber);
        }
    }
}