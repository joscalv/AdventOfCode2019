using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;

namespace AdventOfCode.Day5
{

    public static class Day5
    {
        private static readonly long[] Program = ReadInput();
        public static long Part1()
        {
            return Execute(1);
        }

        public static long Part2()
        {
            return Execute(5);
        }

        public static long Execute(int inputValue)
        {
           

            var input = new InputFixedValue(inputValue);
            var output = new OutputFixed();
            var computer = new IntCodeComputer(Program, input, output);

            computer.Execute();

            return output.GetOutPut();
        }

        private static long[] ReadInput()
        {
            var program = File.ReadAllText(@"Inputs\inputDay5.txt")
                .Split(',')
                .Select(long.Parse)
                .ToArray();
            return program;
        }

        public static void Init()
        {
        }
    }
}
