using AdventOfCode.Day;

namespace AdventOfCode.Test.Day;

public class Day03Test
{
    [Fact]
    public void TestPartOne()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day03.txt");

        int expected = 181345830;
        int actual = Day03.PartOne(input);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestPartTwo()
    {
        using var input = InputUtility.ReadInput("AdventOfCode.Test.Inputs.Day03.txt");

        int expected = 98729041;
        int actual = Day03.PartTwo(input);

        Assert.Equal(expected, actual);
    }
}
