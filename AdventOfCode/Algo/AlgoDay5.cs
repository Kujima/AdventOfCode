namespace AdventOfCode.Algo;

using System;

public class AlgoDay5 : IAlgoDay
{
    private readonly string DayNumber;
    private int HeightStackMax = 0;
    private int NumberOfStacks = 0;
    private Dictionary<int, Stack<char>> Stacks;

    public AlgoDay5(string dayNumber)
    {
        DayNumber = dayNumber;
    }

    public void Solve1()
    {
        var lines = InputProvider.GetContent(this.DayNumber);

        SetFeaturesStacks(lines);

        this.Stacks = SetContentStacks(lines);

        int indexLineStartToMove = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            if (!string.IsNullOrEmpty(lines[i]))
            {
                if (lines[i].First() is 'm')
                {
                    indexLineStartToMove = i;
                    break;
                }
            }
        }

        string instructionLine;
        List<string> instructions = new List<string>();
        for (int j = indexLineStartToMove; j < lines.Length; j++)
        {
            instructionLine = lines[j].Replace("move", "").Replace("from", "").Replace("to", "");
            instructions = instructionLine.Split(' ').Where(x => x != "").ToList();

            MoveCrateTo(
                increment: int.Parse(instructions[0]),
                startStack: int.Parse(instructions[1]),
                destinationStack: int.Parse(instructions[2])
            );
        }

        PrintTopOfAllStacks();
    }

    private void PrintTopOfAllStacks()
    {
        string result = "";
        for (int i = 1; i <= this.NumberOfStacks; i++)
        {
            result = result + this.Stacks[i].Peek().ToString();
        }

        Console.WriteLine(result);
    }

    private void MoveCrateTo(int increment, int startStack, int destinationStack)
    {
        char crate = 'c';
        for (int i = increment; i > 0; i--)
        {
            crate = this.Stacks[startStack].Pop();
            this.Stacks[destinationStack].Push(crate);
        }
    }

    private int GetIndexLineStartToMove(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].First() is 'm')
            {
                return i;
            }
        }
        return -1;
    }

    private Dictionary<int, Stack<char>> SetContentStacks(string[] lines)
    {
        Dictionary<int, Stack<char>> stacks = new Dictionary<int, Stack<char>>();
        for (int i = 1; i <= this.NumberOfStacks; i++)
        {
            stacks.Add(i, new Stack<char>());
        }

        for (int i = this.HeightStackMax - 1; i >= 0; i--)
        {
            var lineCrates = GetFormatLine(lines[i]);
            for (int j = 0; j < lineCrates.Length; j++)
            {
                if (char.IsLetter(lineCrates[j]))
                {
                    stacks[j + 1].Push(lineCrates[j]);
                }
            }
        }

        return stacks;
    }

    private string GetFormatLine(string line)
    {
        string lineResult = "";

        for (int i = 1; i < line.Length; i += 4)
        {
            lineResult = lineResult + line[i];
        }
        return lineResult;
    }

    public void SetFeaturesStacks(string[] lines)
    {
        int number;
        foreach (var line in lines)
        {
            var splitLines = line.Split(' ').Where(x => x != "");
            if (int.TryParse(splitLines.First(), out number))
            {
                this.NumberOfStacks = int.Parse(splitLines.Last());
                break;
            }
            this.HeightStackMax++;
        }
    }

    public void Solve2() { }
}
