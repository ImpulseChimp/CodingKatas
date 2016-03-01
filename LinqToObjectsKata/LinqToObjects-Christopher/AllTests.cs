using Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects_Christopher
{
    [TestClass]
    public class AllTests
    {
        [TestMethod]
        public void AllReturnsFalseWhenAtLeastOneElementDoesNotMatchThePredicate()
        {
            var values = new[] { 1, 2, 3 };

            Assert.IsFalse(values.All(v => v < 3));
        }

        [TestMethod]
        public void AllReturnsTrueWhenAllElementMatchThePredicate()
        {
            var values = new[] { 1, 2, 3 };

            Assert.IsTrue(values.All(v => v < 4));
        }
    }
}
