using NUnit.Framework;

namespace Advent2022;

[TestFixture]
public class Day06Tests
{
    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", ExpectedResult = "7")]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", ExpectedResult = "5")]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", ExpectedResult = "6")]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", ExpectedResult = "10")]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", ExpectedResult = "11")]
    public string TestPart01BaseStrings(string input)
    {
        return Day06.ElaborateLine(input, 4);
    }
    
    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", ExpectedResult = "19")]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", ExpectedResult = "23")]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", ExpectedResult = "23")]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", ExpectedResult = "29")]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", ExpectedResult = "26")]
    public string TestPart02BaseStrings(string input)
    {
        return Day06.ElaborateLine(input, 14);
    }
}