using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode
{
    public class Day12
    {
        //private readonly Step _input = ReadInput();

        private readonly Step _input = ReadInput();

        public int Part1()
        {
            var stepN = _input;

            for (int i=0; i < 1000; i++)
            {
                stepN = stepN.GetNextStep();
            }

            return stepN.GetTotalEnergy();
        }

        public int Part2()
        {
            return 0;
        }

        private static Step ReadInput()
        {
            return File
                .ReadAllText(@"Inputs\inputDay12.txt")
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(Day12Utils.ParseInput)
                .Select(coordinates => new int[] { coordinates[0], coordinates[1], coordinates[2], 0, 0, 0 })
                .ToList()
            .ToStep();


        }

        private static int ParseValue(string step, string init, string end)
        {
            int initIndex = step.IndexOf(init, StringComparison.Ordinal) + init.Length;
            int endIndex = step.IndexOf(end, StringComparison.Ordinal);
            return int.Parse(step.Substring(initIndex, endIndex - initIndex));
        }
    }

    public class Step
    {
        public const int NumberOfMoons = 4;
        public const int Dimmensions = 3;

        public Step()
        {

        }

        public Step(int[,] status)
        {
            _status = status;
        }

        readonly int[,] _status = new int[NumberOfMoons, Dimmensions * 2];

        public int[,] Status => _status;

        public Step GetNextStep()
        {
            var nextStep = new Step((int[,])_status.Clone());

            for (int coordinate = 0; coordinate < Dimmensions; coordinate++)
            {
                for (int moon = 0; moon < NumberOfMoons; moon++)
                {
                    for (int j = 0; j < NumberOfMoons; j++)
                    {
                        if (moon != j)
                        {
                            var nextSpeed = GetSpeed(nextStep, moon, coordinate);
                            if (Status[moon, coordinate] < Status[j, coordinate])
                            {
                                nextSpeed = GetSpeed(nextStep, moon, coordinate) + 1;
                            }
                            else if (Status[moon, coordinate] > Status[j, coordinate])
                            {
                                nextSpeed = GetSpeed(nextStep, moon, coordinate) - 1;
                            }

                            nextStep.Status[moon, coordinate + Dimmensions] = nextSpeed;
                            nextStep.Status[moon, coordinate] = Status[moon, coordinate] + nextSpeed;

                        }
                    }
                }
            }

            return nextStep;
        }

        private static int GetSpeed(Step step, int moon, int coordinate)
        {
            return step.Status[moon, coordinate + Dimmensions];
        }

        private int GetSum(int moon, int initDimension)
        {
            var potential = 0;
            for (int coordinate = initDimension; coordinate < initDimension + Dimmensions; coordinate++)
            {
                potential = potential + Math.Abs(_status[moon, coordinate]);
            }

            return potential;
        }

        public int GetPotential(int moon)
        {
            return GetSum(moon, 0);
        }

        public int GetKinetic(int moon)
        {
            return GetSum(moon, Dimmensions);

            
        }

        public int GetTotalEnergy()
        {
            int totalEnergy = 0;
            for (int moon = 0; moon < NumberOfMoons; moon++)
            {
                totalEnergy = totalEnergy + GetPotential(moon) * GetKinetic(moon);
            }

            return totalEnergy;
        }
    }

    public class MoonStatus
    {
        public MoonStatus()
        {

        }
        public MoonStatus(int[] values)
        {
            Values = values;
        }
        public int[] Values { get; set; }
    }

    public class Position
    {
        public Position()
        {
        }

        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }



    public static class Day12Utils
    {

        public static int[] ParseInput(string step)
        {
            var splited = step
                .Replace("<", "")
                .Replace("x", "")
                .Replace(" ", "")
                .Replace("=", "")
                .Replace("y", "")
                .Replace("z", "")
                .Replace(">", "")
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            var numbers = splited.Select(int.Parse).ToArray();
            return numbers;
        }

        public static Step ToStep(this List<int[]> status)
        {
            var step = new Step();
            for (int i = 0; i < Step.NumberOfMoons; i++)
            {
                for (int j = 0; j < Step.Dimmensions; j++)
                {
                    step.Status[i, j] = status[i][j];
                }
            }
            return step;
        }
    }
}
