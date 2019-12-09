using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;

namespace AdventOfCode.Day5
{

    public class Day5
    {
        private readonly long[] _program = ReadInput();
        public long Part1()
        {
            return Execute(1);
        }

        public long Part2()
        {
            return Execute(5);
        }

        public long Execute(int inputValue)
        {
           

            var input = new InputFixedValue(inputValue);
            var output = new OutputFixed();
            var computer = new IntCodeComputer(input, output);

            computer.Execute(_program);

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
    }
}
