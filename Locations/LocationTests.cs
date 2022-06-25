using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle.Stats.Enemy.Storage;
using DesertRage.Model.Locations.Battle.Stats.Player.Armory;
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
            Location current = new Location();

            Location next = new Location
            {
                Name = "Name",
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
                Messages = new Dictionary<string, string>
                {
                    { "2:0", "Message" }
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

            current.SetChapter(next);

            Assert.AreEqual(next.Name, current.Name);
            Assert.AreEqual(next.NextChapter, current.NextChapter);
            Assert.AreEqual(next.Map, current.Map);
            Assert.AreEqual(next.BackCover, current.BackCover);
            Assert.AreEqual(next.BattleBack, current.BattleBack);
            Assert.AreEqual(next.MusicPeace, current.MusicPeace);
            Assert.AreEqual(next.MusicFight, current.MusicFight);
            Assert.AreEqual(next.Start, current.Start);
            Assert.AreEqual(next.Danger.X, current.Danger.X);
            Assert.AreEqual(next.Danger.Y, current.Danger.Y);
            Assert.AreEqual(next.StageFoes[0], current.StageFoes[0]);
            Assert.AreEqual(next.Bosses["1:0"], current.Bosses["1:0"]);
            Assert.AreEqual(next.Messages["2:0"], current.Messages["2:0"]);
            Assert.AreEqual(next.Gates["3:0"], current.Gates["3:0"]);
            Assert.AreEqual(next.Warps["4:0"], current.Warps["4:0"]);
            Assert.AreEqual(next.Equipment["5:0"], current.Equipment["5:0"]);
            Assert.AreEqual(next.TileCodes["."], current.TileCodes["."]);
            Assert.AreEqual(next.IsTimeChamber, current.IsTimeChamber);
        }
    }
}