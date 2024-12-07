using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Extensions;
using FluentAssertions;

namespace AdventOfCode.Test.Extensions;

public class SetExtensionsTest
{
    [Fact]
    public void TestCombination()
    {
        var set = new HashSet<int> { 1, 2 };

        var expected = new List<List<int>> {
            new List<int> { 1, 1},
            new List<int> { 1, 2},
            new List<int> { 2, 1},
            new List<int> { 2, 2}
        };

        var actual = set.Combinations(2);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void TestCombinations_SizeZero_ReturnsEmpty()
    {
        var set = new HashSet<int> { 1, 2, 3 };

        var result = set.Combinations(0);

        result.Should().BeEmpty();
    }

    [Fact]
    public void TestCombinations_NegativeSize_Throws()
    {
        var set = new HashSet<int>();

        var combinations = () => set.Combinations(-1).ToList();

        combinations.Should().Throw<ArgumentOutOfRangeException>();
    }
}
