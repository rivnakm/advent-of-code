using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Models.Day05;

public class RuleSet : IComparer<int>
{
    private IList<Rule> _rules;

    public RuleSet(IList<Rule> rules)
    {
        this._rules = rules;
    }

    public bool CheckUpdate(IList<int> update)
    {
        return update.All(num =>
            this._rules.Where(r => r.A == num).Where(r => update.Contains(r.B)).All(r => update.IndexOf(num) < update.IndexOf(r.B))

        );
    }

    public int Compare(int a, int b)
    {
        var rule = this._rules.SingleOrDefault(r => (r.A == a && r.B == b) || (r.A == b && r.B == a));

        if (rule is null)
        {
            return 0;
        }

        if (rule.A == a)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
