using System.Globalization;

namespace AdventOfCode._2023.Algo;

public class AlgoDay1 : IAlgoDay
{
    private string[] Lines;

    public AlgoDay1()
    {
        var dayNumber = typeof(AlgoDay1).Name.Last().ToString();
        this.Lines = InputProvider.GetContent(dayNumber);
    }

    public void Solve1()
    {
        int firstDigit = 0;
        int lastDigit = 0;

        var calibrationsValues = new List<int>();

        foreach (var line in this.Lines)
        {
            firstDigit = 0;
            lastDigit = 0;

            foreach (var caracter in line)
            {
                if (char.IsDigit(caracter))
                {
                    firstDigit = (int)char.GetNumericValue(caracter);
                    break;
                }
            }

            foreach (char caracter in line.Reverse())
            {
                if (char.IsDigit(caracter))
                {
                    lastDigit = (int)char.GetNumericValue(caracter);
                    break;
                }
            }

            calibrationsValues.Add(Int32.Parse("" + firstDigit + lastDigit));
        }

        var result = calibrationsValues.Sum();
        Console.WriteLine(result);
    }

    public void Solve2()
    {
        int firstDigit = 0;
        int lastDigit = 0;

        var calibrationsValues = new List<int>();
        var stringsDigit = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        };

        string subStringLine = "";
        CultureInfo ci;

        foreach (var line in this.Lines)
        {
            firstDigit = 0;
            lastDigit = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    firstDigit = (int)char.GetNumericValue(line[i]);
                    break;
                }
                else
                {
                    subStringLine = line.Substring(i);
                    foreach (var stringDigit in stringsDigit)
                    {
                        if (subStringLine.StartsWith(stringDigit.Key))
                        {
                            firstDigit = stringDigit.Value;
                            break;
                        }
                    }

                    if (firstDigit != 0)
                    {
                        break;
                    }
                }
            }

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    lastDigit = (int)char.GetNumericValue(line[i]);
                    break;
                }
                else
                {
                    subStringLine = line.Substring(i);
                    foreach (var stringDigit in stringsDigit)
                    {
                        if (subStringLine.StartsWith(stringDigit.Key))
                        {
                            lastDigit = stringDigit.Value;
                            break;
                        }
                    }

                    if (lastDigit != 0)
                    {
                        break;
                    }
                }
            }

            calibrationsValues.Add(Int32.Parse("" + firstDigit + lastDigit));
        }
        var result = calibrationsValues.Sum();
        Console.WriteLine(result);
    }
}
