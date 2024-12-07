using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Extensions;

public static class SetExtensions
{
    public static IEnumerable<IEnumerable<T>> Combinations<T>(this ISet<T> set, int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), n, "Size cannot be less than zero");
        }

        if (n == 0)
        {
            yield break;
        }
        if (n == 1)
        {
            foreach (var item in set)
            {
                yield return new List<T> { item };
            }
            yield break;
        }

        var result = set.SelectMany(item => set.Combinations(n - 1).Select(c => c.Append(item)));

        foreach (var item in result)
        {
            yield return item;
        }
    }
}
