using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode.Extensions;

namespace AdventOfCode.Test.Extensions;

public class StreamReaderExtensionsTest
{
    [Fact]
    public void TestReadSingleLine()
    {
        List<string> expected = ["Hello, World!"];
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(string.Join('\n', expected)));
        using var reader = new StreamReader(stream);

        var actual = reader.ReadLines().ToList();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestReadMultipleLines()
    {
        List<string> expected = ["Hello, World!", "Goodbye, World!"];
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(string.Join('\n', expected)));
        using var reader = new StreamReader(stream);

        var actual = reader.ReadLines().ToList();

        Assert.Equal(expected, actual);
    }
}
