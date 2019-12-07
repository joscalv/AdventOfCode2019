using System;
using System.IO;
using System.Linq;
using AdventOfCode.IntCode;

namespace AdventOfCode.Day2
{

    public static class Day2
    {
        public static void Execute()
        {
            //Input 1
            var result1 = Day2.Part1();
            Console.WriteLine($"Solution Day 2.1 {result1}");
            //Input 5
            var result2 = Day2.Part2();
            Console.WriteLine($"Solution Day 2.2 {result1}");
        }

        public static int Part1()
        {
            var program = ReadInput();
            program[1] = 12;
            program[2] = 2;

            var computer = new IntCodeComputer(program);

            var program2 = computer.Execute();
            return program2[0];
        }

        public static int Part2()
        {
            var program = ReadInput();

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

        private static int[] ReadInput()
        {
            var program = File.ReadAllText(@"Inputs\inputDay2.txt")
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            return program;
        }
    }
}
