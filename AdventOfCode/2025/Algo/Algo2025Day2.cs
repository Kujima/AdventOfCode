using System.Globalization;

namespace AdventOfCode._2025.Algo;

public class Algo2025Day2
{
    private string[] Input = InputProvider.GetContent("2025", "2");

    public void Solve1()
    {
        long min = 0;
        long max = 0;
        long result = 0;
        var rangesIds = Input.First().Split(",");
        foreach (var range in rangesIds)
        {
            Console.WriteLine(range);
            var temp = range.Split("-");
            min = long.Parse(temp.First());
            max = long.Parse(temp.Last());

            for (var i = min; i <= max; i++)
            {
                if (!IsValidId(Convert.ToString(i)))
                    result += i;

                i++;
            }
        }
        Console.WriteLine(result);
    }

    private bool IsValidId(string id)
    {
        if (Decimal.Remainder(id.Length, 2) != 0)
            return false;

        var part1 = id.Substring(0, id.Length / 2);
        var part2 = id.Substring(id.Length / 2);

        if (part1 == part2)
            return true;

        return false;
    }
}
