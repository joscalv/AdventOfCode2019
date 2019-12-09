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
        private readonly long[] _program;
        private readonly IConsoleInput _input;
        private readonly IConsoleOutput _output;
        private readonly IMemoryController _memoryController;

        public IntCodeComputer(long[] program, IConsoleInput input = null, IConsoleOutput output = null)
        {
            _program = (long[])program.Clone();
            _input = input ?? new ConsoleInput();
            _output = output ?? new ConsoleOutput();
            _memoryController = new MemoryController(_program);
        }

        public long[] Execute()
        {
            long pc = 0;
            while (pc < _program.Length)
            {
                long instructionCode = _program[pc];
                var instruction = InstructionUtils.GetInstruction(_program, pc, _input, _output, _memoryController);
                if (instruction == null)
                {
                    return _program;
                }
                instruction.Execute(_program, ref pc);
            }
            return _program;
        }


    }
}
