using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Extensions;

namespace AdventOfCode.Day;

public static class Day07
{
    public static long PartOne(Stream input)
    {
        using var reader = new StreamReader(input);

        var equations = reader.ReadLines().Select(l => Equation.Parse(l));

        var operators = new HashSet<IOperator> { new Addition(), new Multiplication() };
        var validEquations = equations.Where(e => e.IsValid(operators));

        return validEquations.Select(e => e.Result).Sum();
    }

    public static long PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var equations = reader.ReadLines().Select(l => Equation.Parse(l));

        var operators = new HashSet<IOperator> { new Addition(), new Multiplication(), new Concatenation() };
        var validEquations = equations.Where(e => e.IsValid(operators));

        return validEquations.Select(e => e.Result).Sum();
    }

    private class Equation
    {
        public required long Result;
        public required IList<long> Operands;

        public static Equation Parse(string str)
        {
            var parts = str.Split(':', 2);
            var result = long.Parse(parts[0]);

            var operands = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(o => long.Parse(o))
                .ToList();

            return new Equation { Result = result, Operands = operands };
        }

        public bool IsValid(ISet<IOperator> operators)
        {
            var operatorCombos = operators.Combinations(this.Operands.Count - 1);

            return operatorCombos.Any(comb => this.Evaluate(comb.ToList()) == this.Result);
        }

        private long Evaluate(IList<IOperator> operators)
        {
            if (operators.Count != this.Operands.Count - 1)
            {
                throw new ArgumentException("Incorrect number of operators for number of operands");
            }

            var value = this.Operands[0];
            for (var i = 0; i < operators.Count; i++)
            {
                value = operators[i].Evaluate(value, this.Operands[i + 1]);
            }

            return value;
        }
    }

    private interface IOperator
    {
        long Evaluate(long a, long b);
    }

    private class Addition : IOperator
    {
        public long Evaluate(long a, long b)
        {
            return a + b;
        }
    }

    private class Multiplication : IOperator
    {
        public long Evaluate(long a, long b)
        {
            return a * b;
        }
    }

    private class Concatenation : IOperator
    {
        public long Evaluate(long a, long b)
        {
            var bDigits = (long)Math.Log10(b) + 1;
            return a * PowL(10, bDigits) + b;
        }
    }

    private static long PowL(long x, long e)
    {
        var value = 1L;
        for (var i = 0; i < e; i++)
        {
            value *= x;
        }

        return value;
    }
}
