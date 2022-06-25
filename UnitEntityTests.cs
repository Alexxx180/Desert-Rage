using DesertRage.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesertRageTests
{
    [TestClass]
    public class UnitEntityTests
    {
        [TestMethod]
        public void SetUnitReturnItem()
        {
            Unit item = new Unit
            {
                Name = "Name"
            };

            Unit clone = new Unit();
            clone.Set(item);

            Assert.AreEqual(item.Name, clone.Name);
        }

        [TestMethod]
        public void CloneUnitReturnItem()
        {
            Unit item = new Unit
            {
                Name = "Name"
            };

            Unit clone = item.Clone();

            Assert.AreEqual(item.Name, clone.Name);
        }
    }
}