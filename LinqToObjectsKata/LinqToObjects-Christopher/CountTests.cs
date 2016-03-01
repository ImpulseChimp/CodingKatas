using Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects_Christopher
{
    [TestClass]
    public class CountTests
    {
        [TestMethod]
        public void CountReturnNumberOfElementsWhenNoPredicateIsDefined()
        {
            var values = new[] { 1, 2, 3 };

            Assert.AreEqual(3, values.Count());
        }

        [TestMethod]
        public void CountReturnNumberOfElementsThatMatchThePredicate()
        {
            var values = new[] { 1, 2, 3 };

            Assert.AreEqual(2, values.Count(v => v >= 2));
        }
    }
}
