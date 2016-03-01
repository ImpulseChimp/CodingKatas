using Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects_Christopher
{
    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        public void AnyReturnsFalseNoElementMatchesThePredicate()
        {
            var values = new[] { 1, 2, 3 };

            Assert.IsFalse(values.Any(v => v == 4));
        }

        [TestMethod]
        public void AnyReturnsTrueWhenAtLeastOneElementMatchesThePredicate()
        {
            var values = new[] { 1, 2, 3 };

            Assert.IsTrue(values.Any(v => v >= 3));
        }

        [TestMethod]
        public void AnyReturnsTrueWhenAllElementsMatchThePredicate()
        {
            var values = new[] { 1, 2, 3 };

            Assert.IsTrue(values.Any(v => v > 0));
        }
    }
}
