using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Extensions;
using AdventOfCode.Models.Common;
using MoreLinq;

namespace AdventOfCode.Day;

public static class Day08
{
    public static int PartOne(Stream input)
    {
        using var reader = new StreamReader(input);

        var grid = new Grid(reader.ReadLines().Select(l => (IList<char>)l.ToList()).ToList());

        var antennas = grid.Points()
            .Select(p => new { Point = p, Value = grid.Get(p) })
            .Where(pair => pair.Value != '.')
            .Select(pair => new Antenna(pair.Point, pair.Value));

        var antennasByFrequency = antennas.GroupBy(a => a.Frequency);
        var antennaPairs = antennasByFrequency
            .Where(g => g.Count() >= 2)
            .SelectMany(g => g.Subsets(2))
            .Select(l => new Tuple<Antenna, Antenna>(l[0], l[1]));

        var antinodes = antennaPairs.SelectMany(pair => FindAntinodes(pair.Item1, pair.Item2)).Where(p => grid.IsInBounds(p)).Distinct();

        return antinodes.Count();
    }

    public static int PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var grid = new Grid(reader.ReadLines().Select(l => (IList<char>)l.ToList()).ToList());

        var antennas = grid.Points()
            .Select(p => new { Point = p, Value = grid.Get(p) })
            .Where(pair => pair.Value != '.')
            .Select(pair => new Antenna(pair.Point, pair.Value));

        var antennasByFrequency = antennas.GroupBy(a => a.Frequency);
        var antennaPairs = antennasByFrequency
            .Where(g => g.Count() >= 2)
            .SelectMany(g => g.Subsets(2))
            .Select(l => new Tuple<Antenna, Antenna>(l[0], l[1]));

        var antinodes = antennaPairs.SelectMany(pair => FindInBoundsAntinodes(pair.Item1, pair.Item2, grid)).Distinct();

        return antinodes.Count();
    }

    private record Antenna(Point Point, char Frequency)
    {
    }

    private static IEnumerable<Point> FindAntinodes(Antenna a, Antenna b)
    {
        var diff = b.Point - a.Point;

        yield return b.Point + diff;
        yield return a.Point - diff;
    }

    private static IEnumerable<Point> FindInBoundsAntinodes(Antenna a, Antenna b, Grid grid)
    {
        var diff = b.Point - a.Point;

        yield return a.Point;
        yield return b.Point;

        var antinode = b.Point + diff;
        while (grid.IsInBounds(antinode))
        {
            yield return antinode;
            antinode += diff;
        }

        antinode = a.Point - diff;
        while (grid.IsInBounds(antinode))
        {
            yield return antinode;
            antinode -= diff;
        }
    }
}
