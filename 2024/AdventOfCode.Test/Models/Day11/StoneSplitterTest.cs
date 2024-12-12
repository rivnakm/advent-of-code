using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Models.Day11;
using FluentAssertions;

namespace AdventOfCode.Test.Models.Day11;

public class StoneSplitterTest
{
    public static IEnumerable<object[]> SplitStonesCases = new List<object[]>
    {
        new object [] { new List<long> { 0, 1, 10, 99, 999 }, new List<long> { 1, 2024, 1, 0, 9, 9, 2021976 } },
        new object [] { new List<long> { 125, 17 }, new List<long> { 253000, 1, 7 } },
        new object [] { new List<long> { 253000, 1, 7 }, new List<long> { 253, 0, 2024, 14168 } },
        new object [] { new List<long> { 253, 0, 2024, 14168 }, new List<long> { 512072, 1, 20, 24, 28676032 } },
        new object [] { new List<long> { 512072, 1, 20, 24, 28676032 }, new List<long> { 512, 72, 2024, 2, 0, 2, 4, 2867, 6032 } },
        new object [] { new List<long> { 512, 72, 2024, 2, 0, 2, 4, 2867, 6032 }, new List<long> { 1036288, 7, 2, 20, 24, 4048, 1, 4048, 8096, 28, 67, 60, 32} },
        new object [] { new List<long> { 1036288, 7, 2, 20, 24, 4048, 1, 4048, 8096, 28, 67, 60, 32}, new List<long> { 2097446912, 14168, 4048, 2, 0, 2, 4, 40, 48, 2024, 40, 48, 80, 96, 2, 8, 6, 7, 6, 0, 3, 2 }, },
    };

    [Theory]
    [MemberData(nameof(SplitStonesCases))]
    public void TestSplitStones(IList<long> before, IList<long> after)
    {
        var actual = StoneSplitter.SplitStones(before);

        actual.Should().Equal(after);
    }

    [Theory]
    [MemberData(nameof(SplitStonesCases))]
    public void TestRunNSplits(IList<long> before, IList<long> after)
    {
        var splitter = new StoneSplitter();
        var count = before.Select(s => splitter.RunNSplits(s, 1)).Sum();

        count.Should().Be(after.Count());
    }
}
