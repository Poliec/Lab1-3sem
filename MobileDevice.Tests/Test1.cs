using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewProject;

namespace MobileDevice.Tests
{
    [TestClass]
    public class SmartphoneTests
    {
        [TestMethod]
        public void Price_PositiveValue_ShouldBeSet()
        {
            var phone = new Smartphone();
            phone.Price = 500;

            Assert.AreEqual(500, phone.Price);
        }

        [TestMethod]
        public void Price_NegativeValue_ShouldBeIgnored()
        {
            var phone = new Smartphone();
            phone.Price = 500;
            phone.Price = -100;

            Assert.AreEqual(500, phone.Price);
        }

        [TestMethod]
        public void GetInfo_Smartphone_ShouldContainAllFields()
        {
            var phone = new Smartphone
            {
                Brand = "Samsung",
                Model = "Galaxy S24",
                Price = 800,
                RAM = 8,
                Battery = 5000
            };

            string info = phone.GetInfo();

            StringAssert.Contains(info, "Samsung");
            StringAssert.Contains(info, "RAM: 8");
            StringAssert.Contains(info, "Battery: 5000");
        }

        [TestMethod]
        public void Polymorphism_BaseTypeVariable_CallsOverriddenMethod()
        {
            NewProject.MobileDevice device = new Smartphone
            {
                Brand = "Apple",
                Model = "iPhone 15",
                Price = 999,
                RAM = 6,
                Battery = 3877
            };

            string info = device.GetInfo();

            // Если бы вызвалась базовая версия GetInfo(), в строке не было бы RAM/Battery
            StringAssert.Contains(info, "RAM");
            StringAssert.Contains(info, "Battery");
        }
    }

}