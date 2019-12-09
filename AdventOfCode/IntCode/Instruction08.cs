namespace AdventOfCode.IntCode
{
    public class Instruction08 : InstructionBase
    {
        public Instruction08(int instructionCode, IPositionBaseManager positionBaseManager) : base(instructionCode, positionBaseManager)
        {

        }

        public override int Length => 4;

        public override OptCode Code => OptCode.OptCode8;


        public override void ExecuteInstruction(int[] program, ref int pc)
        {
            var value1 = GetValue(0, program, pc);
            var value2 = GetValue(1, program, pc);
            WriteValue(value1 == value2 ? 1 : 0, 2, program, pc);

        }

    }
}