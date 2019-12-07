using AdventOfCode.IntCode.IO;

namespace AdventOfCode.IntCode
{

    public enum OptCode
    {
        OptCode1 = 1,
        OptCode2 = 2,
        OptCode3 = 3,
        OptCode4 = 4,
        OptCode5 = 5,
        OptCode6 = 6,
        OptCode7 = 7,
        OptCode8 = 8
    }

    public enum ParameterMode
    {
        PositionMode = 0,
        ImmediateMode = 1
    }

    public class IntCodeComputer
    {
        private readonly int[] _program;
        private readonly IConsoleInput _input;
        private readonly IConsoleOutput _output;

        public IntCodeComputer(int[] program, IConsoleInput input = null, IConsoleOutput output = null)
        {
            _program = (int[])program.Clone();
            _input = input ?? new ConsoleInput();
            _output = output ?? new ConsoleOutput();
        }

        public int[] Execute()
        {
            int pc = 0;
            while (pc < _program.Length)
            {
                int instructionCode = _program[pc];
                var instruction = InstructionUtils.GetInstruction(_program, pc, _input, _output);
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
