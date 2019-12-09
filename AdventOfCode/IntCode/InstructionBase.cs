namespace AdventOfCode.IntCode
{
    public abstract class InstructionBase
    {
        private readonly IPositionBaseManager _positionBaseManager;

        protected InstructionBase(int instructionCode, IPositionBaseManager positionBaseManager)
        {
            _positionBaseManager = positionBaseManager;
            Modes = InstructionUtils.ParseParameterMode(instructionCode);
        }

        public abstract int Length { get; }
        public abstract OptCode Code { get; }

        protected ParameterMode[] Modes { get; }

        public abstract void ExecuteInstruction(int[] program, ref int pc);

        public void Execute(int[] program, ref int pc)
        {
            int originalPc = pc;

            ExecuteInstruction(program, ref originalPc);
            if (pc == originalPc)
            {
                pc = pc + Length;
            }
            else
            {
                pc = originalPc;
            }
        }

        protected ParameterMode GetModeAt(int i)
        {
            if (i < 0 || i > 2)
            {
                return ParameterMode.PositionMode;
            }

            return Modes[i];
        }

        protected int GetValue(int i, int[] program, int pc)
        {
            var value = program[pc + 1 + i];
            var parameterMode = GetModeAt(i);
            if (parameterMode == ParameterMode.ImmediateMode)
            {
                return value;
            }

            if (parameterMode == ParameterMode.PositionMode)
            {
                return program[value];
            }

            if (parameterMode == ParameterMode.RelativeMode)
            {
                int posBase = _positionBaseManager?.GetPositionBase() ?? 0;
                return posBase + program[value];
            }

            return 0;
        }

        protected void WriteValue(int value, int i, int[] program, int pc)
        {
            if (GetModeAt(i) == ParameterMode.ImmediateMode)
            {
                program[pc + 1 + i] = value;
            }
            else
            {
                var direction = program[pc + 1 + i];
                program[direction] = value;
            }
        }
    }
}