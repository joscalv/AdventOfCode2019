using AdventOfCode;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;

using Xunit;

namespace AdventOfCode2019Test
{
    public class Day09Test
    {
        private readonly Day09 _day9 = new Day09();
        [Fact]
        public void TestResultPart1()
        {
            long day9Part1Solution = 3989758265;
            Assert.Equal(day9Part1Solution, _day9.Part1());
        }

        [Fact]
        public void TestResultPart2()
        {
            long day9Part2Solution = 76791;
            Assert.Equal(day9Part2Solution, _day9.Part2());
        }

        [Fact]
        public void TestInput1Part1_OutputMustBeACopyOfProgram()
        {
            long[] input = { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };

            var computer = new IntCodeComputer(new InputFixedValue(0), new ConsoleOutput());
            var outPut = computer.Execute(input);

            Assert.Equal(input, outPut);

        }

        [Fact]
        public void TestInput1Part2_Output16DigitNumber()
        {
            long[] input = { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            var outputConsole = new OutputFixed();
            var computer = new IntCodeComputer(new InputFixedValue(0), outputConsole);
            var result = computer.Execute(input);

            var outputValue = outputConsole.GetOutPut();
            Assert.Equal(16, outputValue.ToString().Length);

        }

        [Fact]
        public void TestInput1Part3_OutputMiddleLargeNumber()
        {
            long[] input = { 104, 1125899906842624, 99 };
            var outputConsole = new OutputFixed();
            var computer = new IntCodeComputer(new InputFixedValue(0), outputConsole);
            var result = computer.Execute(input);

            var outputValue = outputConsole.GetOutPut();
            Assert.Equal(1125899906842624, outputValue);

        }

    }
}
