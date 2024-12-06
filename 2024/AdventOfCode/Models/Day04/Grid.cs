using System.Collections.Generic;
using System.Collections.Immutable;

namespace AdventOfCode.Models.Day04;

public class Grid(ImmutableArray<char> grid, int rows, int cols)
{
    public IEnumerable<Point> Points()
    {
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                yield return new Point(j, i);
            }
        }
    }

    public bool TryGetValue(Point point, out char value)
    {
        if (IsInBounds(point))
        {
            value = grid[point.X + point.Y * cols];
            return true;
        }

        value = default(char);
        return false;

    }

    public bool IsInBounds(Point point)
    {
        return point.X >= 0 && point.X < cols &&
            point.Y >= 0 && point.Y < rows;
    }
}
