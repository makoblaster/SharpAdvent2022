using NUnit.Framework;

namespace Advent2022;

[TestFixture]
public class Day02Tests
{
    [Test]
    public void TestDemoInput()
    {
        var input = new List<string>
        {
            "A Y", "B X", "C Z"
        };

        var result = input.Sum(Day02.GetLineTotalScore);
        Assert.AreEqual(15, result);
    }

    [Test]
    [TestCase("A X", ExpectedResult = 1 + 3)]
    [TestCase("A Y", ExpectedResult = 2 + 6)]
    [TestCase("A Z", ExpectedResult = 3 + 0)]
    [TestCase("B X", ExpectedResult = 1 + 0)]
    [TestCase("B Y", ExpectedResult = 2 + 3)]
    [TestCase("B Z", ExpectedResult = 3 + 6)]
    [TestCase("C X", ExpectedResult = 1 + 6)]
    [TestCase("C Y", ExpectedResult = 2 + 0)]
    [TestCase("C Z", ExpectedResult = 3 + 3)]
    public int TestSingle(string input)
    {
        return Day02.GetLineTotalScore(input);
    }
    
    [Test]
    public void TestCompleteInput()
    {
        var input = new List<string>
        {
            "A X", "A Y", "A Z",
            "B X", "B Y", "B Z",
            "C X", "C Y", "C Z"
        };

        const int winPoints = 3 * 3 + 6 * 3;
        const int movePoints = 1 * 3 + 2 * 3 + 3 * 3;

        var result = input.Sum(Day02.GetLineTotalScore);
        Assert.AreEqual(winPoints + movePoints, result);
    }
    
    [Test]
    public void TestAllLoseInput()
    {
        var input = new List<string>
        {
            "A Z",
            "B X",
            "C Y"
        };
        
        const int movePoints = 1 + 2 + 3;

        var result = input.Sum(Day02.GetLineTotalScore);
        Assert.AreEqual(movePoints, result);
    }
    
    [Test]
    public void TestAllWinInput()
    {
        var input = new List<string>
        {
            "A Y",
            "B Z",
            "C X"
        };
        
        const int movePoints = 1 + 2 + 3;
        const int winPoints = 6 * 3;
        
        var result = input.Sum(Day02.GetLineTotalScore);
        Assert.AreEqual(movePoints + winPoints, result);
    }
    
    [Test]
    public void TestAllDrawInput()
    {
        var input = new List<string>
        {
            "A X",
            "B Y",
            "C Z"
        };
        
        const int movePoints = 1 + 2 + 3;
        const int winPoints = 3 * 3;
        
        var result = input.Sum(Day02.GetLineTotalScore);
        Assert.AreEqual(movePoints + winPoints, result);
    }
}