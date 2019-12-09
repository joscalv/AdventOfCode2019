namespace AdventOfCode.IntCode
{
    public class Instruction07 : InstructionBase
    {
        public Instruction07(long instructionCode, IMemoryController memoryController) : base(instructionCode, memoryController)
        {

        }

        public override int Length => 4;

        public override OptCode Code => OptCode.OptCode7;


        public override void ExecuteInstruction(long[] program, ref long pc)
        {
            var value1 = GetValue(Parameter.Parameter1, program, pc);
            var value2 = GetValue(Parameter.Parameter2, program, pc);

            WriteValue(value1 < value2 ? 1 : 0, Parameter.Parameter3, program, pc);

        }

    }
}