using AdventOfCode.Models.Common;
using FluentAssertions;

namespace AdventOfCode.Test.Models.Common;

public class PointTest
{
    [Theory]
    [InlineData(0, 0, 1, 2, 1, 2)]
    [InlineData(-1, -2, 1, 2, 0, 0)]
    public void TestAdd(int aX, int aY, int bX, int bY, int cX, int cY)
    {
        var a = new Point(aX, aY);
        var b = new Point(bX, bY);
        var c = new Point(cX, cY);

        var result = a + b;

        result.Should().Be(c);
    }

    [Theory]
    [InlineData(1, 2, 1, 2, 0, 0)]
    [InlineData(1, 2, -1, -2, 2, 4)]
    public void TestSubtract(int aX, int aY, int bX, int bY, int cX, int cY)
    {
        var a = new Point(aX, aY);
        var b = new Point(bX, bY);
        var c = new Point(cX, cY);

        var result = a - b;

        result.Should().Be(c);
    }
}
