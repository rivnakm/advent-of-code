using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode.Models.Common;

public class Grid
{
    protected ImmutableArray<char> _grid;
    protected int _rows;
    protected int _cols;

    public Grid(ImmutableArray<char> grid, int rows, int cols)
    {
        if (grid.Length == 0 || rows == 0 || cols == 0)
        {
            throw new ArgumentException("Cannot create grid from empty matrix");
        }
        this._grid = grid;
        this._rows = rows;
        this._cols = cols;
    }

    public Grid(IList<char> grid, int rows, int cols) : this(grid.ToImmutableArray(), rows, cols)
    {
    }

    public Grid(IList<IList<char>> grid)
    {
        if (grid.Count == 0 || grid[0].Count == 0)
        {
            throw new ArgumentException("Cannot create grid from empty matrix");
        }
        if (grid.Select(row => row.Count).Distinct().Count() > 1)
        {
            throw new ArgumentException("Cannot create grid from jagged matrix");
        }

        this._rows = grid.Count;
        this._cols = grid[0].Count;
        this._grid = grid.SelectMany(row => row).ToImmutableArray();
    }

    public IEnumerable<Point> Points()
    {
        for (var i = 0; i < _rows; i++)
        {
            for (var j = 0; j < _cols; j++)
            {
                yield return new Point(j, i);
            }
        }
    }

    public char Get(Point point)
    {
        if (!TryGetValue(point, out var value))
        {
            throw new ArgumentOutOfRangeException(nameof(point));
        }

        return value;
    }

    public bool TryGetValue(Point point, out char value)
    {
        if (IsInBounds(point))
        {
            value = _grid[point.X + point.Y * _cols];
            return true;
        }

        value = default(char);
        return false;

    }

    public bool IsInBounds(Point point)
    {
        return point.X >= 0 && point.X < _cols &&
            point.Y >= 0 && point.Y < _rows;
    }
}
