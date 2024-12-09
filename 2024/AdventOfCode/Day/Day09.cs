using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day;

public static class Day09
{
    public static long PartOne(Stream input)
    {
        using var reader = new StreamReader(input);

        var blocks = UncompressMap(reader.ReadToEnd()).ToList();
        var shifted = ShiftBlocks(blocks);

        return shifted.Select((b, i) => b.IsFreeSpace ? 0L : (long)(b.Id * i)).Sum();
    }

    public static long PartTwo(Stream input)
    {
        using var reader = new StreamReader(input);

        var blocks = UncompressMap(reader.ReadToEnd()).ToList();
        var shifted = ShiftChunks(blocks);

        return shifted.Select((b, i) => b.IsFreeSpace ? 0L : (long)(b.Id * i)).Sum();
    }

    private struct Block
    {
        public int Id { get; set; }
        public bool IsFreeSpace { get; set; }

        public override string ToString()
        {
            return this.IsFreeSpace ? "." : $"{this.Id}";
        }
    }

    private static IEnumerable<Block> UncompressMap(IEnumerable<char> denseMap)
    {
        var id = 0;
        var is_free_space = false;

        foreach (var ch in denseMap)
        {
            int value = ch - '0';
            for (var i = 0; i < value; i++)
            {
                if (is_free_space)
                {
                    yield return new Block { IsFreeSpace = true };
                }
                else
                {
                    yield return new Block { Id = id };
                }
            }

            if (!is_free_space)
            {
                id++;
            }

            is_free_space = !is_free_space;
        }
    }

    private static IList<Block> ShiftBlocks(IList<Block> blocks)
    {
        var head = 0;
        var tail = blocks.Count - 1;

        var outputBlocks = new List<Block>(blocks);

        while (head < tail)
        {
            var headBlock = outputBlocks[head];
            if (headBlock.IsFreeSpace)
            {
                var tailBlock = outputBlocks[tail];
                while (tailBlock.IsFreeSpace)
                {
                    tailBlock = outputBlocks[--tail];
                }

                if (head >= tail)
                {
                    break;
                }

                outputBlocks[head] = tailBlock;
                outputBlocks[tail] = headBlock;
            }
            head++;
        }

        return outputBlocks;
    }

    private static IEnumerable<Block> ShiftChunks(IList<Block> blocks)
    {
        var outputBlocks = blocks.ToArray();

        var chunks = outputBlocks
            .Select((block, i) => (block, i))
            .Where(pair => !pair.block.IsFreeSpace)
            .GroupBy(
                pair => pair.block.Id,
                pair => pair,
                (key, val) => new
                {
                    Id = key,
                    Length = val.Count(),
                    Index = val.Select(pair => pair.i).Min()
                })
            .Reverse();

        foreach (var chunk in chunks)
        {
            for (var i = 0; i < chunk.Index; i++)
            {
                var numSpace = 0;
                for (var j = i; j < Math.Min(i + chunk.Length, outputBlocks.Length); j++)
                {
                    if (outputBlocks[j].IsFreeSpace)
                    {
                        numSpace++;
                    }
                }

                if (numSpace == chunk.Length)
                {
                    for (var j = 0; j < outputBlocks.Length; j++)
                    {
                        if (outputBlocks[j].Id == chunk.Id)
                        {
                            outputBlocks[j].IsFreeSpace = true;
                        }
                    }

                    for (var j = i; j < i + chunk.Length; j++)
                    {
                        outputBlocks[j].IsFreeSpace = false;
                        outputBlocks[j].Id = chunk.Id;
                    }
                    break;
                }
            }
        }

        return outputBlocks;
    }
}
