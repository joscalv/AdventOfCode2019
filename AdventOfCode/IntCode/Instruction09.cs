namespace AdventOfCode.IntCode
{
    public class Instruction09 : InstructionBase
    {
        private readonly IMemoryController _posBaseManager;

        public Instruction09(long instructionCode, IMemoryController memoryController) : base(instructionCode,
            memoryController)
        {
            _posBaseManager = memoryController;
        }

        public override int Length => 2;

        public override OptCode Code => OptCode.OptCode9;


        public override void ExecuteInstruction(long[] program, ref long pc)
        {
            var value = GetValue(0, program, pc);
            _posBaseManager.IncreasePositionBase(value);
        }
    }
}