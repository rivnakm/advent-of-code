using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Models.Day05;

public class RuleSet : IComparer<int>
{
    private FrozenDictionary<int, FrozenSet<Rule>> _rules;

    public RuleSet(IList<Rule> rules)
    {
        this._rules = rules
            .GroupBy(r => r.A)
            .ToFrozenDictionary(g => g.Key, g => g.ToFrozenSet());
    }

    public bool CheckUpdate(IList<int> update)
    {
        return update
            .Where(u => this._rules.ContainsKey(u))
            .All(num =>
                this._rules[num]
                    .Where(r => update.Contains(r.B))
                    .All(r => update.IndexOf(num) < update.IndexOf(r.B))

        );
    }

    public int Compare(int a, int b)
    {
        // Correct order
        if (this._rules.TryGetValue(a, out var rules))
        {
            var rule = rules.SingleOrDefault(r => r.B == b);
            if (rule is not null)
            {
                return -1;
            }
        }

        // Reversed
        if (this._rules.TryGetValue(b, out rules))
        {
            var rule = rules.SingleOrDefault(r => r.B == a);
            if (rule is not null)
            {
                return 1;
            }
        }

        // No rule
        return 0;
    }
}
