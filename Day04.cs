namespace Advent2022;

public class Day04 : BaseDay
{
    protected override string Part1()
    {
        var count = 0;
        foreach (var line in Input)
        {
            var ranges = GetRangesFromLine(line);

            var intersect = ranges[0].Intersect(ranges[1]).ToList();
            if (intersect.SequenceEqual(ranges[1]) || intersect.SequenceEqual(ranges[0]))
                count++;
        }

        return count.ToString();
    }

    protected override string Part2()
    {
        var count = 0;
        foreach (var line in Input)
        {
            var ranges = GetRangesFromLine(line);
            
            if (ranges[0].Any(x => ranges[1].Contains(x) || ranges[1].Any(x => ranges[0].Contains(x))))
                count++;
        }
        return count.ToString();
    }
    
    private static List<List<int>> GetRangesFromLine(string line)
    {
        var twoElvesAssignments = line.Split(",");
        var ranges = new List<List<int>>();
        foreach (var elfAssignments in twoElvesAssignments)
        {
            var split = elfAssignments.Split("-");
            var start = int.Parse(split[0]);
            var rangeCount = int.Parse(split[1]) - start + 1;
            ranges.Add(Enumerable.Range(start, rangeCount).ToList());
        }

        return ranges;
    }
}