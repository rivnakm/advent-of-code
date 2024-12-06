using System.Collections.Generic;
using AdventOfCode.Models.Day05;
using FluentAssertions;

namespace AdventOfCode.Test.Models.Day05;

public class RuleSetTest
{
    public static IEnumerable<object[]> CheckUpdateCases = new List<object[]>
    {
        new object [] { new List<int> { 2, 4, 5 }, true },
        new object [] { new List<int> { 1, 2, 5 }, false }
    };

    [Theory]
    [MemberData(nameof(CheckUpdateCases))]
    public void TestCheckUpdate(IList<int> update, bool expected)
    {
        var rules = new List<Rule> {
            new Rule(2, 4),
            new Rule(4, 5),
            new Rule(5, 1)
        };

        var ruleSet = new RuleSet(rules);
        var actual = ruleSet.CheckUpdate(update);

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, 4, -1)]
    public void TestCompare(int a, int b, int expected)
    {
        var rules = new List<Rule> {
            new Rule(2, 4),
            new Rule(4, 5),
            new Rule(5, 1)
        };

        var ruleSet = new RuleSet(rules);
        var actual = ruleSet.Compare(a, b);

        actual.Should().Be(expected);
    }

    [Fact]
    public void TestSort_ValidIsSame()
    {
        var rules = new List<Rule> {
            new Rule(2, 4),
            new Rule(4, 5),
            new Rule(5, 1)
        };

        var ruleSet = new RuleSet(rules);
        var update = new List<int> { 2, 6, 4, 3, 5, 1 };
        var original = new List<int>(update);

        ruleSet.CheckUpdate(update).Should().BeTrue();

        update.Sort(ruleSet);

        ruleSet.CheckUpdate(update).Should().BeTrue();
        update.Should().Equal(original);
    }
}

