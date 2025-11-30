namespace AdventOfCode._2023.Algo;

public class AlgoDay3
{
    private string[] Lines;

    public AlgoDay3()
    {
        this.Lines = InputProvider.GetContent("2023", "3");
    }

    public void Solve1()
    {
        var stringNumber = string.Empty;
        var RightNumbers = new List<int>();
        int y = 0;
        int x = 0;
        int z = 0;
        int zMax = 0;
        int positionStartNumber = 0;
        int positionEndNumber = 0;
        bool topRightNumber = false;

        while (y < Lines.Length)
        {
            x = 0;
            while (x < Lines[y].Length)
            {
                topRightNumber = false;

                z = 0;

                if (char.IsDigit(Lines[y][x]))
                {
                    positionStartNumber = x;
                    z = x;

                    while (z < Lines[y].Length && char.IsDigit(Lines[y][z]))
                    {
                        Console.WriteLine(Lines[y][z]);
                        z++;
                    }
                    positionEndNumber = z - 1;

                    // check même ligne à gauche
                    if (positionStartNumber - 1 >= 0)
                    {
                        if (
                            Lines[y][positionStartNumber - 1] != '.'
                            && !char.IsDigit(Lines[y][positionStartNumber - 1])
                        )
                        {
                            topRightNumber = true;
                        }
                    }

                    // check même ligne à droite
                    if (positionEndNumber + 1 < Lines[y].Length && topRightNumber == false)
                    {
                        if (
                            Lines[y][positionEndNumber + 1] != '.'
                            && !char.IsDigit(Lines[y][positionStartNumber + 1])
                        )
                        {
                            topRightNumber = true;
                        }
                    }

                    // check ligne du dessus
                    if (topRightNumber == false && y - 1 >= 0)
                    {
                        if (positionStartNumber == 0)
                        {
                            z = 0;
                        }
                        else
                        {
                            z = positionStartNumber - 1;
                        }

                        if (positionEndNumber == Lines[y - 1].Length - 1)
                        {
                            zMax = positionEndNumber;
                        }
                        else
                        {
                            zMax = positionEndNumber + 1;
                        }
                        while (topRightNumber == false && z <= zMax)
                        {
                            if (Lines[y - 1][z] != '.' && !char.IsDigit(Lines[y - 1][z]))
                            {
                                topRightNumber = true;
                            }

                            z++;
                        }
                    }

                    // check ligne du dessous
                    if (topRightNumber == false && y + 1 < Lines[y].Length)
                    {
                        if (positionStartNumber == 0)
                        {
                            z = 0;
                        }
                        else
                        {
                            z = positionStartNumber - 1;
                        }

                        if (positionEndNumber == Lines[y + 1].Length - 1)
                        {
                            zMax = positionEndNumber;
                        }
                        else
                        {
                            zMax = positionEndNumber + 1;
                        }
                        while (topRightNumber == false && z <= zMax)
                        {
                            if (Lines[y + 1][z] != '.' && !char.IsDigit(Lines[y + 1][z]))
                            {
                                topRightNumber = true;
                            }

                            z++;
                        }
                    }

                    if (topRightNumber)
                    {
                        z = positionStartNumber;
                        stringNumber = string.Empty;
                        while (z <= positionEndNumber)
                        {
                            stringNumber = stringNumber + Lines[y][z].ToString();
                            z++;
                        }

                        RightNumbers.Add(int.Parse(stringNumber));
                    }

                    x = positionEndNumber + 1;
                }
                else
                {
                    x++;
                }
            }
            y++;
        }

        Console.WriteLine(RightNumbers.Sum());
    }

    public void Solve2() { }
}
