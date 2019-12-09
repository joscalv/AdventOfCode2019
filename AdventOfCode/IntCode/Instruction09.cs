namespace AdventOfCode.IntCode
{
    public class Instruction09 : InstructionBase
    {
        private readonly IPositionBaseManager _posBaseManager;

        public Instruction09(int instructionCode, IPositionBaseManager positionBaseManager) : base(instructionCode,
            positionBaseManager)
        {
            _posBaseManager = positionBaseManager;
        }

        public override int Length => 2;

        public override OptCode Code => OptCode.OptCode9;


        public override void ExecuteInstruction(int[] program, ref int pc)
        {
            var value = GetValue(0, program, pc);
            _posBaseManager.IncreatePositionBase(value);
        }
    }
}