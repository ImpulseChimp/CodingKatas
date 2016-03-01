using System;
using System.Collections.Generic;

namespace Linq
{
    public static partial class Linq
    {
        public static Int32 Count<TSource>(this IEnumerable<TSource> source)
        {
            return Count(source, (element) => true);
        }

        public static Int32 Count<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            var count = 0;
            foreach (var element in source)
                if (predicate(element)) count++;

            return count;
        }
    }
}
