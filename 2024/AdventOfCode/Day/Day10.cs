using System.IO;
using System.Linq;
using AdventOfCode.Extensions;
using AdventOfCode.Models.Day10;

namespace AdventOfCode.Day;

public static class Day10
{
    public static int PartOne(Stream input)
    {
        using var reader = new StreamReader(input);

        var lines = reader.ReadLines().ToList();
        var rows = lines.Count;
        var cols = lines.First().Length;

        var gridList = lines.SelectMany(l => l.TrimEnd()).ToList();
        var trailMap = new TrailMap(gridList, rows, cols);

        return trailMap.TraceTrails();
    }

    public static int PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var lines = reader.ReadLines().ToList();
        var rows = lines.Count;
        var cols = lines.First().Length;

        var gridList = lines.SelectMany(l => l.TrimEnd()).ToList();
        var trailMap = new TrailMap(gridList, rows, cols);

        return trailMap.RateTrails();
    }
}
