using System.Globalization;

namespace AdventOfCode._2023.Algo;

public class Algo2025Day1
{
    private string[] Lines = InputProvider.GetContent("2025", "1");

    public void Solve1()
    {
        this.Lines = new[] { "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82" };
        var pwd = 0;
        var dialPointer = 50;
        var dialRotate = 0;
        foreach (var line in Lines)
        {
            dialRotate = int.Parse(line.Remove(0, 1));
            if (line.First() is 'R')
            {
                if (dialPointer + dialRotate <= 100)
                {
                    dialPointer += dialRotate;
                    dialRotate = 0;

                    if (dialPointer == 100)
                        dialPointer = 0;
                }
                else
                {
                    dialRotate -= (100 - dialPointer);
                    dialPointer = 0;
                }
            }
            else
            {
                if (dialPointer - dialPointer >= 0)
                {
                    dialPointer -= dialRotate;
                }
                else
                {
                    
                }
            }

            if (dialPointer == 0)
            {
                pwd++;
            }
        }
        Console.WriteLine(pwd);
    }
}
