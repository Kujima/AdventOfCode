namespace AdventOfCode.Algo;

using System;

public class AlgoDay3 : IAlgoDay
{
    private readonly string DayNumber;

    public AlgoDay3(string dayNumber)
    {
        DayNumber = dayNumber;
    }

    public void Solve1()
    {
        string[] lines = InputProvider.GetContent(this.DayNumber);

        string firstPocket;
        string secondPocket;
        char itemType = 'c';
        List<int> listTypeScore = new List<int>();

        foreach (var rucksack in lines)
        {
            firstPocket = rucksack.Substring(0, rucksack.Length / 2);
            secondPocket = rucksack.Substring(rucksack.Length / 2);

            foreach (var c in firstPocket)
            {
                if (secondPocket.Contains(c))
                {
                    itemType = c;
                    break;
                }
            }

            listTypeScore.Add(categoryScore[itemType]);
        }

        Console.WriteLine(listTypeScore.Sum());
    }

    private Dictionary<char, int> categoryScore = new Dictionary<char, int>()
    {
        { 'a', 1 },
        { 'b', 2 },
        { 'c', 3 },
        { 'd', 4 },
        { 'e', 5 },
        { 'f', 6 },
        { 'g', 7 },
        { 'h', 8 },
        { 'i', 9 },
        { 'j', 10 },
        { 'k', 11 },
        { 'l', 12 },
        { 'm', 13 },
        { 'n', 14 },
        { 'o', 15 },
        { 'p', 16 },
        { 'q', 17 },
        { 'r', 18 },
        { 's', 19 },
        { 't', 20 },
        { 'u', 21 },
        { 'v', 22 },
        { 'w', 23 },
        { 'x', 24 },
        { 'y', 25 },
        { 'z', 26 },
        { 'A', 27 },
        { 'B', 28 },
        { 'C', 29 },
        { 'D', 30 },
        { 'E', 31 },
        { 'F', 32 },
        { 'G', 33 },
        { 'H', 34 },
        { 'I', 35 },
        { 'J', 36 },
        { 'K', 37 },
        { 'L', 38 },
        { 'M', 39 },
        { 'N', 40 },
        { 'O', 41 },
        { 'P', 42 },
        { 'Q', 43 },
        { 'R', 44 },
        { 'S', 45 },
        { 'T', 46 },
        { 'U', 47 },
        { 'V', 48 },
        { 'W', 49 },
        { 'X', 50 },
        { 'Y', 51 },
        { 'Z', 52 },
    };

    public void Solve2()
    {
        string[] lines = InputProvider.GetContent(this.DayNumber);

        string firstRucksack = "";
        string secondRucksack = "";
        string thirdRucksack = "";
        List<int> listScoreRucksackGroup = new List<int>();

        for (int i = 0; i < lines.Length; i += 3)
        {
            firstRucksack = lines[i];
            secondRucksack = lines[i + 1];
            thirdRucksack = lines[i + 2];

            foreach (var c in firstRucksack)
            {
                if (secondRucksack.Contains(c) && thirdRucksack.Contains(c))
                {
                    listScoreRucksackGroup.Add(categoryScore[c]);
                    break;
                }
            }
        }
        Console.WriteLine(listScoreRucksackGroup.Sum());
    }
}
