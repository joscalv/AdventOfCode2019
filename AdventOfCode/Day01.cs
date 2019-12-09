using System.IO;
using AdventOfCode.Day1;

namespace AdventOfCode
{
    public  class Day01
    {
        public int Execute()
        {
            string line;

            var fuel = 0;

            var file = new StreamReader(@"inputs\inputDay01.txt");
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
