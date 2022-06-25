using DesertRage.Model.Locations;
using DesertRage.Model.Locations.Battle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesertRage.Tests.Locations.Battle
{
    [TestClass]
    public class RangeTests
    {
        [TestMethod]
        public void BottomLeftRangeReturnZeroFourPosition()
        {
            Range range = new Range(new Position(0), new Position(5));

            Assert.AreEqual(new Position(0, 4), range.BottomLeft());
        }

        [TestMethod]
        public void TopRightRangeReturnFourZeroPosition()
        {
            Range range = new Range(new Position(0), new Position(5));

            Assert.AreEqual(new Position(4, 0), range.TopRight());
        }

        [TestMethod]
        public void SizeRangeReturnFivePosition()
        {
            Range range = new Range(new Position(0), new Position(5));

            Assert.AreEqual(new Position(5), range.Size());
        }

        [TestMethod]
        public void ToStringRangeReturnFiveZeroPosition()
        {
            Range range = new Range(new Position(0), new Position(5));

            Assert.AreEqual("{ 0:0, 4:4 }", range.ToString());
        }

        [TestMethod]
        public void IsOverflowRangeReturnTrue()
        {
            Range range = new Range(new Position(0), new Position(5));
            Range overflow = new Range(new Position(1), new Position(5));

            Assert.AreEqual(true, range.IsOverflow(overflow));
        }

        [TestMethod]
        public void IsOverflowRangeReturnFalse()
        {
            Range range = new Range(new Position(0), new Position(5));
            Range overflow = new Range(new Position(0), new Position(5));

            Assert.AreEqual(false, range.IsOverflow(overflow));
        }
    }
}