using System;
using System.Collections.Generic;

namespace Linq
{
    public static partial class Linq
    {
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return Except(first, second, EqualityComparer<TSource>.Default);
        }

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            var secondHash = new HashSet<TSource>(second);

            foreach (var element in first)
                if (!secondHash.Contains(element))
                    yield return element;
        }
    }
}