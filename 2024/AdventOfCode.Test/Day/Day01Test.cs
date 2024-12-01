using AdventOfCode.Day;

namespace AdventOfCode.Test.Day;

public class Day01Test
{
    [Fact]
    public void TestPartOne()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day01.txt");

        int expected = 2000468;
        int actual = Day01.PartOne(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestPartTwo()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day01.txt");

        int expected = 18567089;
        int actual = Day01.PartTwo(input);

        Assert.Equal(expected, actual);
    }
}
