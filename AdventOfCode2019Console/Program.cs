using System;
using System.Threading.Tasks;
using AdventOfCode;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Day4;
using AdventOfCode.Day5;
using AdventOfCode.Day6;
using AdventOfCode.Day7;

namespace AdventOfCode2019Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("AdventOfCode2019");
            Console.WriteLine($"{Environment.NewLine}Day 1");
            Day1.Execute();
            Console.WriteLine($"{Environment.NewLine}Day 2");
            Day2.Execute();
            Console.WriteLine($"{Environment.NewLine}Day 3");
            Day3.Execute();
            Console.WriteLine($"{Environment.NewLine}Day 4");
            Day4.Execute();
            Console.WriteLine($"{Environment.NewLine}Day 5");
            Day5.Execute();
            Console.WriteLine($"{Environment.NewLine}Day 6");
            Day6.Execute();
            Console.WriteLine($"{Environment.NewLine}Day 7");
            await Day7.Execute();

        }
    }
}
