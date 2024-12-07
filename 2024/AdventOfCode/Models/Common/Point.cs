using System;

namespace AdventOfCode.Models.Common;

public record Point(int X, int Y)
{
    public Point Adjacent(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return this with { Y = this.Y - 1 };
            case Direction.NorthEast:
                return this with { X = this.X + 1, Y = this.Y - 1 };
            case Direction.East:
                return this with { X = this.X + 1 };
            case Direction.SouthEast:
                return this with { X = this.X + 1, Y = this.Y + 1 };
            case Direction.South:
                return this with { Y = this.Y + 1 };
            case Direction.SouthWest:
                return this with { X = this.X - 1, Y = this.Y + 1 };
            case Direction.West:
                return this with { X = this.X - 1 };
            case Direction.NorthWest:
                return this with { X = this.X - 1, Y = this.Y - 1 };
            default:
                throw new ArgumentException("Invalid direction", nameof(direction));
        }
    }

    public override string ToString()
    {
        return $"({this.X}, {this.Y})";
    }
}

