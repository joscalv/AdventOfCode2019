namespace AdventOfCode.IntCode
{
    public class Instruction01 : InstructionBase
    {
        public Instruction01(long instructionCode, IMemoryController memoryController) : base(instructionCode, memoryController)
        {
        }

        public override int Length => 4;
        public override OptCode Code => OptCode.OptCode1;


        public override void ExecuteInstruction(long[] program, ref long pc)
        {
            var value1 = GetValue(Parameter.Parameter1, program, pc);
            var value2 = GetValue(Parameter.Parameter2, program, pc);
            var result = value1 + value2;
            WriteValue(result, Parameter.Parameter3, program, pc);
        }
    }
}