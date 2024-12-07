using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using AdventOfCode.Extensions;
using AdventOfCode.Models.Common;
using AdventOfCode.Models.Day04;

namespace AdventOfCode.Day;

public static class Day04
{
    public static int PartOne(Stream input)
    {
        using var reader = new StreamReader(input);

        var lines = reader.ReadLines().ToList();

        var rows = lines.Count;
        var cols = lines.First().Length;

        var gridArr = lines.SelectMany(l => l.TrimEnd()).ToImmutableArray();
        var grid = new Grid(gridArr, rows, cols);

        var xPoints = grid.Points().Where(p => grid.TryGetValue(p, out var value) && value == (char)XmasLetter.X);

        return xPoints.Select(p => FindXmas(grid, p)).Sum();
    }

    public static int PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var lines = reader.ReadLines().ToList();

        var rows = lines.Count;
        var cols = lines.First().Length;

        var gridArr = lines.SelectMany(l => l.TrimEnd()).ToImmutableArray();
        var grid = new Grid(gridArr, rows, cols);

        var aPoints = grid.Points().Where(p => grid.TryGetValue(p, out var value) && value == (char)XmasLetter.A);

        return aPoints.Where(p => FindMasX(grid, p)).Count();
    }

    private static int FindXmas(Grid grid, Point xPoint)
    {
        int numXmas = 0;
        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
        {
            var next = xPoint.Adjacent(direction);
            if (!TryFindLetter(grid, next, XmasLetter.M))
            {
                continue;
            }

            next = next.Adjacent(direction);
            if (!TryFindLetter(grid, next, XmasLetter.A))
            {
                continue;
            }

            next = next.Adjacent(direction);
            if (!TryFindLetter(grid, next, XmasLetter.S))
            {
                continue;
            }

            numXmas++;
        }

        return numXmas;
    }

    private static bool FindMasX(Grid grid, Point point)
    {
        var diagonals = new List<Tuple<Direction, Direction>> {
            new Tuple<Direction, Direction>(Direction.NorthEast, Direction.SouthWest),
            new Tuple<Direction, Direction>(Direction.NorthWest, Direction.SouthEast),
        };
        var letters = new List<Tuple<XmasLetter, XmasLetter>> {
            new Tuple<XmasLetter, XmasLetter>(XmasLetter.M, XmasLetter.S),
            new Tuple<XmasLetter, XmasLetter>(XmasLetter.S, XmasLetter.M),
        };

        return diagonals.All(d => letters.Any(l => TryFindLetter(grid, point.Adjacent(d.Item1), l.Item1) && TryFindLetter(grid, point.Adjacent(d.Item2), l.Item2)));
    }

    private static bool TryFindLetter(Grid grid, Point point, XmasLetter letter)
    {
        if (grid.TryGetValue(point, out var value) && value == (char)letter)
        {
            return true;
        }
        return false;
    }
}

