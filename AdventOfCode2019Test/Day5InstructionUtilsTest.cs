using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day5InstructionUtilsTest
    {
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
