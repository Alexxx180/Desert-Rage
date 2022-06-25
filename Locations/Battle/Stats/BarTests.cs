using DesertRage.Model.Locations.Battle.Stats;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesertRage.Tests.Locations.Battle.Stats
{
    [TestClass]
    public class BarTests
    {
        [TestMethod]
        public void ToStringBarReturnFiveNineAndZero()
        {
            Bar bar = new Bar(0, 5, 9);

            Assert.AreEqual("5 / 9 (0 - 9)", bar.ToString());
        }
    }
}