using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AdventOfCode.Extensions;

namespace AdventOfCode.Day;

public static class Day01
{
    public static int PartOne(Stream input)
    {
        var left = new List<int>();
        var right = new List<int>();

        using var reader = new StreamReader(input);

        foreach (var line in reader.ReadLines())
        {
            var (l, r) = ParseLine(line);
            left.Add(l);
            right.Add(r);
        }

        left.Sort();
        right.Sort();

        var diffs = left.Zip(right, (l, r) => Math.Abs(l - r));

        return diffs.Sum();
    }

    public static int PartTwo(Stream input)
    {
        var left = new List<int>();
        var right = new Dictionary<int, int>();

        using var reader = new StreamReader(input);

        foreach (var line in reader.ReadLines())
        {
            var (l, r) = ParseLine(line);
            left.Add(l);

            _ = right.TryAdd(r, 0);
            right[r]++;
        }

        return left.Select(l =>
        {
            if (right.TryGetValue(l, out var r))
            {
                return l * r;
            }
            else
            {
                return 0;
            }
        }).Sum();
    }

    private static Tuple<int, int> ParseLine(string line)
    {
        var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(n => int.Parse(n)).ToList();

        Debug.Assert(nums.Count() == 2);

        return new Tuple<int, int>(nums[0], nums[1]);
    }
}
