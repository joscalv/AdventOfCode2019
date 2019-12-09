namespace AdventOfCode.IntCode
{
    public abstract class InstructionBase
    {
        private readonly IMemoryController _memoryController;

        protected InstructionBase(long instructionCode, IMemoryController memoryController)
        {
            _memoryController = memoryController;
            Modes = InstructionUtils.ParseParameterMode(instructionCode);
        }

        public abstract int Length { get; }
        
        public abstract OptCode Code { get; }

        protected ParameterMode[] Modes { get; }

        public void Execute(long[] program, ref long pc)
        {
            long originalPc = pc;

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

        public abstract void ExecuteInstruction(long[] program, ref long pc);

        protected ParameterMode GetModeAt(Parameter parameter)
        {
            return Modes[(int)parameter];
        }

        protected long GetValue(Parameter parameter, long[] program, long pc)
        {
            var value = program[pc + 1 + (int)parameter];
            var positionMode = GetModeAt(parameter);
            if (positionMode == ParameterMode.ImmediateMode)
            {
                return value;
            }

            return _memoryController.GetValue(positionMode, value);
        }

        protected void WriteValue(long value, Parameter parameter, long[] program, long pc)
        {
            int parameterOffset = (int) parameter;
            var positionMode = GetModeAt(parameter);

            if (positionMode == ParameterMode.ImmediateMode)
            {
                program[pc + 1 + parameterOffset] = value;
            }
            else
            {
                var direction = program[pc + 1 + parameterOffset];
                _memoryController.WriteValue(positionMode, direction, value);
            }
        }
    }
}