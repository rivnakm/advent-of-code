using System;
using System.Collections.Immutable;
using AdventOfCode.Models.Common;
using FluentAssertions;

namespace AdventOfCode.Test.Models.Common;

public class GridTest
{
    [Fact]
    public void TestArrayConstructor_EmptyArray_Throws()
    {
        var arr = Array.Empty<char>();
        var create = () => new Grid(arr, 0, 0);

        create.Should().Throw<ArgumentException>();
    }

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

        actual.Should().Be(expected);
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

        actualBool.Should().Be(expectedBool);
        actualValue.Should().Be(expectedValue);
    }
}
