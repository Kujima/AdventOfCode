using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024.Algo;

public class Algo2024Day1 : IAlgoDay
{
    private string[] Lines;

    public Algo2024Day1()
    {
        this.Lines = InputProvider.GetContent("1");
    }

    public void Solve1()
    {
        (List<int> listA, List<int> listB) = TransformeLinesTo2IntList();

        int total = 0;
        int numberA = 0;
        int numberB = 0;

        while (listA.Any())
        {
            numberA = listA.OrderBy(x => x).First();
            numberB = listB.OrderBy(x => x).First();

            if (numberA > numberB)
            {
                total += (numberA - numberB);
            }
            else
            {
                total += (numberB - numberA);
            }

            listA.Remove(numberA);
            listB.Remove(numberB);
        }

        Console.WriteLine(total);
    }

    public void Solve2()
    {
        (List<int> listA, List<int> listB) = TransformeLinesTo2IntList();

        int total = 0;
        int totalCount = 0;

        foreach (int numberA in listA)
        {
            totalCount = listB.Where(numberB => numberB == numberA).Count();

            total += (numberA * totalCount);
        }

        Console.WriteLine(total);
    }

    private (List<int> listA, List<int> listB) TransformeLinesTo2IntList()
    {
        var listA = new List<int>();
        var listB = new List<int>();

        foreach (var line in this.Lines)
        {
            var temp = line.Split("   ");
            listA.Add(Convert.ToInt32(temp.First()));
            listB.Add(Convert.ToInt32(temp.Last()));
        }

        return (listA, listB);
    }
}
