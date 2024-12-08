using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using AdventOfCode.Models.Common;

namespace AdventOfCode.Models.Day06;

public class GuardMap : Grid
{
    private Point _guardPosition;
    private Direction _guardFacing;

    private readonly Point _originalGuardPosition;
    private readonly Direction _originalGuardFacing;

    public GuardMap(IList<IList<char>> grid) : base(grid)
    {
        var (guardPosition, guardFacing) = this.FindGuard();
        this._guardPosition = guardPosition;
        this._guardFacing = guardFacing;
        this._originalGuardPosition = guardPosition;
        this._originalGuardFacing = guardFacing;
    }

    public GuardMap(IList<char> grid, int rows, int cols) : base(grid, rows, cols)
    {
        var (guardPosition, guardFacing) = this.FindGuard();
        this._guardPosition = guardPosition;
        this._guardFacing = guardFacing;
        this._originalGuardPosition = guardPosition;
        this._originalGuardFacing = guardFacing;
    }

    private Tuple<Point, Direction> FindGuard()
    {
        var guardChars = new HashSet<char> { '^', 'v', '<', '>' }.ToImmutableHashSet();

        foreach (var point in this.Points())
        {
            var ch = this.Get(point);
            if (guardChars.Contains(ch))
            {
                switch (ch)
                {
                    case '^':
                        return new Tuple<Point, Direction>(point, Direction.North);
                    case 'v':
                        return new Tuple<Point, Direction>(point, Direction.South);
                    case '<':
                        return new Tuple<Point, Direction>(point, Direction.West);
                    case '>':
                        return new Tuple<Point, Direction>(point, Direction.East);
                }
            }
        }

        throw new InvalidOperationException("Could not find guard in map");
    }

    private void Reset()
    {
        this._guardPosition = this._originalGuardPosition;
        this._guardFacing = this._originalGuardFacing;
    }

    public IEnumerable<Point> GuardPoints()
    {
        while (IsInBounds(_guardPosition))
        {
            yield return this._guardPosition;

            while (HitObstacle())
            {
                TurnRight();
            }
            Advance();
        }
        this.Reset();
    }

    public bool NewObstacleCausesLoop(Point newObstacle)
    {
        // overlaps with the guard, they would notice
        if (newObstacle == this._originalGuardPosition)
        {
            return false;
        }
        // overlaps with existing obstacle, won't cause a loop
        if (this.TryGetValue(newObstacle, out var value) && value == '#')
        {
            return false;
        }

        var moveRecord = new HashSet<Tuple<Point, Direction>>();

        while (IsInBounds(_guardPosition))
        {
            while (this._guardPosition.Adjacent(this._guardFacing) == newObstacle || HitObstacle())
            {
                TurnRight();
            }
            this.Advance();

            var tuple = new Tuple<Point, Direction>(this._guardPosition, this._guardFacing);
            if (moveRecord.Contains(tuple))
            {
                this.Reset();
                return true;
            }
            moveRecord.Add(tuple);
        }

        this.Reset();
        return false;
    }

    private bool HitObstacle()
    {
        if (this.TryGetValue(this._guardPosition.Adjacent(this._guardFacing), out var value) && value == '#')
        {
            return true;
        }
        return false;
    }

    private void Advance()
    {
        this._guardPosition = this._guardPosition.Adjacent(this._guardFacing);
    }

    private void TurnRight()
    {
        this._guardFacing = this._guardFacing switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => throw new InvalidOperationException("Guard facing cannot be diagonal")
        };
    }
}
