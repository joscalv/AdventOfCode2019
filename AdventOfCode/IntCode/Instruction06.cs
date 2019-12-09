namespace AdventOfCode.IntCode
{
    public class Instruction06 : InstructionBase
    {
        public Instruction06(long instructionCode, IMemoryController memoryController) : base(instructionCode, memoryController)
        {

        }

        public override int Length => 3;

        public override OptCode Code => OptCode.OptCode6;


        public override void ExecuteInstruction(long[] program, ref long pc)
        {
            var value = GetValue(Parameter.Parameter1, program, pc);
            if (value == 0)
            {
                pc = GetValue(Parameter.Parameter2, program, pc);
            }
        }

    }
}