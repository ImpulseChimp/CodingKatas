using System;
using System.Collections.Generic;

namespace Linq
{
    public static partial class Linq
    {
        public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, Int32 index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index");

            var i = 0;
            foreach (var element in source)
                if (index == i++)
                    return element;

            throw new ArgumentOutOfRangeException("index");
        }
    }
}
