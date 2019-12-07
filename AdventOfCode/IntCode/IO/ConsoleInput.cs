using System;

namespace AdventOfCode.IntCode.IO
{
    public class ConsoleInput : IConsoleInput
    {
        public int Read()
        {
            Console.Write("Insert value: ");
            var value = Console.ReadLine();

            if (int.TryParse(value, out var result))
            {
                return result;
            }

            return 0;

        }
    }

    public class ConsoleOutput : IConsoleOutput
    {
        public void Write(int output)
        {
            Console.WriteLine(output);
        }
    }

    public class InputFixedValue : IConsoleInput
    {
        private readonly int _value;

        public InputFixedValue(int value)
        {
            _value = value;
        }
        public int Read()
        {
            return _value;

        }
    }
}
