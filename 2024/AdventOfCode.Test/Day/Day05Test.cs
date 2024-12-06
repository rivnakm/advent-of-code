using AdventOfCode.Day;
using FluentAssertions;

namespace AdventOfCode.Test.Day;

public class Day05Test
{
    [Fact]
    public void TestPartOne()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day05.txt");

        int expected = 5452;
        int actual = Day05.PartOne(input);

        actual.Should().Be(expected);
    }

    [Fact]
    public void TestPartTwo()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day05.txt");

        int expected = 4598;
        int actual = Day05.PartTwo(input);

        actual.Should().BeGreaterThan(4592);
        actual.Should().Be(expected);
    }
}
