namespace AdventOfCode.IntCode.IO
{
    public class OutputFixed : IConsoleOutput
    {
        private int _output;

        public void Write(int output)
        {
            _output = output;
        }

        public int GetOutPut() => _output;
    }
}