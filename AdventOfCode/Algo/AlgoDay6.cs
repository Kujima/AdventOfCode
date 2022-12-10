namespace AdventOfCode.Algo;

using System;

public class AlgoDay6 : IAlgoDay
{
    private readonly string DayNumber;

    public AlgoDay6(string dayNumber)
    {
        DayNumber = dayNumber;
    }

    public void Solve1()
    {
        var datastream = InputProvider.GetContent(this.DayNumber).First();
        List<char> chars = new List<char>();
        int indexStartMsgStream = 0;
        for (int i = 0; i < datastream.Length; i++)
        {
            chars.Add(datastream[i]);

            if (chars.Count >= 4)
            {
                if (IsFirstMarker(chars))
                {
                    indexStartMsgStream = i;
                    break;
                }

                chars.Remove(chars.First());
            }
        }

        Console.WriteLine(indexStartMsgStream + 1);
    }

    private bool IsFirstMarker(List<char> chars)
    {
        foreach (var caractere in chars)
        {
            if (chars.GroupBy(c => c).Any(g => g.Count() > 1))
            {
                return false;
            }
        }

        return true;
    }

    public void Solve2()
    {
        var datastream = InputProvider.GetContent(this.DayNumber).First();
        List<char> chars = new List<char>();
        int indexStartMsgStream = 0;
        for (int i = 0; i < datastream.Length; i++)
        {
            chars.Add(datastream[i]);

            if (chars.Count >= 14)
            {
                if (IsFirstMarker(chars))
                {
                    indexStartMsgStream = i;
                    break;
                }

                chars.Remove(chars.First());
            }
        }

        Console.WriteLine(indexStartMsgStream + 1);
    }
}
