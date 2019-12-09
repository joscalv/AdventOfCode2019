using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day10
    {
        private readonly long[] _program = ReadInput();

        public long Part1()
        {
            return 0;
        }

        public long Part2()
        {
            return 0;
        }

        private static long[] ReadInput()
        {
            var program = File
                .ReadAllText(@"Inputs\inputDay10.txt")
                .Split(',')
                .Select(long.Parse).ToArray();
            return program;
        }
    }
}