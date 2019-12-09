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
        OptCode9 = 9 // Adjust relative base
    }

    public enum ParameterMode
    {
        PositionMode = 0,
        ImmediateMode = 1,
        RelativeMode = 2
    }

    public class IntCodeComputer : IPositionBaseManager
    {
        private readonly int[] _program;
        private readonly IConsoleInput _input;
        private readonly IConsoleOutput _output;
        private int _positionBase;

        public IntCodeComputer(int[] program, IConsoleInput input = null, IConsoleOutput output = null)
        {
            _program = (int[])program.Clone();
            _input = input ?? new ConsoleInput();
            _output = output ?? new ConsoleOutput();
            _positionBase = 0;
        }

        public int[] Execute()
        {
            int pc = 0;
            while (pc < _program.Length)
            {
                int instructionCode = _program[pc];
                var instruction = InstructionUtils.GetInstruction(_program, pc, _input, _output, this);
                if (instruction == null)
                {
                    return _program;
                }
                instruction.Execute(_program, ref pc);
            }
            return _program;
        }


        public void IncreatePositionBase(int value)
        {
            _positionBase = _positionBase + value;
        }

        public int GetPositionBase()
        {
            return _positionBase;
        }
    }

    public interface IPositionBaseManager
    {
        void IncreatePositionBase(int value);

        int GetPositionBase();
    }
}
