using System;
using System.IO;
using System.Linq;
using AdventOfCode.Extensions;
using AdventOfCode.Models.Day05;
using MoreLinq;

namespace AdventOfCode.Day;

public static class Day05
{
    public static int PartOne(Stream input)
    {
        using var reader = new StreamReader(input);

        var splits = reader.ReadLines().Split("", 1).GetEnumerator();

        splits.MoveNext();
        var rules = splits.Current.Select(Rule.Parse).ToList();
        var ruleSet = new RuleSet(rules);

        splits.MoveNext();
        var updates = splits.Current.Select(u => u.Split(',').Select(int.Parse)).Select(u => u.ToList());

        var validUpdates = updates.Where(u => ruleSet.CheckUpdate(u)).ToList();

        return validUpdates.Select(u => u[u.Count / 2]).Sum();
    }

    public static int PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var splits = reader.ReadLines().Split("", 1).GetEnumerator();

        splits.MoveNext();
        var rules = splits.Current.Select(Rule.Parse).ToList();
        var ruleSet = new RuleSet(rules);

        splits.MoveNext();
        var updates = splits.Current.Select(u => u.Split(',').Select(int.Parse)).Select(u => u.ToList());

        var invalidUpdates = updates.Where(u => !ruleSet.CheckUpdate(u));


        return invalidUpdates.Select(u =>
        {
            u.Sort(ruleSet);
            return u[u.Count / 2];
        }).Sum();
    }

}

