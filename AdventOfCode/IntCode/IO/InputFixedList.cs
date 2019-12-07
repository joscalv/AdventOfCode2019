namespace AdventOfCode.IntCode.IO
{
    public class InputFixedList : IConsoleInput
    {
        private readonly int[] _values;
        private int _readIndex = 0;

        public InputFixedList(int cfg, int previousInput)
        {
            _values = new[] { cfg, previousInput };
        }
        public InputFixedList(int[] values)
        {
            _values = values;
        }

        public int Read()
        {
            return _values[(_readIndex++) % _values.Length];
        }
    }
}