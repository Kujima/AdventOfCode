namespace AdventOfCode.Algo;

using System;

public class AlgoDay9 : IAlgoDay
{
    private readonly string DayNumber;
    private readonly string[] Lines;

    public AlgoDay9()
    {
        this.DayNumber = typeof(AlgoDay9).Name.Last().ToString();
        this.Lines = InputProvider.GetContent(this.DayNumber);
    }

    // https://learn.microsoft.com/fr-fr/dotnet/api/system.tuple-4?view=net-7.0

    public void Solve1()
    {
        string[] instructions;
        string direction;
        int steps = 0;
        List<string[]> registeredPosition = new List<string[]>();

        foreach (var line in this.Lines)
        {
            instructions = line.Split(' ');
            direction = instructions[0];
            steps = int.Parse(instructions[1]);
        }
    }

    public void Solve2() { }
}
