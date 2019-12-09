using AdventOfCode.IntCode.IO;

namespace AdventOfCode.IntCode
{
    public class Instruction04 : InstructionBase
    {
        private readonly IConsoleOutput _output;

        public Instruction04(int instructionCode, IConsoleOutput output, IPositionBaseManager positionBaseManager) :
            base(instructionCode, positionBaseManager)
        {
            _output = output;
        }

        public override int Length => 2;
        public override OptCode Code => OptCode.OptCode2;


        public override void ExecuteInstruction(int[] program, ref int pc)
        {
            var value = GetValue(0, program, pc);

            _output.Write(value);
        }
    }
}