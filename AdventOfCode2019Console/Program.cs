﻿using System;
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
            ExecuteSolution("2.2 ", Day1.Execute);

            Console.WriteLine($"{Environment.NewLine}--- Day 2: 1202 Program Alarm ---");
            ExecuteSolution("2.1 ", Day2.Part1);
            ExecuteSolution("2.2 ", Day2.Part2);

            Console.WriteLine($"{Environment.NewLine}--- Day 3: Crossed Wires ---");
            Day3.Init();
            ExecuteSolution("3.1.A Minimun distance (using segments) ", Day3.Part1_Version1);
            ExecuteSolution("3.1.B Minimun distance (using all points) ", Day3.Part1_Version2);
            ExecuteSolution("3.2   Sunny with a Chance of Asteroids. Thermal Radiators", Day3.Part2);

            Console.WriteLine($"{Environment.NewLine}--- Day 4: Secure Container ---");
            ExecuteSolution("4.1 Sunny with a Chance of Asteroids ", Day4.Part1);
            ExecuteSolution("4.2 Sunny with a Chance of Asteroids. Thermal Radiators", Day4.Part2);


            Console.WriteLine($"{Environment.NewLine}--- Day 5: Sunny with a Chance of Asteroids ---");
            Day5.Init();
            ExecuteSolution("5.1 Sunny with a Chance of Asteroids ", Day5.Part1);
            ExecuteSolution("5.2 Sunny with a Chance of Asteroids. Thermal Radiators:", Day5.Part2);


            Console.WriteLine($"{Environment.NewLine}--- Day 6: Universal Orbit Map ---");
            Day6.Init();
            ExecuteSolution("6.1 The number of orbits is ", Day6.Part1);
            ExecuteSolution("6.2 Steps to get SANTA", Day6.Part2);


            Console.WriteLine($"{Environment.NewLine}--- Day 7: Amplification Circuit ---");
            Day7.Init();
            ExecuteSolution("7.1 Amplification Circuit", Day7.Part1);
            ExecuteSolution("7.2 Amplification Circuit with Feedback loop", () => Day7.Part2().Result);


            Console.WriteLine($"{Environment.NewLine}--- Day 8: Space Image Format ---");
            Day8.Init();
            ExecuteSolution("8.1 Count Zeros Complex", Day8.Part1ComplexImage);
            ExecuteSolution("8.1 Count Zeros Simple", Day8.Part1SimpleImage);
            ExecuteSolution("8.2 Decode Image Complex", Day8.Part2ComplexImage);
            ExecuteSolution("8.2 Decode Image Simple", Day8.Part2SimpleImage);

            Console.WriteLine($"{Environment.NewLine}--- Day 9: Sensor Boost ---");
            Day9.Init();
            ExecuteSolution("9.1 BOOST keycode", Day9.Part1);
            ExecuteSolution("9.2 Coordinates of the distress signal", Day9.Part2);
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
