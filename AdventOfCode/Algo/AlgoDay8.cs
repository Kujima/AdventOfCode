namespace AdventOfCode.Algo;

using System;

public class AlgoDay8 : IAlgoDay
{
    private readonly string DayNumber;

    public AlgoDay8()
    {
        this.DayNumber = typeof(AlgoDay8).Name.Last().ToString();
    }

    public void Solve1()
    {
        var lines = InputProvider.GetContent(this.DayNumber);

        var nbrTreesVisible = 0;

        var yMax = lines.Count();
        var xMax = lines[0].Length;
        var test = "";

        var x = 0;
        var y = 0;

        while (y <= yMax)
        {
            while (x <= xMax)
            {
                if (x == 0 || y == 0 || x == xMax - 1 || y == yMax - 1)
                {
                    nbrTreesVisible++;
                    test = test + "A";
                }
                else
                {
                    test = test + "P";
                }
                x++;
            }

            Console.WriteLine(test);

            y++;
            x = 0;
        }
    }

    public void Solve2() { }
}
