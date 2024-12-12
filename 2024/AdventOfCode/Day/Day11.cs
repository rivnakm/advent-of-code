using System;
using System.IO;
using System.Linq;
using AdventOfCode.Models.Day11;

namespace AdventOfCode.Day;

public static class Day11
{
    public static int PartOne(Stream input)
    {
        const int NUM_BLINKS = 25;
        using var reader = new StreamReader(input);

        var stones = reader.ReadToEnd().Split(" ").Select(s => long.Parse(s)).ToList();

        for (var i = 0; i < NUM_BLINKS; i++)
        {
            stones = StoneSplitter.SplitStones(stones);
        }

        return stones.Count();
    }

    public static long PartTwo(Stream input)
    {
        const int NUM_BLINKS = 75;
        using var reader = new StreamReader(input);

        var stones = reader.ReadToEnd().Split(" ").Select(s => long.Parse(s));
        var stoneSplitter = new StoneSplitter();


        return stones.Select(stone => stoneSplitter.RunNSplits(stone, NUM_BLINKS)).Sum();
    }
}
