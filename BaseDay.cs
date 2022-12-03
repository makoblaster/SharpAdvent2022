namespace Advent2022;

public abstract class BaseDay
{
    protected BaseDay()
    {
        Input = ReadInput(GetType().Name);
    }

    protected List<string> Input { get; }

    private static List<string> ReadInput(string name)
    {
        var fileName = $"{name}.txt";
        return File.ReadAllLines(fileName).ToList();
    }
    
    protected abstract string Part1();
    protected abstract string Part2();

    public void Execute()
    {
        var part1Result = Part1();
        Console.WriteLine(GetType().Name + "Part 1");
        Console.WriteLine(part1Result);
        var part2Result = Part2();
        Console.WriteLine(GetType().Name + "Part 2");
        Console.WriteLine(part2Result);
        
    }
}