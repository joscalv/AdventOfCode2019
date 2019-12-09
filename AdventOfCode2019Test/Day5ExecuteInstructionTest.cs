using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day5ExecuteInstructionTest
    {
        [Fact]
        public void ExecuteInstruction1Test()
        {
            int[] program = new[] { 10001, 1, 1, 1 };
            var pc = 0;
            var instruction01 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), null);
            instruction01?.Execute(program, ref pc);

            Assert.Equal(2, program[3]);
        }

        public void ExecuteInstruction12Test()
        {
            int[] program = new[] { 11101, 1, 1, 2 };
            int[] expected = new[] { 11101, 0, 11104, 2 };
            var pc = 0;
            var instruction01 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), null);
            instruction01?.Execute(program, ref pc);

            Assert.Equal(expected, program);
        }


        [Fact]
        public void ExecuteInstruction2Test()
        {
            int[] program = new[] { 10002, 2, 2, 1 };
            var pc = 0;
            var instruction02 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), null);
            instruction02?.Execute(program, ref pc);

            Assert.Equal(4, program[3]);
        }

    }
}
