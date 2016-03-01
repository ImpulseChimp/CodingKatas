using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToObjects_Christopher
{
    public class EnumerableAssert
    {
        public static void AssertContent<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.AreEqual(expected.Count(), actual.Count());

            for (var i = 0; i < expected.Count(); i++)
                Assert.AreEqual(expected.ElementAt(i), actual.ElementAt(i), String.Format("Element {0} does not match.", i));
        }
    }
}
