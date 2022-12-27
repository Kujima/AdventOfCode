namespace AdventOfCode.Algo;

using System;

public class AlgoDay4 : IAlgoDay
{
    private readonly string DayNumber;

    public AlgoDay4()
    {
        this.DayNumber = typeof(AlgoDay4).Name.Last().ToString();
    }

    /*
       2-4,6-8
       2-3,4-5
       5-7,7-9
       2-8,3-7
       6-6,4-6
       2-6,4-8
    */

    public void Solve1()
    {
        var lines = InputProvider.GetContent(this.DayNumber);

        int totalFullyContainRange = 0;

        foreach (var pairElves in lines)
        {
            if (
                IsFullyContainRange1(
                    int.Parse(pairElves.Split(',').First().Split('-').First()),
                    int.Parse(pairElves.Split(',').First().Split('-').Last()),
                    int.Parse(pairElves.Split(',').Last().Split('-').First()),
                    int.Parse(pairElves.Split(',').Last().Split('-').Last())
                )
            )
            {
                totalFullyContainRange++;
            }
        }

        Console.WriteLine(totalFullyContainRange);
    }

    private bool IsFullyContainRange1(int s1Start, int s1End, int s2Start, int s2End)
    {
        var s1Range = Enumerable.Range(s1Start, s1End - s1Start + 1);
        if (s1Range.Contains(s2Start) && s1Range.Contains(s2End))
        {
            return true;
        }

        var s2Range = Enumerable.Range(s2Start, s2End - s2Start + 1);
        if (s2Range.Contains(s1Start) && s2Range.Contains(s1End))
        {
            return true;
        }

        return false;
    }

    public void Solve2()
    {
        var lines = InputProvider.GetContent(this.DayNumber);

        int totalFullyContainRange = 0;

        foreach (var pairElves in lines)
        {
            if (
                IsFullyContainRange2(
                    int.Parse(pairElves.Split(',').First().Split('-').First()),
                    int.Parse(pairElves.Split(',').First().Split('-').Last()),
                    int.Parse(pairElves.Split(',').Last().Split('-').First()),
                    int.Parse(pairElves.Split(',').Last().Split('-').Last())
                )
            )
            {
                totalFullyContainRange++;
            }
        }

        Console.WriteLine(totalFullyContainRange);
    }

    private bool IsFullyContainRange2(int s1Start, int s1End, int s2Start, int s2End)
    {
        var s1Range = Enumerable.Range(s1Start, s1End - s1Start + 1);
        if (s1Range.Contains(s2Start) || s1Range.Contains(s2End))
        {
            return true;
        }

        var s2Range = Enumerable.Range(s2Start, s2End - s2Start + 1);
        if (s2Range.Contains(s1Start) || s2Range.Contains(s1End))
        {
            return true;
        }

        return false;
    }
}
