using System;
using System.Collections.Generic;

namespace Linq
{
    public static partial class Linq
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                    return false;
            }

            return true;
        }
    }
}
