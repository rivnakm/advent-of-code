using AdventOfCode.Day;
using FluentAssertions;

namespace AdventOfCode.Test.Day;

public class Day04Test
{
    [Fact]
    public void TestPartOne()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day04.txt");

        int expected = 2401;
        int actual = Day04.PartOne(input);

        actual.Should().Be(expected);
    }

    [Fact]
    public void TestPartTwo()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day04.txt");

        int expected = 1822;
        int actual = Day04.PartTwo(input);

        actual.Should().Be(expected);
    }
}
