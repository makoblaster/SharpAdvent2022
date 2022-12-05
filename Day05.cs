using System.Collections;

namespace Advent2022;

public class Day05 : BaseDay
{
    protected override string Part1()
    {
        var separatorIndex = Input.FindIndex(x => x == string.Empty);
        var crates = ReadStartingCrates(separatorIndex);
        foreach (var line in Input.Skip(separatorIndex + 1))
        {
            var splitLine = line.Split(' ');
            var quantity = int.Parse(splitLine[1]);
            var from = int.Parse(splitLine[3]) - 1;
            var to = int.Parse(splitLine[5]) - 1;
            while (quantity > 0)
            {
                quantity--;
                var popped = crates[from].Pop();
                crates[to].Push(popped);
            }
        }

        return new string(crates.Select(x => x.Peek()).ToArray());
    }

    private List<Stack<char>> ReadStartingCrates(int separatorIndex)
    {
        var crates = new List<Stack<char>>();
        for (var lineIndex = separatorIndex - 1 ; lineIndex >= 0; lineIndex--)
        {
            var line = Input[lineIndex];
            for (var crateIndex = 1; crateIndex < line.Length; crateIndex += 4)
            {
                if (crateIndex >= line.Length)
                    break;

                if (lineIndex == separatorIndex - 1)
                {
                    crates.Add(new Stack<char>());
                    continue;
                }

                var crateChar = line[crateIndex];
                if (crateChar == ' ')
                    continue;
                crates[crateIndex / 4].Push(crateChar);
            }
        }

        return crates;
    }

    protected override string Part2()
    {
        var separatorIndex = Input.FindIndex(x => x == string.Empty);
        var crates = ReadStartingCrates(separatorIndex);
        foreach (var line in Input.Skip(separatorIndex + 1))
        {
            var splitLine = line.Split(' ');
            var quantity = int.Parse(splitLine[1]);
            var from = int.Parse(splitLine[3]) - 1;
            var to = int.Parse(splitLine[5]) - 1;
            var toPush = new Stack<char>();
            while (quantity > 0)
            {
                quantity--;
                toPush.Push(crates[from].Pop());
            }

            var reversed = new Stack<char>(toPush.Reverse().ToList());
            while (reversed.Count > 0)
            {
                crates[to].Push(reversed.Pop());
            }
        }

        return new string(crates.Select(x => x.Peek()).ToArray());
    }
}