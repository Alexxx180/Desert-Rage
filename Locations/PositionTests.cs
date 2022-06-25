using DesertRage.Model.Locations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesertRage.Tests.Locations
{
    [TestClass]
    public class PositionTests
    {
        /// <summary>
        /// Emty map sample
        /// </summary>
        /// <returns>3 x 5 game field</returns>
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
        public void IsOverflowPositionReturnTrue()
        {
            Position tile = new Position(5, 3);

            Assert.AreEqual(true, tile.IsOverflow(0, TestMap()));
        }

        [TestMethod]
        public void IsOverflowPositionReturnFalse()
        {
            Position tile = new Position(4, 2);

            Assert.AreEqual(false, tile.IsOverflow(0, TestMap()));
        }

        [TestMethod]
        public void IsOutTopPositionReturnTrue()
        {
            Position tile = new Position(3, 5);

            Assert.AreEqual(true, tile.IsOutTop(new Position(4, 5)));
            Assert.AreEqual(true, tile.IsOutTop(new Position(3, 6)));
            Assert.AreEqual(true, tile.IsOutTop(new Position(4, 6)));
        }

        [TestMethod]
        public void IsOutTopPositionReturnFalse()
        {
            Position tile = new Position(3, 5);

            Assert.AreEqual(false, tile.IsOutTop(new Position(3, 5)));
            Assert.AreEqual(false, tile.IsOutTop(new Position(2, 5)));
            Assert.AreEqual(false, tile.IsOutTop(new Position(3, 4)));
            Assert.AreEqual(false, tile.IsOutTop(new Position(2, 4)));
        }

        [TestMethod]
        public void IsOutBottomPositionReturnTrue()
        {
            Position tile = new Position(3, 5);
            
            Assert.AreEqual(true, tile.IsOutBottom(new Position(2, 5)));
            Assert.AreEqual(true, tile.IsOutBottom(new Position(3, 4)));
            Assert.AreEqual(true, tile.IsOutBottom(new Position(2, 4)));
        }

        [TestMethod]
        public void IsOutBottomPositionReturnFalse()
        {
            Position tile = new Position(3, 5);

            Assert.AreEqual(false, tile.IsOutBottom(new Position(3, 5)));
            Assert.AreEqual(false, tile.IsOutBottom(new Position(4, 5)));
            Assert.AreEqual(false, tile.IsOutBottom(new Position(3, 6)));
            Assert.AreEqual(false, tile.IsOutBottom(new Position(4, 6)));
        }

        [TestMethod]
        public void PositionIntAddictionReturnFiveAndSeven()
        {
            Position tile = new Position(3, 5);

            Position result = tile + 2;

            Assert.AreEqual(5, result.X);
            Assert.AreEqual(7, result.Y);
        }

        [TestMethod]
        public void PositionAddictionReturnFiveAndSeven()
        {
            Position tile = new Position(3, 5);

            Position result = tile + new Position(2, 2);

            Assert.AreEqual(5, result.X);
            Assert.AreEqual(7, result.Y);
        }

        [TestMethod]
        public void PositionIntSubtractionReturnOneAndThree()
        {
            Position tile = new Position(3, 5);

            Position result = tile - 2;

            Assert.AreEqual(1, result.X);
            Assert.AreEqual(3, result.Y);
        }

        [TestMethod]
        public void PositionSubtractionReturnOneAndThree()
        {
            Position tile = new Position(3, 5);

            Position result = tile - new Position(2, 2);

            Assert.AreEqual(1, result.X);
            Assert.AreEqual(3, result.Y);
        }

        [TestMethod]
        public void LessOrEqualPositionReturnTrue()
        {
            Position tile = new Position(3, 5);
            Position less = new Position(3, 5);

            bool expected = less.X <= tile.X;
            expected &= less.Y <= tile.Y;

            Assert.AreEqual(expected, less <= tile);
        }

        [TestMethod]
        public void LessOrEqualPositionReturnFalse()
        {
            Position tile = new Position(3, 5);
            Position less = new Position(5, 7);

            bool expected = less.X <= tile.X;
            expected &= less.Y <= tile.Y;

            Assert.AreEqual(expected, less <= tile);
        }

        [TestMethod]
        public void MoreOrEqualPositionReturnTrue()
        {
            Position tile = new Position(3, 5);
            Position more = new Position(3, 5);

            bool expected = more.X >= tile.X;
            expected &= more.Y >= tile.Y;

            Assert.AreEqual(expected, more >= tile);
        }

        [TestMethod]
        public void MoreOrEqualPositionReturnFalse()
        {
            Position tile = new Position(3, 5);
            Position more = new Position(2, 4);

            bool expected = more.X >= tile.X;
            expected &= more.Y >= tile.Y;

            Assert.AreEqual(expected, more >= tile);
        }

        [TestMethod]
        public void LessPositionReturnTrue()
        {
            Position tile = new Position(3, 5);
            Position less = new Position(2, 4);

            bool expected = less.X < tile.X;
            expected &= less.Y < tile.Y;

            Assert.AreEqual(expected, less < tile);
        }

        [TestMethod]
        public void LessPositionReturnFalse()
        {
            Position tile = new Position(3, 5);
            Position less = new Position(5, 7);

            bool expected = less.X < tile.X;
            expected &= less.Y < tile.Y;

            Assert.AreEqual(expected, less < tile);
        }

        [TestMethod]
        public void MorePositionReturnTrue()
        {
            Position tile = new Position(3, 5);
            Position more = new Position(5, 7);

            bool expected = more.X > tile.X;
            expected &= more.Y > tile.Y;

            Assert.AreEqual(expected, more > tile);
        }

        [TestMethod]
        public void MorePositionReturnFalse()
        {
            Position tile = new Position(3, 5);
            Position more = new Position(2, 4);

            bool expected = more.X > tile.X;
            expected &= more.Y > tile.Y;

            Assert.AreEqual(expected, more > tile);
        }

        [TestMethod]
        public void ToStringPositionReturnFiveAndThree()
        {
            Position tile = new Position(5, 3);

            Assert.AreEqual("5:3", tile.ToString());
        }
    }
}