using AdventOfCode.Day;
using FluentAssertions;

namespace AdventOfCode.Test.Day;

public class Day06Test
{
    [Fact]
    public void TestPartOne()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day06.txt");

        int expected = 5453;
        int actual = Day06.PartOne(input);

        actual.Should().Be(expected);
    }

    [Fact]
    public void TestPartTwo()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day06.txt");

        int expected = 2188;
        int actual = Day06.PartTwo(input);

        actual.Should().Be(expected);
    }
}
