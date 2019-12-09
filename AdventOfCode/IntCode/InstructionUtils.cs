using AdventOfCode.IntCode.IO;

namespace AdventOfCode.IntCode
{
    public static class InstructionUtils
    {
        public static InstructionBase GetInstruction(long[] program, long pc, IConsoleInput input, IConsoleOutput output, IMemoryController memoryController)
        {
            var instructionCode = program[pc];
            InstructionBase instruction = null;
            switch (ParseInstructionCode(instructionCode))
            {
                case OptCode.OptCode1:
                    instruction = new Instruction01(instructionCode, memoryController);
                    break;
                case OptCode.OptCode2:
                    instruction = new Instruction02(instructionCode, memoryController);
                    break;
                case OptCode.OptCode3:
                    instruction = new Instruction03(instructionCode, input, memoryController);
                    break;
                case OptCode.OptCode4:
                    instruction = new Instruction04(instructionCode, output, memoryController);
                    break;
                case OptCode.OptCode5:
                    instruction = new Instruction05(instructionCode, memoryController);
                    break;
                case OptCode.OptCode6:
                    instruction = new Instruction06(instructionCode, memoryController);
                    break;
                case OptCode.OptCode7:
                    instruction = new Instruction07(instructionCode, memoryController);
                    break;
                case OptCode.OptCode8:
                    instruction = new Instruction08(instructionCode, memoryController);
                    break;
                case OptCode.OptCode9:
                    instruction = new Instruction09(instructionCode, memoryController);
                    break;
                default:
                    instruction = null;
                    break;

            }
            return instruction;
        }

        public static OptCode ParseInstructionCode(long instructionCode)
        {
            var code = instructionCode % 100;
            return (OptCode)code;
        }

        public static ParameterMode[] ParseParameterMode(long instructionCode)
        {
            var tmp = (long)instructionCode / 100;
            ParameterMode[] modes = new ParameterMode[3];
            int i = 0;
            while (tmp > 0)
            {
                modes[i] = (ParameterMode)(tmp % 10);
                i = i + 1;
                tmp = tmp / 10;
            }

            return modes;
        }
    }
}