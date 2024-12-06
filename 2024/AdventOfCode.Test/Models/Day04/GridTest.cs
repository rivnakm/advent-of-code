using System.Collections.Immutable;
using AdventOfCode.Models.Day04;

namespace AdventOfCode.Test.Models.Day04;

public class GridTest
{
    [Theory]
    [InlineData(0, 1, true)]
    [InlineData(1, 0, true)]
    [InlineData(-1, 0, false)]
    [InlineData(0, -1, false)]
    [InlineData(0, 2, false)]
    [InlineData(2, 0, false)]
    public void TestIsInBounds(int x, int y, bool expected)
    {
        var gridArr = "ABCD".ToImmutableArray();
        var grid = new Grid(gridArr, 2, 2);

        var testPoint = new Point(x, y);

        var actual = grid.IsInBounds(testPoint);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 1, true, 'C')]
    [InlineData(1, 0, true, 'B')]
    [InlineData(-1, 0, false, default(char))]
    [InlineData(0, -1, false, default(char))]
    [InlineData(0, 2, false, default(char))]
    [InlineData(2, 0, false, default(char))]
    public void TestTryGetValue(int x, int y, bool expectedBool, char expectedValue)
    {
        var gridArr = "ABCD".ToImmutableArray();
        var grid = new Grid(gridArr, 2, 2);

        var testPoint = new Point(x, y);

        var actualBool = grid.TryGetValue(testPoint, out var actualValue);

        Assert.Equal(expectedBool, actualBool);
        Assert.Equal(expectedValue, actualValue);
    }
}
