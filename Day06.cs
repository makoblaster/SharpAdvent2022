namespace Advent2022;

public class Day06 : BaseDay
{
    protected override string Part1()
    {
        var line = Input[0];
        return ElaborateLine(line, 4);
    }

    public static string ElaborateLine(string line, int size)
    {
        for (var i = 0; i < line.Length; i++)
        {
            var end = i + size;
            var chars = line[i..end];
            if (chars.Distinct().Count() == chars.Length)
            {
                return end.ToString();
            }
        }

        return "null";
    }

    protected override string Part2()
    {
        var line = Input[0];
        return ElaborateLine(line, 14);
    }
}