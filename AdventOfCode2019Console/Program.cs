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
using AdventOfCode.Day9;

namespace AdventOfCode2019Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("*** AdventOfCode2019 ***");
            Console.WriteLine($"{Environment.NewLine}--- Day 1: The Tyranny of the Rocket Equation ---");
            var day1 = new Day1();
            ExecuteSolution("2.2 ", day1.Execute);

            Console.WriteLine($"{Environment.NewLine}--- Day 2: 1202 Program Alarm ---");
            var day2 = new Day2();
            ExecuteSolution("2.1 ", day2.Part1);
            ExecuteSolution("2.2 ", day2.Part2);

            Console.WriteLine($"{Environment.NewLine}--- Day 3: Crossed Wires ---");
            var day3 = new Day3();
            ExecuteSolution("3.1.A Minimun distance (using segments) ", day3.Part1_Version1);
            ExecuteSolution("3.1.B Minimun distance (using all points) ", day3.Part1_Version2);
            ExecuteSolution("3.2   Sunny with a Chance of Asteroids. Thermal Radiators", day3.Part2);

            Console.WriteLine($"{Environment.NewLine}--- Day 4: Secure Container ---");
            var day4= new Day4();
            ExecuteSolution("4.1 Sunny with a Chance of Asteroids ", day4.Part1);
            ExecuteSolution("4.2 Sunny with a Chance of Asteroids. Thermal Radiators", day4.Part2);


            Console.WriteLine($"{Environment.NewLine}--- Day 5: Sunny with a Chance of Asteroids ---");
            var day5 = new Day5();
            ExecuteSolution("5.1 Sunny with a Chance of Asteroids ", day5.Part1);
            ExecuteSolution("5.2 Sunny with a Chance of Asteroids. Thermal Radiators:", day5.Part2);


            Console.WriteLine($"{Environment.NewLine}--- Day 6: Universal Orbit Map ---");
            var day6 = new Day6();
            ExecuteSolution("6.1 The number of orbits is ", day6.Part1);
            ExecuteSolution("6.2 Steps to get SANTA", day6.Part2);


            Console.WriteLine($"{Environment.NewLine}--- Day 7: Amplification Circuit ---");
            var day7 = new Day7();
            ExecuteSolution("7.1 Amplification Circuit", day7.Part1);
            ExecuteSolution("7.2 Amplification Circuit with Feedback loop", () => day7.Part2().Result);


            Console.WriteLine($"{Environment.NewLine}--- Day 8: Space Image Format ---");
            var day8 = new Day8();
            ExecuteSolution("8.1 Count Zeros Complex", day8.Part1ComplexImage);
            ExecuteSolution("8.1 Count Zeros Simple", day8.Part1SimpleImage);
            ExecuteSolution("8.2 Decode Image Complex", day8.Part2ComplexImage);
            ExecuteSolution("8.2 Decode Image Simple", day8.Part2SimpleImage);

            Console.WriteLine($"{Environment.NewLine}--- Day 9: Sensor Boost ---");
            var day9 = new Day9();
            ExecuteSolution("9.1 BOOST keycode", day9.Part1);
            ExecuteSolution("9.2 Coordinates of the distress signal", day9.Part2);
        }

        private static void ExecuteSolution(string title, Func<long> solution)
        {
            ExecuteSolution(title, () => solution.Invoke().ToString());
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
