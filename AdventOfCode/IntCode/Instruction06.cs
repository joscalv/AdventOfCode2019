namespace AdventOfCode.IntCode
{
    public class Instruction06 : InstructionBase
    {
        public Instruction06(int instructionCode, IPositionBaseManager positionBaseManager) : base(instructionCode, positionBaseManager)
        {

        }

        public override int Length => 3;

        public override OptCode Code => OptCode.OptCode6;


        public override void ExecuteInstruction(int[] program, ref int pc)
        {
            var value = GetValue(0, program, pc);
            if (value == 0)
            {
                pc = GetValue(1, program, pc);
            }
        }

    }
}