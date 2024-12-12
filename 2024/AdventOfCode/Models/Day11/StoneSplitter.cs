using System;
using System.Collections.Generic;

namespace AdventOfCode.Models.Day11;

public class StoneSplitter
{
    private readonly Dictionary<Tuple<long, int>, long> counts;

    public StoneSplitter()
    {
        this.counts = new Dictionary<Tuple<long, int>, long>();
    }

    public long RunNSplits(long stone, int n)
    {
        var initialStone = stone;
        var initialN = n;
        if (this.counts.TryGetValue(new Tuple<long, int>(stone, n), out var result))
        {
            return result;
        }
        var count = 1L;
        while (n > 0)
        {
            if (stone == 0)
            {
                stone = 1;
                n--;
                continue;
            }

            var digits = Digits(stone);
            if (digits % 2 == 0)
            {
                n--;
                var factor = PowL(10, digits / 2);
                count += this.RunNSplits(stone % factor, n);
                stone = stone / factor;
            }
            else
            {
                stone *= 2024;
                n--;
            }
        }

        this.counts.TryAdd(new Tuple<long, int>(initialStone, initialN), count);
        return count;
    }

    public static List<long> SplitStones(IList<long> stones)
    {
        var output = new List<long>();
        foreach (var stone in stones)
        {
            if (stone == 0)
            {
                output.Add(1);
                continue;
            }

            var digits = Digits(stone);
            if (digits % 2 == 0)
            {
                var factor = PowL(10, digits / 2);
                output.Add(stone / factor);
                output.Add(stone % factor);
            }
            else
            {
                output.Add(stone * 2024);
            }
        }

        return output;
    }

    private static int Digits(long num)
    {
        int len = 1;
        while (num >= 10)
        {
            num /= 10;
            len++;
        }
        return len;
    }

    private static long PowL(long num, int exp)
    {
        var result = 1L;
        for (var i = 0; i < exp; i++)
        {
            result *= num;
        }
        return result;
    }
}
