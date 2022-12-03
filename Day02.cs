namespace Advent2022;

public class Day02 : BaseDay
{
    private enum Move
    {
        Rock,
        Paper,
        Scissors
    }

    private static Move GetMove(char letter)
    {
        switch (letter)
        {
            case 'A':
            case 'X':
                return Move.Rock;
            case 'B':
            case 'Y': 
                return Move.Paper;
            case 'C':
            case 'Z':
                return Move.Scissors;
            default:
                throw new ArgumentOutOfRangeException(nameof(letter));
        }
    }

    private static int GetScore(Move move)
    {
        return move switch
        {
            Move.Rock => 1,
            Move.Paper => 2,
            Move.Scissors => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(move), move, null)
        };
    }

    private static bool? DoTheyWin(Move first, Move second)
    {
        switch (first)
        {
            case Move.Rock:
                return second switch
                {
                    Move.Rock => null,
                    Move.Paper => false,
                    Move.Scissors => true,
                    _ => throw new ArgumentOutOfRangeException(nameof(second), second, null)
                };
            case Move.Paper:
                return second switch
                {
                    Move.Rock => true,
                    Move.Paper => null,
                    Move.Scissors => false,
                    _ => throw new ArgumentOutOfRangeException(nameof(second), second, null)
                };
            case Move.Scissors:
                return second switch
                {
                    Move.Rock => false,
                    Move.Paper => true,
                    Move.Scissors => null,
                    _ => throw new ArgumentOutOfRangeException(nameof(second), second, null)
                };
            default:
                throw new ArgumentOutOfRangeException(nameof(first), first, null);
        }
    }
    
    protected override string Part1()
    {
        var totalScore = Input.Sum(GetLineTotalScore);

        return totalScore.ToString();
    }

    public static int GetLineTotalScore(string line)
    {
        var score = 0;
        var theirInput = GetMove(line[0]);
        var myInput = GetMove(line[2]);
        var result = DoTheyWin(theirInput, myInput);
        switch (result)
        {
            case null:
                score += 3;
                break;
            case false:
                score += 6;
                break;
        }

        score += GetScore(myInput);
        return score;
    }

    public static int GetLinePossibleScore(string line)
    {
        var score = 0;
        var theirInput = GetMove(line[0]);
        var myNeededInput = GetMoveToDo(theirInput, line[2]);
        var result = DoTheyWin(theirInput, myNeededInput);
        switch (result)
        {
            case null:
                score += 3;
                break;
            case false:
                score += 6;
                break;
        }

        score += GetScore(myNeededInput);
        return score;
    }

    private static Move GetMoveToDo(Move theirInput, char result)
    {
        switch (result)
        {
            case 'X':
                switch (theirInput)
                {
                    case Move.Rock:
                        return Move.Scissors;
                    case Move.Paper:
                        return Move.Rock;
                    case Move.Scissors:
                        return Move.Paper;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(theirInput), theirInput, null);
                }
            case 'Y':
                return theirInput;
            case 'Z':
                switch (theirInput)
                {
                    case Move.Rock:
                        return Move.Paper;
                    case Move.Paper:
                        return Move.Scissors;
                    case Move.Scissors:
                        return Move.Rock;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(theirInput), theirInput, null);
                }
            default:
                throw new ArgumentOutOfRangeException(nameof(result), result, null);
        }
    }

    protected override string Part2()
    {
        var totalScore = Input.Sum(GetLinePossibleScore);

        return totalScore.ToString();
    }
}