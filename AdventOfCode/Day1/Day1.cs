using System;
using System.IO;
using AdventOfCode.Model;

namespace AdventOfCode
{
    public static class Day1
    {
        public static void Execute()
        {
            string line;

            var fuel = 0;

            var file = new StreamReader(@"inputs\inputDay1.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (int.TryParse(line.Trim(), out var weight))
                {
                    fuel = fuel + FuelCalculator.GetFuel(weight);
                }
            }

            Console.WriteLine($"Solution Day 1.2 {fuel}");
        }
    }
}
