using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day;

public static class Day03
{
    private static readonly Regex mulRegex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
    private static readonly Regex dontDoRegex = new Regex(@"don't\(\).*?do\(\)", RegexOptions.Singleline);
    private static readonly Regex dontRegex = new Regex(@"don't\(\).*", RegexOptions.Singleline);


    public static int PartOne(Stream input)
    {
        using var reader = new StreamReader(input);

        var memory = reader.ReadToEnd();

        var matches = mulRegex.Matches(memory);

        return matches.Select(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)).Sum();
    }

    public static int PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var memory = reader.ReadToEnd();
        memory = dontDoRegex.Replace(memory, "");
        memory = dontRegex.Replace(memory, "");

        var matches = mulRegex.Matches(memory);

        return matches.Select(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)).Sum();
    }


}
