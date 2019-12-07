namespace AdventOfCode.IntCode
{
    public abstract class InstructionBase
    {
        public abstract int Length { get; }
        public abstract OptCode Code { get; }

        public abstract void ExecuteInstruction(int[] program, ref int pc);

        public void Execute(int[] program, ref int pc)
        {
            int originalPC = pc;

            ExecuteInstruction(program, ref originalPC);
            if (pc == originalPC)
            {
                pc = pc + Length;
            }
            else
            {
                pc = originalPC;
            }
        }

        protected ParameterMode[] Modes { get; }

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
            if (GetModeAt(i) == ParameterMode.ImmediateMode)
            {
                return value;
            }
            else
            {
                return program[value];
            }
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

        protected InstructionBase(int instructionCode)
        {
            Modes = InstructionUtils.ParseParameterMode(instructionCode);
        }

    }
}