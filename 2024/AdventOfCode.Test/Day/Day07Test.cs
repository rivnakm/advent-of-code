using AdventOfCode.Day;
using FluentAssertions;

namespace AdventOfCode.Test.Day;

public class Day07Test
{
    [Fact]
    public void TestPartOne()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day07.txt");

        var expected = 945512582195L;
        var actual = Day07.PartOne(input);

        actual.Should().Be(expected);
    }

    [Fact]
    public void TestPartTwo()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day07.txt");

        var expected = 271691107779347L;
        var actual = Day07.PartTwo(input);

        actual.Should().Be(expected);
    }
}
