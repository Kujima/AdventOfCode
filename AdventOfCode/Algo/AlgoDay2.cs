namespace AdventOfCode.Algo;

using System;

public class AlgoDay2 : IAlgoDay
{
    private readonly string DayNumber;

    public AlgoDay2(string dayNumber)
    {
        DayNumber = dayNumber;
    }

    public void Solve1()
    {
        string[] lines = InputProvider.GetContent(this.DayNumber);
        string meHand;
        string opponentHand;
        List<int> scoreList = new List<int>();

        foreach (var line in lines)
        {
            opponentHand = line.Substring(0, 1);
            meHand = line.Substring(2);

            scoreList.Add(CalculateRoundScore1(meHand, opponentHand));
        }

        Console.WriteLine(scoreList.Sum());
    }

    private int CalculateRoundScore1(string meHand, string opponentHand)
    {
        int score = 0;
        if (meHand == "X" && opponentHand == "A")
        {
            // rock + draw
            score = 1 + 3;
        }
        else if (meHand == "X" && opponentHand == "B")
        {
            // rock + lost
            score = 1;
        }
        else if (meHand == "X" && opponentHand == "C")
        {
            // rock + win
            score = 1 + 6;
        }
        else if (meHand == "Y" && opponentHand == "A")
        {
            // paper + win
            score = 2 + 6;
        }
        else if (meHand == "Y" && opponentHand == "B")
        {
            // paper + draw
            score = 2 + 3;
        }
        else if (meHand == "Y" && opponentHand == "C")
        {
            // paper + lost
            score = 2;
        }
        else if (meHand == "Z" && opponentHand == "A")
        {
            // Scissors + lost
            score = 3;
        }
        else if (meHand == "Z" && opponentHand == "B")
        {
            // Scissors + Win
            score = 3 + 6;
        }
        else if (meHand == "Z" && opponentHand == "C")
        {
            // Scissors + draw
            score = 3 + 3;
        }
        ;

        return score;
    }

    private int CalculateRoundScore2(string opponentHand, string resultRound)
    {
        int score = 0;
        if (resultRound == "X" && opponentHand == "A")
        {
            // lost + Scissors
            score = 3;
        }
        else if (resultRound == "X" && opponentHand == "B")
        {
            // lost + Rock
            score = 1;
        }
        else if (resultRound == "X" && opponentHand == "C")
        {
            // lost + Paper
            score = 2;
        }
        else if (resultRound == "Y" && opponentHand == "A")
        {
            // draw + Rock
            score = 3 + 1;
        }
        else if (resultRound == "Y" && opponentHand == "B")
        {
            // draw + Paper
            score = 3 + 2;
        }
        else if (resultRound == "Y" && opponentHand == "C")
        {
            // draw + Scissors
            score = 3 + 3;
        }
        else if (resultRound == "Z" && opponentHand == "A")
        {
            // Win + Paper
            score = 6 + 2;
        }
        else if (resultRound == "Z" && opponentHand == "B")
        {
            // Win + Scissors
            score = 6 + 3;
        }
        else if (resultRound == "Z" && opponentHand == "C")
        {
            // Win + Rock
            score = 6 + 1;
        }
        ;

        return score;
    }

    public void Solve2()
    {
        string[] lines = InputProvider.GetContent(this.DayNumber);
        string resultRound;
        string opponentHand;
        List<int> scoreList = new List<int>();

        foreach (var line in lines)
        {
            opponentHand = line.Substring(0, 1);
            resultRound = line.Substring(2);

            scoreList.Add(CalculateRoundScore2(opponentHand, resultRound));
        }

        Console.WriteLine(scoreList.Sum());
    }
}
