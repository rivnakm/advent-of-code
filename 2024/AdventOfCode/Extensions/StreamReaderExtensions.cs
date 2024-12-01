using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Extensions;

public static class StreamReaderExtensions
{
    public static IEnumerable<string> ReadLines(this StreamReader reader)
    {
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
}
