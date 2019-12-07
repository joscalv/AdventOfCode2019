namespace AdventOfCode.IntCode
{
    public class Instruction01 : InstructionBase
    {
        public Instruction01(int instructionCode) : base(instructionCode)
        {

        }

        public override int Length => 4;
        public override OptCode Code => OptCode.OptCode1;

        public override void ExecuteInstruction(int[] program, ref int pc)
        {

            var value1 = GetValue(0, program, pc);
            var value2 = GetValue(1, program, pc);
            var result = value1 + value2;
            WriteValue(result, 2, program, pc);
        }

    }
}