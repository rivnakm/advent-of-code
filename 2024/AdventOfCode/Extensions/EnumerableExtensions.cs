using System;
using System.Collections.Generic;

namespace AdventOfCode.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<Tuple<T, K>> Permutations<T, K>(this IEnumerable<T> a, IEnumerable<K> b)
    {
        foreach (var itemA in a)
        {
            foreach (var itemB in b)
            {
                yield return new Tuple<T, K>(itemA, itemB);
            }
        }
    }
}
