namespace AdventOfCode.Algo;

using System;

public class AlgoDay8 : IAlgoDay
{
    private readonly string DayNumber;
    private readonly string[] Lines;
    private readonly int YMax;
    private readonly int XMax;

    public AlgoDay8()
    {
        this.DayNumber = typeof(AlgoDay8).Name.Last().ToString();
        this.Lines = InputProvider.GetContent(this.DayNumber);
        this.YMax = Lines.Length;
        this.XMax = Lines[0].Length;
    }

    public void Solve1()
    {
        var nbrTreesVisible = 0;

        var x = 0;
        var y = 0;

        while (y < YMax)
        {
            while (x < XMax)
            {
                if (x == 0 || y == 0 || x == XMax - 1 || y == YMax - 1)
                {
                    nbrTreesVisible++;
                }
                else
                {
                    if (IsVilibleOnTopSide(x, y))
                    {
                        nbrTreesVisible++;
                    }
                    else if (IsVilibleOnBottomSide(x, y))
                    {
                        nbrTreesVisible++;
                    }
                    else if (IsVilibleOnLeftSide(x, y))
                    {
                        nbrTreesVisible++;
                    }
                    else if (IsVilibleOnRightSide(x, y))
                    {
                        nbrTreesVisible++;
                    }
                }
                x++;
            }
            y++;
            x = 0;
        }

        Console.WriteLine(nbrTreesVisible);
    }

    public bool IsVilibleOnTopSide(int x, int y)
    {
        var treeCHeck = this.Lines[y][x];
        y--;
        while (y >= 0)
        {
            if (treeCHeck <= this.Lines[y][x])
            {
                return false;
            }
            y--;
        }

        return true;
    }

    public bool IsVilibleOnBottomSide(int x, int y)
    {
        var treeCHeck = this.Lines[y][x];
        y++;
        while (y < YMax)
        {
            if (treeCHeck <= this.Lines[y][x])
            {
                return false;
            }
            y++;
        }

        return true;
    }

    public bool IsVilibleOnRightSide(int x, int y)
    {
        var treeCHeck = this.Lines[y][x];
        x++;
        while (x < XMax)
        {
            if (treeCHeck <= this.Lines[y][x])
            {
                return false;
            }
            x++;
        }

        return true;
    }

    public bool IsVilibleOnLeftSide(int x, int y)
    {
        var treeCHeck = this.Lines[y][x];
        x--;
        while (x >= 0)
        {
            if (treeCHeck <= this.Lines[y][x])
            {
                return false;
            }
            x--;
        }

        return true;
    }

    public void Solve2()
    {
        List<int> listScenicScore = new();
        var x = 0;
        var y = 0;

        while (y < YMax)
        {
            while (x < XMax)
            {
                if (x == 0 || y == 0 || x == XMax - 1 || y == YMax - 1)
                {
                    listScenicScore.Add(0);
                }
                else
                {
                    listScenicScore.Add(
                        GetTopScenicScore(x, y)
                            * GetBottomScenicScore(x, y)
                            * GetRightScenicScore(x, y)
                            * GetLeftScenicScore(x, y)
                    );
                }
                x++;
            }
            y++;
            x = 0;
        }

        Console.WriteLine(listScenicScore.OrderByDescending(x => x).First());
    }

    private int GetLeftScenicScore(int x, int y)
    {
        var treeCHeck = this.Lines[y][x];
        var scenicScoreTree = 0;
        x--;
        while (x >= 0)
        {
            scenicScoreTree++;
            if (treeCHeck <= this.Lines[y][x])
            {
                return scenicScoreTree;
            }
            x--;
        }

        return scenicScoreTree;
    }

    private int GetRightScenicScore(int x, int y)
    {
        var treeCHeck = this.Lines[y][x];
        var scenicScoreTree = 0;
        x++;
        while (x < XMax)
        {
            scenicScoreTree++;
            if (treeCHeck <= this.Lines[y][x])
            {
                return scenicScoreTree;
            }
            x++;
        }

        return scenicScoreTree;
    }

    private int GetBottomScenicScore(int x, int y)
    {
        var treeCHeck = this.Lines[y][x];
        var scenicScoreTree = 0;
        y++;
        while (y < YMax)
        {
            scenicScoreTree++;
            if (treeCHeck <= this.Lines[y][x])
            {
                return scenicScoreTree;
            }
            y++;
        }

        return scenicScoreTree;
    }

    private int GetTopScenicScore(int x, int y)
    {
        var treeCHeck = this.Lines[y][x];
        var scenicScoreTree = 0;
        y--;
        while (y >= 0)
        {
            scenicScoreTree++;
            if (treeCHeck <= this.Lines[y][x])
            {
                return scenicScoreTree;
            }
            y--;
        }

        return scenicScoreTree;
    }
}
