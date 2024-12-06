using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Extensions;
using FluentAssertions;

namespace AdventOfCode.Test.Extensions;

public class EnumerableExtensionsTest
{
    [Fact]
    public void TestPermutations()
    {
        var a = new List<char> { 'A', 'B', 'C' };
        var b = new List<int> { 1, 2 };

        var expected = new List<Tuple<char, int>> {
            new Tuple<char, int>('A', 1),
            new Tuple<char, int>('A', 2),
            new Tuple<char, int>('B', 1),
            new Tuple<char, int>('B', 2),
            new Tuple<char, int>('C', 1),
            new Tuple<char, int>('C', 2),
        };

        var actual = a.Permutations(b).ToList();

        actual.Should().Equal(expected);
    }
}
