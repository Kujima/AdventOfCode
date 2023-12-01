using System.Linq;

namespace AdventOfCode.Algo;

public class AlgoDay1 : IAlgoDay
{
    private readonly string DayNumber;

    public AlgoDay1()
    {
        this.DayNumber = typeof(AlgoDay6).Name.Last().ToString();
    }

    public void Solve1()
    {
        string[] lines = InputProvider.GetContent(DayNumber);

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

    public void Solve2()
    {
        string[] lines = InputProvider.GetContent(DayNumber);

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
