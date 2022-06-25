using DesertRage.Model.Locations.Battle.Stats;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesertRage.Tests.Locations.Battle.Stats
{
    [TestClass]
    public class SliderTests
    {
        [TestMethod]
        public void ToStringSliderReturnFiveNineAndZero()
        {
            Slider bar = new Slider(0, 5, 9);

            Assert.AreEqual("5 / 9 (0 - 9)", bar.ToString());
        }

        [TestMethod]
        public void DrainSliderReturnZero()
        {
            Slider bar = new Slider(0, 5, 9);
            bar.Drain();

            Assert.AreEqual(0, bar.Current);
        }

        [TestMethod]
        public void DrainIntSliderReturnFour()
        {
            Slider bar = new Slider(0, 5, 9);
            bar.Drain(1);

            Assert.AreEqual(4, bar.Current);
        }

        [TestMethod]
        public void FillSliderReturnNine()
        {
            Slider bar = new Slider(0, 5, 9);
            bar.Fill();

            Assert.AreEqual(9, bar.Current);
        }

        [TestMethod]
        public void FillIntSliderReturnSix()
        {
            Slider bar = new Slider(0, 5, 9);
            bar.Fill(1);

            Assert.AreEqual(6, bar.Current);
        }

        [TestMethod]
        public void SetSliderReturnZeroFiveNine()
        {
            Slider bar = new Slider();
            Slider clone = new Slider(0, 5, 9);

            bar.Set(clone);

            Assert.AreEqual(clone.Minimum, bar.Minimum);
            Assert.AreEqual(clone.Current, bar.Current);
            Assert.AreEqual(clone.Max, bar.Max);
        }
    }
}