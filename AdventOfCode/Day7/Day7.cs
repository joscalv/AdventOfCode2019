using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;

namespace AdventOfCode.Day7
{
    public class Day7
    {
        static async Task Execute(string[] args)
        {
            //var result = Part1();
            //Console.WriteLine($"Result part 1: {result}");

            var result2 = await Part2();
            Console.WriteLine($"Result part 2: {result2}");

        }

        public static int Part1()
        {
            var program = ReadInput();
            return Day7Part1.AmplificationCircuit(program);
        }

        public static async Task<int> Part2()
        {
            var program = ReadInput();
            return await Day7Part2.AmplificationCircuitWithFeedbackLoop(program);
        }

        private static int[] ReadInput()
        {
            var program = File
                .ReadAllText(@"Inputs\inputDay7.txt")
                .Split(',')
                .Select(int.Parse).ToArray();
            return program;
        }
    }

    public static class Day7Part1
    {
        public static int AmplificationCircuit(int[] program)
        {
            var combinations = Utils.GetCombinations(0, 4);
            int outputE = 0;
            foreach (var c in combinations)
            {
                var outputA = ExecuteAmplifierControllerSoftware(program, c.A, 0);
                var outputB = ExecuteAmplifierControllerSoftware(program, c.B, outputA);
                var outputC = ExecuteAmplifierControllerSoftware(program, c.C, outputB);
                var outputD = ExecuteAmplifierControllerSoftware(program, c.D, outputC);
                var tmp = ExecuteAmplifierControllerSoftware(program, c.E, outputD);
                outputE = tmp > outputE ? tmp : outputE;
            }

            return outputE;
        }

        public static int ExecuteAmplifierControllerSoftware(int[] program, int setting, int previousOutput)
        {
            var inputConsole = new InputFixedList(setting, previousOutput);
            var outputConsole = new OutputFixed();
            IntCodeComputer computer = new IntCodeComputer((int[])program.Clone(), inputConsole, outputConsole);
            computer.Execute();
            return outputConsole.GetOutPut();
        }
    }

    public static class Day7Part2
    {
        public static async Task<int> AmplificationCircuitWithFeedbackLoop(int[] program)
        {
            var combinations = Utils.GetCombinations(5, 9);
            int result = 0;
            foreach (var combination in combinations)
            {
                var candidate = await ExecuteCombinationWithFeedback(program, combination);
                result = candidate > result ? candidate : result;
            }

            return result;
        }

        public static async Task<int> ExecuteCombinationWithFeedback(int[] program, (int A, int B, int C, int D, int E) combination)
        {
            var c1 = new InputOutputLinked(combination.A, 0);
            var c2 = new InputOutputLinked(combination.B);
            var c3 = new InputOutputLinked(combination.C);
            var c4 = new InputOutputLinked(combination.D);
            var c5 = new InputOutputLinked(combination.E);

            var computer1 = new IntCodeComputer((int[])program.Clone(), c1, c2);
            var computer2 = new IntCodeComputer((int[])program.Clone(), c2, c3);
            var computer3 = new IntCodeComputer((int[])program.Clone(), c3, c4);
            var computer4 = new IntCodeComputer((int[])program.Clone(), c4, c5);
            var computer5 = new IntCodeComputer((int[])program.Clone(), c5, c1);

            var t1 = Task.Run(() => computer1.Execute());
            var t2 = Task.Run(() => computer2.Execute());
            var t3 = Task.Run(() => computer3.Execute());
            var t4 = Task.Run(() => computer4.Execute());
            var t5 = Task.Run(() => computer5.Execute());

            await Task.WhenAll(t1, t2, t3, t4, t5);

            return c1.GetOutput();
        }
    }


    public static class Utils
    {
        public static List<(int A, int B, int C, int D, int E)> GetCombinations(int min, int max)
        {
            var combinations = new List<(int A, int B, int C, int D, int E)>();

            for (int a = min; a <= max; a++)
            {
                for (int b = min; b <= max; b++)
                {
                    if (a != b)
                    {
                        for (int c = min; c <= max; c++)
                        {
                            if (c != a && c != b)
                            {
                                for (int d = min; d <= max; d++)
                                {
                                    if (d != a && d != b && d != c)
                                    {

                                        for (int e = min; e <= max; e++)
                                        {
                                            if (e != a && e != b && e != c && e != d)
                                            {
                                                combinations.Add((a, b, c, d, e));
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return combinations;
        }
    }

}
