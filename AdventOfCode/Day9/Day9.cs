using System.IO;
using System.Linq;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;

namespace AdventOfCode.Day9
{
    public class Day9
    {
        private static readonly long[] Program = ReadInput();

        public static void Init()
        {
        }

        public static long Part1()
        {
            var outputConsole = new OutputFixed();
            var computer = new IntCodeComputer(new InputFixedValue(1), outputConsole);
            var result = computer.Execute(Program);

            return outputConsole.GetOutPut();
        }

        public static long Part2()
        {
            var outputConsole = new OutputFixed();
            var computer = new IntCodeComputer(new InputFixedValue(2), outputConsole);
            var result = computer.Execute(Program);

            return outputConsole.GetOutPut();
        }

        private static long[] ReadInput()
        {
            var program = File
                .ReadAllText(@"Inputs\inputDay9.txt")
                .Split(',')
                .Select(long.Parse).ToArray();
            return program;
        }
    }
}