using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventOfCode.IntCode.IO
{
    public class InputOutputLinked : IConsoleOutput, IConsoleInput
    {
        private readonly Queue<int> _queue;

        public InputOutputLinked(params int[] values)
        {
            if (values != null && values.Any())
            {
                _queue = new Queue<int>(values);
            }
            else
            {
                _queue = new Queue<int>();
            }

        }

        public void Write(int output)
        {
            lock (_queue)
            {
                _queue.Enqueue(output);
                Monitor.PulseAll(_queue);
            }

        }

        public int Read()
        {
            var count = 0;
            int result;
            lock (_queue)
            {
                while (count == 0)
                {
                    count = _queue.Count;

                    if (count == 0)
                    {
                        Monitor.Wait(_queue);
                    }
                }

                result = _queue.Dequeue();
            }

            return result;
        }

        public int GetOutput()
        {
            lock (_queue)
            {
                return _queue.Peek();
            }
        }
    }
}