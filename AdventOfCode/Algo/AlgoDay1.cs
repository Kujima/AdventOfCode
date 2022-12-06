using System.Linq;

namespace AdventOfCode.Algo;

public static class AlgoDay1
{
    private static readonly string InputPath = @"./Inputs/";
    private static readonly string InputName = "InputDay1.txt";
    private static readonly string InputPathFormat = InputPath + InputName;
    public static void Solve1()
    {
        string[] lines = InputProvider.GetContent(InputPathFormat);

        int total = 0;
        int max = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                if (total > max)
                {
                    max = total;
                }
                total = 0;
            }
            else
            {
                total += int.Parse(line);            
            }
        }

        Console.WriteLine(max);
    }

    public static void Solve2()
    {
        string[] lines = InputProvider.GetContent(InputPathFormat);

        int total = 0;
        int max = 0;
        List<int> listTotal = new List<int>();

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                listTotal.Add(total);
                total = 0;
            }
            else
            {
                total += int.Parse(line);
            }
        }

        var sortList = listTotal.OrderByDescending(x => x).Take(3).ToList();

        total = 0;
        foreach (var item in sortList)
        {
            total += item;
        }

        Console.WriteLine(total);
    }
}
