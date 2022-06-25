using DesertRage.Model.Locations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesertRage.Tests.Locations
{
    [TestClass]
    public class ChipTests
    {
        private char[][] TestMap()
        {
            return new char[][]
            {
                ".....".ToCharArray(),
                ".....".ToCharArray(),
                ".....".ToCharArray(),
            };
        }

        [TestMethod]
        public void IsOverflowChipReturnTrue()
        {
            Chip tile = new Chip(5, 3);

            Assert.AreEqual(true, tile.IsOverflow(0, TestMap()));
        }

        [TestMethod]
        public void IsOverflowChipReturnFalse()
        {
            Chip tile = new Chip(4, 2);

            Assert.AreEqual(false, tile.IsOverflow(0, TestMap()));
        }

        [TestMethod]
        public void IsOutTopChipReturnTrue()
        {
            Chip tile = new Chip(3, 5);

            Assert.AreEqual(true, tile.IsOutTop(new Chip(4, 5)));
            Assert.AreEqual(true, tile.IsOutTop(new Chip(3, 6)));
            Assert.AreEqual(true, tile.IsOutTop(new Chip(4, 6)));
        }

        [TestMethod]
        public void IsOutTopChipReturnFalse()
        {
            Chip tile = new Chip(3, 5);

            Assert.AreEqual(false, tile.IsOutTop(new Chip(3, 5)));
            Assert.AreEqual(false, tile.IsOutTop(new Chip(2, 5)));
            Assert.AreEqual(false, tile.IsOutTop(new Chip(3, 4)));
            Assert.AreEqual(false, tile.IsOutTop(new Chip(2, 4)));
        }

        [TestMethod]
        public void IsOutBottomChipReturnTrue()
        {
            Chip tile = new Chip(3, 5);

            Assert.AreEqual(true, tile.IsOutBottom(new Chip(2, 5)));
            Assert.AreEqual(true, tile.IsOutBottom(new Chip(3, 4)));
            Assert.AreEqual(true, tile.IsOutBottom(new Chip(2, 4)));
        }

        [TestMethod]
        public void IsOutBottomChipReturnFalse()
        {
            Chip tile = new Chip(3, 5);

            Assert.AreEqual(false, tile.IsOutBottom(new Chip(3, 5)));
            Assert.AreEqual(false, tile.IsOutBottom(new Chip(4, 5)));
            Assert.AreEqual(false, tile.IsOutBottom(new Chip(3, 6)));
            Assert.AreEqual(false, tile.IsOutBottom(new Chip(4, 6)));
        }

        [TestMethod]
        public void IsZeroChipReturnTrue()
        {
            Chip tile = new Chip(0, 0);

            Assert.AreEqual(true, tile.IsZero);
        }

        [TestMethod]
        public void IsZeroChipReturnFalse()
        {
            Chip tile = new Chip(1, 0);

            Assert.AreEqual(false, tile.IsZero);
        }

        [TestMethod]
        public void CountdownChipReturnZeroMinFiftyNineSeconds()
        {
            Chip tile = new Chip(1, 0);

            tile.Countdown();

            Assert.AreEqual(0, tile.X);
            Assert.AreEqual(59, tile.Y);
        }

        [TestMethod]
        public void CountdownChipReturnZeroMinThreeSeconds()
        {
            Chip tile = new Chip(0, 4);

            tile.Countdown();

            Assert.AreEqual(0, tile.X);
            Assert.AreEqual(3, tile.Y);
        }

        [TestMethod]
        public void ToStringChipReturnFiveAndThree()
        {
            Chip tile = new Chip(5, 3);

            Assert.AreEqual("5:3", tile.ToString());
        }
    }
}