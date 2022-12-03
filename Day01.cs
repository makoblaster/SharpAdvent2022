namespace Advent2022;

class Day01 : BaseDay
{
    protected override string Part1()
    {
        var elvesCalories = new Dictionary<int, int>();
        var currentElf = 0;
        foreach (var line in Input)
        {
            if (line == string.Empty)
            {
                currentElf++;
                continue;
            }
            var calories = int.Parse(line);
            if (!elvesCalories.ContainsKey(currentElf))
            {
                elvesCalories[currentElf] = 0;
            }
    
            elvesCalories[currentElf] += calories;
        }
        return elvesCalories.Values.Max().ToString();
    }

    protected override string Part2()
    {
        var elvesCalories = new Dictionary<int, int>();
        var currentElf = 0;
        foreach (var line in Input)
        {
            if (line == string.Empty)
            {
                currentElf++;
                continue;
            }
            var calories = int.Parse(line);
            if (!elvesCalories.ContainsKey(currentElf))
            {
                elvesCalories[currentElf] = 0;
            }
    
            elvesCalories[currentElf] += calories;
        }
        return elvesCalories.Values.OrderByDescending(x => x).Take(3).Sum().ToString();
    }
}