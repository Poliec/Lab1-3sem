using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewProject;

namespace MobileDevice.Tests
{
    [TestClass]
    public class EBookTests
    {
        [TestMethod]
        public void Storage_PositiveValue_ShouldBeSet()
        {
            var book = new EBook();
            book.Storage = 32;

            Assert.AreEqual(32, book.Storage);
        }

        [TestMethod]
        public void Storage_NegativeValue_ShouldBeIgnored()
        {
            var book = new EBook();
            book.Storage = 32;
            book.Storage = -10;

            Assert.AreEqual(32, book.Storage);
        }
    }
}