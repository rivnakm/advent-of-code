using AdventOfCode.Day;

namespace AdventOfCode.Test.Day;

public class Day02Test
{
    [Fact]
    public void TestPartOne()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day02.txt");

        int expected = 472;
        int actual = Day02.PartOne(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestPartTwo()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day02.txt");

        int expected = 520;
        int actual = Day02.PartTwo(input);

        Assert.Equal(expected, actual);
    }
}
