using DesertRage.Model.Locations.Battle.Stats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesertRage.Model.Locations.Battle.Stats.Player;

namespace DesertRage.Tests.Locations.Battle.Stats.Player
{
    [TestClass]
    public class SettingsTest
    {
        [TestMethod]
        public void SetSettingsReturnPreferences()
        {
            Settings item = new Settings
            {
                Name = "Name",
                Music = new Slider(100),
                Sound = new Slider(100),
                Noise = new Slider(100),
                Brightness = new Slider(1, 50, 100)
            };

            Settings clone = new Settings
            {
                Music = new Slider(),
                Sound = new Slider(),
                Noise = new Slider(),
                Brightness = new Slider()
            };
            clone.Set(item);

            Assert.AreEqual(item.Name, clone.Name);
        }
    }
}