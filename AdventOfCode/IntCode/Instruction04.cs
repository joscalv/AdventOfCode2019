using AdventOfCode.IntCode.IO;

namespace AdventOfCode.IntCode
{
    public class Instruction04 : InstructionBase
    {
        private readonly IConsoleOutput _output;

        public Instruction04(long instructionCode, IConsoleOutput output, IMemoryController memoryController) :
            base(instructionCode, memoryController)
        {
            _output = output;
        }

        public override int Length => 2;
        public override OptCode Code => OptCode.OptCode2;


        public override void ExecuteInstruction(long[] program, ref long pc)
        {
            var value = GetValue(0, program, pc);

            _output.Write(value);
        }
    }
}