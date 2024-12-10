using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Models.Common;

namespace AdventOfCode.Models.Day10;

public class TrailMap : Grid
{
    public TrailMap(IList<IList<char>> grid) : base(grid)
    {
    }

    public TrailMap(IList<char> grid, int rows, int cols) : base(grid, rows, cols)
    {
    }

    public int TraceTrails()
    {
        var trailHeads = this.Points().Where(p => this.Get(p) == '0').ToHashSet();
        var trailEnds = this.Points().Where(p => this.Get(p) == '9').ToHashSet();

        var directions = new List<Direction> {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
        };

        var score = 0;

        foreach (var trailHead in trailHeads)
        {
            var visited = new HashSet<Point>();
            var stack = new Stack<Point>();

            stack.Push(trailHead);
            while (stack.Count() > 0)
            {
                var point = stack.Pop();

                if (trailEnds.Contains(point) && !visited.Contains(point))
                {
                    score++;
                    visited.Add(point);
                }

                foreach (var direction in directions)
                {
                    var nextLevel = (char)(this.Get(point) + 1);
                    var nextPoint = point.Adjacent(direction);

                    if (TryGetValue(nextPoint, out var value) && value == nextLevel)
                    {
                        stack.Push(nextPoint);
                    }
                }
            }
        }

        return score;
    }

    public int RateTrails()
    {
        var trailHeads = this.Points().Where(p => this.Get(p) == '0').ToHashSet();
        var trailEnds = this.Points().Where(p => this.Get(p) == '9').ToHashSet();

        var directions = new List<Direction> {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
        };

        var rating = 0;

        foreach (var trailHead in trailHeads)
        {
            var visited = new HashSet<Point>();
            var stack = new Stack<Point>();

            stack.Push(trailHead);
            while (stack.Count() > 0)
            {
                var point = stack.Pop();

                if (trailEnds.Contains(point))
                {
                    rating++;
                    visited.Add(point);
                }

                foreach (var direction in directions)
                {
                    var nextLevel = (char)(this.Get(point) + 1);
                    var nextPoint = point.Adjacent(direction);

                    if (TryGetValue(nextPoint, out var value) && value == nextLevel)
                    {
                        stack.Push(nextPoint);
                    }
                }
            }
        }

        return rating;
    }
}
