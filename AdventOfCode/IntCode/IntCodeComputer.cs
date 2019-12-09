using AdventOfCode.IntCode.IO;

namespace AdventOfCode.IntCode
{
    public enum OptCode
    {
        OptCode1 = 1,
        OptCode2 = 2,
        OptCode3 = 3,
        OptCode4 = 4, //ConsoleOutput
        OptCode5 = 5,
        OptCode6 = 6,
        OptCode7 = 7,
        OptCode8 = 8,
        OptCode9 = 9 // Adjust relative base position
    }

    public enum ParameterMode
    {
        PositionMode = 0,
        ImmediateMode = 1,
        RelativeMode = 2
    }

    public enum Parameter
    {
        Parameter1 = 0,
        Parameter2 = 1,
        Parameter3=2
    }

    public class IntCodeComputer
    {
        private readonly IConsoleInput _input;
        private readonly IConsoleOutput _output;

        public IntCodeComputer(IConsoleInput input = null, IConsoleOutput output = null)
        {
            _input = input ?? new ConsoleInput();
            _output = output ?? new ConsoleOutput();

        }

        public long[] Execute(long[] input)
        {
            var program= (long[])input.Clone();
            var memoryController = new MemoryController(program);
            long pc = 0;
            while (pc < program.Length)
            {
                long instructionCode = program[pc];
                var instruction = InstructionUtils.GetInstruction(program, pc, _input, _output, memoryController);
                if (instruction == null)
                {
                    return program;
                }
                instruction.Execute(program, ref pc);
            }
            return program;
        }


    }
}
