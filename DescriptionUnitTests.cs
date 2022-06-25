using DesertRage.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesertRage.Tests
{
    [TestClass]
    public class DescriptionUnitTests
    {
        [TestMethod]
        public void SetDescriptionUnitReturnItem()
        {
            DescriptionUnit item = new DescriptionUnit
            {
                Name = "Name",
                Icon = "Icon",
                Description = "Description"
            };

            DescriptionUnit clone = new DescriptionUnit();
            clone.Set(item);

            Assert.AreEqual(item.Name, clone.Name);
            Assert.AreEqual(item.Icon, clone.Icon);
            Assert.AreEqual(item.Description, clone.Description);
        }

        [TestMethod]
        public void CloneDescriptionUnitReturnItem()
        {
            DescriptionUnit item = new DescriptionUnit
            {
                Name = "Name",
                Icon = "Icon",
                Description = "Description"
            };

            DescriptionUnit clone = item.Clone();

            Assert.AreEqual(item.Name, clone.Name);
            Assert.AreEqual(item.Icon, clone.Icon);
            Assert.AreEqual(item.Description, clone.Description);
        }
    }
}
