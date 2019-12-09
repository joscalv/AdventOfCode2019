using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventOfCode.IntCode.IO
{
    public class InputOutputLinked : IConsoleOutput, IConsoleInput
    {
        private readonly Queue<long> _queue;

        public InputOutputLinked(params long[] values)
        {
            if (values != null && values.Any())
            {
                _queue = new Queue<long>(values);
            }
            else
            {
                _queue = new Queue<long>();
            }
        }

        public void Write(long output)
        {
            lock (_queue)
            {
                _queue.Enqueue(output);
                Monitor.PulseAll(_queue);
            }
        }

        public long Read()
        {
            var count = 0;
            long result;
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

        public long GetOutput()
        {
            lock (_queue)
            {
                return _queue.Peek();
            }
        }
    }
}