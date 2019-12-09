using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AdventOfCode.IntCode;

namespace AdventOfCode.Day2
{

    public static class Day2
    {

        private static readonly long[] Program;

        static Day2()
        {
            Program = ReadInput();
        }

        public static long Part1()
        {
            var program = (long[])Program.Clone();
            program[1] = 12;
            program[2] = 2;

            var computer = new IntCodeComputer(program);

            var program2 = computer.Execute();
            return program2[0];
        }

        public static int Part2()
        {
            var program = (long[])Program.Clone();

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    program[1] = noun;
                    program[2] = verb;

                    var computer = new IntCodeComputer(program);

                    var program2 = computer.Execute();
                    if (program2[0] == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            return 0;

        }

        private static long[] ReadInput()
        {
            var program = File.ReadAllText(@"Inputs\inputDay2.txt")
                .Split(',')
                .Select(long.Parse)
                .ToArray();

            return program;
        }
    }
}
