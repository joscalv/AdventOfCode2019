namespace AdventOfCode.IntCode
{
    public class Instruction05 : InstructionBase
    {
        public Instruction05(int instructionCode, IPositionBaseManager positionBaseManager) : base(instructionCode,
            positionBaseManager)
        {
        }

        public override int Length => 3;

        public override OptCode Code => OptCode.OptCode5;


        public override void ExecuteInstruction(int[] program, ref int pc)
        {
            var value = GetValue(0, program, pc);
            if (value != 0)
            {
                pc = GetValue(1, program, pc);
            }
        }
    }
}