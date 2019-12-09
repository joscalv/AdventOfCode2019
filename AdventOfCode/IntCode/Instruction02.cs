namespace AdventOfCode.IntCode
{
    public class Instruction02 : InstructionBase
    {
        public Instruction02(long instructionCode, IMemoryController memoryController) : base(instructionCode, memoryController)
        {
        }

        public override int Length => 4;
        public override OptCode Code => OptCode.OptCode2;


        public override void ExecuteInstruction(long[] program, ref long pc)
        {
            var value1 = GetValue(Parameter.Parameter1, program, pc);
            var value2 = GetValue(Parameter.Parameter2, program, pc);
            var result = value1 * value2;
            WriteValue(result, Parameter.Parameter3, program, pc);
        }
    }
}