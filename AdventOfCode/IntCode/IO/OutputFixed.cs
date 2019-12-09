namespace AdventOfCode.IntCode.IO
{
    public class OutputFixed : IConsoleOutput
    {
        private long _output;

        public void Write(long output)
        {
            _output = output;
        }

        public long GetOutPut() => _output;
    }
}