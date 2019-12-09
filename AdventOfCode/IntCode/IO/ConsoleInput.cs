using System;

namespace AdventOfCode.IntCode.IO
{
    public class ConsoleInput : IConsoleInput
    {
        public long Read()
        {
            Console.Write("Insert value: ");
            var value = Console.ReadLine();

            if (long.TryParse(value, out var result))
            {
                return result;
            }

            return 0;

        }
    }

    public class ConsoleOutput : IConsoleOutput
    {
        public void Write(long output)
        {
            Console.WriteLine(output);
        }
    }

    public class InputFixedValue : IConsoleInput
    {
        private readonly long _value;

        public InputFixedValue(long value)
        {
            _value = value;
        }
        public long Read()
        {
            return _value;

        }
    }
}
