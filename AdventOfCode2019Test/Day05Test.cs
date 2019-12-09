using AdventOfCode;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day05Test
    {
        private readonly Day05 _day5 = new Day05();

        [Fact]
        public void Part1Test()
        {
            var expected = 15508323;
            var result = _day5.Part1();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2Test()
        {
            var expected = 9006327;
            var result = _day5.Part2();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ExecuteInstruction1Test()
        {
            long[] program = new long[] { 10001, 1, 1, 1 };
            long pc = 0;

            MemoryController memoryController = new MemoryController(program);
            var instruction01 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), memoryController);
            instruction01?.Execute(program, ref pc);

            Assert.Equal(2, program[3]);
        }

        [Fact]
        public void ExecuteInstruction2Test()
        {
            long[] program = { 1002, 4, 3, 4, 33 };
            long[] expected = { 1002, 4, 3, 4, 99 };
            MemoryController memoryController = new MemoryController(program);
            long pc = 0;
            var instruction01 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), memoryController);
            instruction01?.Execute(program, ref pc);

            Assert.Equal(expected, program);
        }


        [Fact]
        public void ExecuteInstruction3Test()
        {
            long[] program = { 10002, 2, 2, 1 };
            MemoryController memoryController = new MemoryController(program);
            long pc = 0;
            var instruction02 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), memoryController);
            instruction02?.Execute(program, ref pc);

            Assert.Equal(4, program[3]);
        }

        [Fact]
        public void GetInstruction1Test()
        {
            long[] program = { 00001, 1, 1, 1 };
            var instruction01 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), null) as Instruction01;
            Assert.NotNull(instruction01);
        }

        [Fact]
        public void GetInstruction2Test()
        {
            long[] program = { 00002, 1, 1, 1 };
            var instruction02 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), null) as Instruction02;
            Assert.NotNull(instruction02);

        }

        [Fact]
        public void GetInstruction3Test()
        {
            long[] program = { 00003, 50, 0 };
            var instruction03 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), null) as Instruction03;
            Assert.NotNull(instruction03);

        }

        [Fact]
        public void GetInstruction4Test()
        {
            long[] program = { 00004, 50, 0 };
            var instruction03 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), null) as Instruction04;
            Assert.NotNull(instruction03);

        }
    }
}