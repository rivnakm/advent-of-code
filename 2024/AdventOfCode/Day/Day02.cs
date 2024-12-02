using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Extensions;
using MoreLinq;

namespace AdventOfCode.Day;

public static class Day02
{
    public static int PartOne(Stream input)
    {
        using var reader = new StreamReader(input);

        var reports = reader.ReadLines().Select(ReadReport);
        return reports.Where(IsReportSafe).Count();
    }

    public static int PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var reports = reader.ReadLines().Select(ReadReport);
        return reports.Where(r => r.Subsets(r.Count - 1).Any(IsReportSafe)).Count();
    }

    private static IList<int> ReadReport(string line)
    {
        return line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(n => int.Parse(n)).ToList();
    }

    private static bool IsReportSafe(IList<int> report)
    {
        var isJagged = report.Window(2).Any(w =>
        {
            int diff = Math.Abs(w[0] - w[1]);
            return diff < 1 || diff > 3;
        });

        if (isJagged)
        {
            return false;
        }

        return report.Window(2).All(w => w[0] < w[1]) || report.Window(2).All(w => w[0] > w[1]);
    }
}
