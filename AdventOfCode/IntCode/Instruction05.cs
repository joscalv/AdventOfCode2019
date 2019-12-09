namespace AdventOfCode.IntCode
{
    public class Instruction05 : InstructionBase
    {
        public Instruction05(long instructionCode, IMemoryController memoryController) : base(instructionCode,
            memoryController)
        {
        }

        public override int Length => 3;

        public override OptCode Code => OptCode.OptCode5;


        public override void ExecuteInstruction(long[] program, ref long pc)
        {
            var value = GetValue(Parameter.Parameter1, program, pc);
            if (value != 0)
            {
                pc = GetValue(Parameter.Parameter2, program, pc);
            }
        }
    }
}