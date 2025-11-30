namespace AdventOfCode._2023.Algo;

public class AlgoDay2
{
    private string[] Lines;

    public AlgoDay2()
    {
        this.Lines = InputProvider.GetContent("2023", "2");
    }

    public void Solve1()
    {
        var maxColorCubes = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 },
        };
        int sumIdsGame = 0;
        var cptGame = 0;
        var valueColor = 0;
        bool isWrongGame = false;
        foreach (var line in this.Lines)
        {
            cptGame++;
            isWrongGame = false;

            var found = line.IndexOf(": ");
            var game = line.Substring(found + 2);

            var sets = game.Split("; ");

            foreach (var set in sets)
            {
                var cubesPulled = set.Split(", ");
                foreach (var colorCubes in cubesPulled)
                {
                    foreach (var maxColorCube in maxColorCubes)
                    {
                        if (colorCubes.Contains(maxColorCube.Key))
                        {
                            valueColor = int.Parse(colorCubes.Split(" ").First());

                            if (valueColor > maxColorCube.Value)
                            {
                                isWrongGame = true;
                                break;
                            }
                        }
                    }

                    if (isWrongGame)
                    {
                        break;
                    }
                }
                if (isWrongGame)
                {
                    break;
                }
            }
            if (!isWrongGame)
            {
                sumIdsGame = sumIdsGame + cptGame;
            }
        }
        Console.WriteLine(sumIdsGame);
    }

    public void Solve2()
    {
        var minRedCubes = 0;
        var minGreenCubes = 0;
        var minBlueCubes = 0;

        var valueColor = 0;
        var sumPowerSets = 0;

        foreach (var line in Lines)
        {
            minRedCubes = 0;
            minGreenCubes = 0;
            minBlueCubes = 0;

            var found = line.IndexOf(": ");
            var game = line.Substring(found + 2);

            var sets = game.Split("; ");

            foreach (var set in sets)
            {
                var cubesPulled = set.Split(", ");
                foreach (var colorCubes in cubesPulled)
                {
                    valueColor = int.Parse(colorCubes.Split(" ").First());

                    if (colorCubes.Contains("red"))
                    {
                        if (minRedCubes < valueColor)
                        {
                            minRedCubes = valueColor;
                        }
                    }
                    else if (colorCubes.Contains("green"))
                    {
                        if (minGreenCubes < valueColor)
                        {
                            minGreenCubes = valueColor;
                        }
                    }
                    else if (colorCubes.Contains("blue"))
                    {
                        if (minBlueCubes < valueColor)
                        {
                            minBlueCubes = valueColor;
                        }
                    }
                }
            }

            sumPowerSets = sumPowerSets + (minRedCubes * minGreenCubes * minBlueCubes);
        }

        Console.WriteLine(sumPowerSets);
    }
}
