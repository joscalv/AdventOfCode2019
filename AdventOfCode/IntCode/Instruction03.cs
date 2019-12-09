using AdventOfCode.IntCode.IO;

namespace AdventOfCode.IntCode
{
    public class Instruction03 : InstructionBase
    {
        private readonly IConsoleInput _input;

        public Instruction03(int instructionCode, IConsoleInput input, IPositionBaseManager positionBaseManager) : base(
            instructionCode, positionBaseManager)
        {
            _input = input;
        }

        public override int Length => 2;
        public override OptCode Code => OptCode.OptCode2;


        public override void ExecuteInstruction(int[] program, ref int pc)
        {
            var input = _input.Read();

            WriteValue(input, 0, program, pc);
        }
    }
}