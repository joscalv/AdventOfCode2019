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
        public static int Part1()
        {
            return Execute(1);
        }

        public static int Part2()
        {
            return Execute(5);
        }

        public static int Execute(int inputValue)
        {
            var program = ReadInput();

            var input = new InputFixedValue(inputValue);
            var output = new OutputFixed();
            var computer = new IntCodeComputer(program, input, output);

            computer.Execute();

            return output.GetOutPut();
        }

        private static int[] ReadInput()
        {
            var program = File.ReadAllText(@"Inputs\inputDay5.txt")
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            return program;
        }
    }
}
