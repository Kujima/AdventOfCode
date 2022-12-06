namespace AdventOfCode;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class InputProvider
{
    public static string[] GetContent(string InputPath)
    {
        string[] lines = File.ReadAllLines(InputPath);
        return lines;
    }
}
