namespace Advent2022;

public class Day03 : BaseDay
{
    protected override string Part1()
    {
        var prioritySum = 0;
        foreach (var line in Input)
        {
            var firstHalf = line[..(line.Length / 2)];
            var secondHalf = line[(line.Length / 2)..];
            var commonItem = firstHalf.Intersect(secondHalf).First();
            prioritySum += CharToPriority(commonItem);
        }

        return prioritySum.ToString();
    }
    
    private static int CharToPriority(char commonItem)
    {
        if (char.IsLower(commonItem))
            return commonItem - 96;
        if (char.IsUpper(commonItem))
            return commonItem - 38;
        throw new ArgumentOutOfRangeException(nameof(commonItem), commonItem, null);
    }

    protected override string Part2()
    {
        var prioritySum = 0;
        for (var index = 0; index < Input.Count; index += 3)
        {
            var line = Input[index];
            var line2 = Input[index + 1];
            var line3 = Input[index + 2];
            var badge = line.Intersect(line2).Intersect(line3).First();
            prioritySum += CharToPriority(badge);
        }

        return prioritySum.ToString();
    }
}