using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using AdventOfCode.Extensions;
using AdventOfCode.Models.Day06;

namespace AdventOfCode.Day;

public static class Day06
{
    public static int PartOne(Stream input)
    {
        using var reader = new StreamReader(input);

        var lines = reader.ReadLines().ToList();

        var rows = lines.Count;
        var cols = lines.First().Length;

        var gridArr = lines.SelectMany(l => l.TrimEnd()).ToImmutableArray();
        var guardMap = new GuardMap(gridArr, rows, cols);

        return guardMap.GuardPoints().Distinct().Count();
    }

    public static int PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var lines = reader.ReadLines().ToList();

        var rows = lines.Count;
        var cols = lines.First().Length;

        var gridArr = lines.SelectMany(l => l.TrimEnd()).ToImmutableArray();
        var guardMap = new GuardMap(gridArr, rows, cols);

        return guardMap.Points().Where(p => guardMap.NewObstacleCausesLoop(p)).Count();
    }
}

