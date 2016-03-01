using System;
using Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects_Christopher
{
    [TestClass]
    public class ExceptTests
    {
        [TestMethod]
        public void ElementInFirstAndNotSecondIsReturned()
        {
            var first = new[] { 1, 2, 3, 4, 5, 6 };
            var second = new[] { 1, 2, 3, 4, 5 };
            var result = first.Except(second);
            var expected = new[] { 6 };

            EnumerableAssert.AssertContent(expected, result);
        }

        [TestMethod]
        public void ElementInSecondAndNotInFirstIsNotReturned()
        {
            var first = new[] { 1, 2, 3, 4, 5, 7 };
            var second = new[] { 1, 2, 3, 4, 5, 6 };
            var result = first.Except(second);
            var expected = new[] { 7 };

            EnumerableAssert.AssertContent(expected, result);
        }
    }
}
