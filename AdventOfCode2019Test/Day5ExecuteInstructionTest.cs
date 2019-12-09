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
            long[] program = new long[] { 10001, 1, 1, 1 };
            long pc = 0;

            MemoryController memoryController = new MemoryController(program);
            var instruction01 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), memoryController);
            instruction01?.Execute(program, ref pc);

            Assert.Equal(2, program[3]);
        }

        public void ExecuteInstruction12Test()
        {
            long[] program = { 11101, 1, 1, 2 };
            long[] expected = { 11101, 0, 11104, 2 };
            MemoryController memoryController = new MemoryController(program);
            long pc = 0;
            var instruction01 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), memoryController);
            instruction01?.Execute(program, ref pc);

            Assert.Equal(expected, program);
        }


        [Fact]
        public void ExecuteInstruction2Test()
        {
            long[] program = { 10002, 2, 2, 1 };
            MemoryController memoryController = new MemoryController(program);
            long pc = 0;
            var instruction02 = InstructionUtils.GetInstruction(program, 0, new ConsoleInput(), new ConsoleOutput(), memoryController);
            instruction02?.Execute(program, ref pc);

            Assert.Equal(4, program[3]);
        }

    }
}
