using AdventOfCode.Day;
using FluentAssertions;

namespace AdventOfCode.Test.Day;

public class Day11Test
{
    [Fact]
    public void TestPartOne()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day11.txt");

        var expected = 183620;
        var actual = Day11.PartOne(input);

        actual.Should().Be(expected);
    }

    [Fact]
    public void TestPartTwo()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day11.txt");

        var expected = 220377651399268L;
        var actual = Day11.PartTwo(input);

        actual.Should().Be(expected);
    }
}
