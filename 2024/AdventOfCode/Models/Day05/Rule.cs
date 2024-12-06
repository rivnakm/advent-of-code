using System;

namespace AdventOfCode.Models.Day05;

public class Rule
{
    public int A { get; init; }
    public int B { get; init; }

    public Rule(int a, int b)
    {
        this.A = a;
        this.B = b;
    }

    public static Rule Parse(string str)
    {
        var parts = str.Split('|', 2);
        if (parts.Length != 2)
        {
            throw new FormatException($"Unable to parse rule: '{str}'");
        }

        return new Rule(int.Parse(parts[0]), int.Parse(parts[1]));
    }
}

