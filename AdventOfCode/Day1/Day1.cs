using System;
using System.IO;

namespace AdventOfCode.Day1
{
    public static class Day1
    {
        public static int Execute()
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

            return fuel;
        }
    }
}
