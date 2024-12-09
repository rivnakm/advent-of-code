using AdventOfCode.Day;
using FluentAssertions;

namespace AdventOfCode.Test.Day;

public class Day09Test
{
    [Fact]
    public void TestPartOne()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day09.txt");

        var expected = 6382875730645L;
        var actual = Day09.PartOne(input);

        actual.Should().Be(expected);
    }

    [Fact]
    public void TestPartTwo()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day09.txt");

        var expected = 6420913943576L;
        var actual = Day09.PartTwo(input);

        actual.Should().Be(expected);
    }
}
