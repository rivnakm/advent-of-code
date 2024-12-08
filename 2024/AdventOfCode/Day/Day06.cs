using System;
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

        var gridList = lines.SelectMany(l => l.TrimEnd()).ToList();
        var guardMap = new GuardMap(gridList, rows, cols);

        return guardMap.GuardPoints().Distinct().Count();
    }

    public static int PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var lines = reader.ReadLines().ToList();

        var rows = lines.Count;
        var cols = lines.First().Length;

        var gridList = lines.SelectMany(l => l.TrimEnd()).ToList();
        var guardMap = new GuardMap(gridList, rows, cols);

        return guardMap.Points().Where(p => guardMap.NewObstacleCausesLoop(p)).Count();
    }
}

