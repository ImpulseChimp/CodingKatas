using Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects_Christopher
{
    [TestClass]
    public class ElementAtTests
    {
        [TestMethod]
        public void ElementAtReturnsElementAtTheSpecifiedIndex()
        {
            var values = new[] { 1, 2, 3 };

            Assert.AreEqual(2, values.ElementAt(1));
        }
    }
}
