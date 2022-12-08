namespace AdventOfCode.Algo;

using System;

public class AlgoDay4 : IAlgoDay
{
    private readonly string DayNumber;

    public AlgoDay4(string dayNumber)
    {
        DayNumber = dayNumber;
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

        List<ElvePair> elvePairs = new List<ElvePair>();
        List<ElvePair> elvePairFullyContainRange = new List<ElvePair>();

        foreach (var pairElves in lines)
        {
            elvePairs.Add(
                new ElvePair(
                    int.Parse(pairElves.Split(',').First().Split('-').First()),
                    int.Parse(pairElves.Split(',').First().Split('-').Last()),
                    int.Parse(pairElves.Split(',').Last().Split('-').First()),
                    int.Parse(pairElves.Split(',').Last().Split('-').Last())
                )
            );
        }

        foreach (ElvePair e in elvePairs)
        {
            // OneFullyContainSecond
            if (
                e.ElveOneStartSection >= e.ElveSecondStartSection
                && e.ElveOneStartSection <= e.ElveSecondEndSection
            )
            {
                if (
                    e.ElveOneEndSection >= e.ElveSecondStartSection
                    && e.ElveOneEndSection >= e.ElveSecondEndSection
                )
                {
                    elvePairFullyContainRange.Add(e);
                    continue;
                }
            }

            // SecondFullyContainOne
            if (
                e.ElveSecondStartSection >= e.ElveOneStartSection
                && e.ElveSecondStartSection <= e.ElveOneEndSection
            )
            {
                if (
                    e.ElveSecondEndSection >= e.ElveOneStartSection
                    && e.ElveSecondEndSection >= e.ElveOneEndSection
                )
                {
                    elvePairFullyContainRange.Add(e);
                    continue;
                }
            }
        }

        Console.WriteLine(elvePairFullyContainRange.Count());
    }

    private record ElvePair(
        int ElveOneStartSection,
        int ElveOneEndSection,
        int ElveSecondStartSection,
        int ElveSecondEndSection
    );

    public void Solve2() { }
}
