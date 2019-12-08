using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AdventOfCode;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Day4;
using AdventOfCode.Day5;
using AdventOfCode.Day6;
using AdventOfCode.Day7;
using AdventOfCode.Day8;

namespace AdventOfCode2019Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("AdventOfCode2019");
            Console.WriteLine($"{Environment.NewLine}Day 1");
            ExecuteSolution("2.2 ", Day1.Execute);

            Console.WriteLine($"{Environment.NewLine}Day 2");
            ExecuteSolution("2.1 ", Day2.Part1);
            ExecuteSolution("2.2 ", Day2.Part2);

            Console.WriteLine($"{Environment.NewLine}Day 3");
            Day3.Init();
            ExecuteSolution("3.1.A Minimun distance (using segments): ", Day3.Part1_Version1);
            ExecuteSolution("3.1.B Minimun distance (using all points): ", Day3.Part1_Version2);
            ExecuteSolution("3.2 Sunny with a Chance of Asteroids. Thermal Radiators:", Day3.Part2);

            Console.WriteLine($"{Environment.NewLine}Day 4");
            ExecuteSolution("4.1. Sunny with a Chance of Asteroids: ", Day4.Part1);
            ExecuteSolution("4.2 Sunny with a Chance of Asteroids. Thermal Radiators:", Day4.Part2);


            Console.WriteLine($"{Environment.NewLine}Day 5");
            Day5.Init();
            ExecuteSolution("5.1. Sunny with a Chance of Asteroids: ", Day5.Part1);
            ExecuteSolution("5.2. Sunny with a Chance of Asteroids. Thermal Radiators:", Day5.Part2);


            Console.WriteLine($"{Environment.NewLine}Day 6");
            Day6.Init();
            ExecuteSolution("6.1 The number of orbits is ", Day6.Part1);
            ExecuteSolution("6.2 Steps to get SANTA", Day6.Part2);


            Console.WriteLine($"{Environment.NewLine}Day 7");
            Day7.Init();
            ExecuteSolution("7.1", Day7.Part1);
            ExecuteSolution("7.2", () => Day7.Part2().Result);


            Console.WriteLine($"{Environment.NewLine}Day 8");
            Day8.Init();
            ExecuteSolution("8.1 Complex", Day8.Part1ComplexImage);
            ExecuteSolution("8.1 Simple", Day8.Part1SimpleImage);
            ExecuteSolution("8.2 Complex", Day8.Part2ComplexImage);
            ExecuteSolution("8.2 Simple", Day8.Part2SimpleImage);
        }

        private static void ExecuteSolution(string title, Func<int> solution)
        {
            ExecuteSolution(title, () => solution.Invoke().ToString());
        }

        private static void ExecuteSolution(string title, Func<string> solution)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            var result = solution.Invoke().ToString();
            clock.Stop();
            string separator = (result.Length > 40) ? Environment.NewLine : $"\t";

            Console.WriteLine($"{title}{separator}{result}{separator}{clock.ElapsedMilliseconds} ms.");

        }
    }
}
