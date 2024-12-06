using System;
using AdventOfCode.Models.Day05;
using FluentAssertions;

namespace AdventOfCode.Test.Models.Day05;

public class RuleTest
{
    [Theory]
    [InlineData("2|5", 2, 5)]
    [InlineData("5|7", 5, 7)]
    public void TestParse(string input, int a, int b)
    {
        var rule = Rule.Parse(input);

        rule.A.Should().Be(a);
        rule.B.Should().Be(b);
    }

    [Fact]
    public void TestInvalidRule_Throws()
    {
        var input = "5,3";
        var parse = () => Rule.Parse(input);

        parse.Should().Throw<FormatException>();
    }
}
