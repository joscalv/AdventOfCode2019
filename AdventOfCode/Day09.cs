using System.IO;
using System.Linq;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;

namespace AdventOfCode
{
    public class Day09
    {
        private readonly long[] _program = ReadInput();

        public long Part1()
        {
            var outputConsole = new OutputFixed();
            var computer = new IntCodeComputer(new InputFixedValue(1), outputConsole);
            var result = computer.Execute(_program);

            return outputConsole.GetOutPut();
        }

        public long Part2()
        {
            var outputConsole = new OutputFixed();
            var computer = new IntCodeComputer(new InputFixedValue(2), outputConsole);
            var result = computer.Execute(_program);

            return outputConsole.GetOutPut();
        }

        private static long[] ReadInput()
        {
            var program = File
                .ReadAllText(@"Inputs\inputDay09.txt")
                .Split(',')
                .Select(long.Parse).ToArray();
            return program;
        }
    }
}