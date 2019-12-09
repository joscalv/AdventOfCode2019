namespace AdventOfCode.IntCode.IO
{
    public class InputFixedList : IConsoleInput
    {
        private readonly long[] _values;
        private int _readIndex = 0;

        public InputFixedList(long cfg, long previousInput)
        {
            _values = new[] { cfg, previousInput };
        }
        public InputFixedList(long[] values)
        {
            _values = values;
        }

        public long Read()
        {
            return _values[(_readIndex++) % _values.Length];
        }
    }
}