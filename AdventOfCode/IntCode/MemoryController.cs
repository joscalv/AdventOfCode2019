using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.IntCode
{
    public class MemoryController : IMemoryController
    {
        private long _positionBase;
        private readonly Dictionary<long, long> _virtualMemory = new Dictionary<long, long>();
        private readonly long[] _memory;

        public MemoryController(long[] memory)
        {
            _memory = memory;
        }

        public void IncreasePositionBase(long value)
        {
            _positionBase = _positionBase + value;
        }

        public long GetValue(ParameterMode directionMode, long direction)
        {
            var memoryDirection = CalcMemoryDirection(directionMode, direction);
            if (memoryDirection < _memory.Length)
            {
                return _memory[memoryDirection];
            }

            if (!_virtualMemory.TryGetValue(memoryDirection, out var value))
            {
                value = 0;
            }

            return value;
        }

        public void WriteValue(ParameterMode directionMode, long direction, long value)
        {
            var memoryDirection = CalcMemoryDirection(directionMode, direction);
            if (memoryDirection < _memory.Length)
            {
                _memory[memoryDirection] = value;
            }
            else if (_virtualMemory.ContainsKey(memoryDirection))
            {
                _virtualMemory[memoryDirection] = value;
            }
            else
            {
                _virtualMemory.Add(memoryDirection, value);
            }
        }

        private long CalcMemoryDirection(ParameterMode mode, long direction)
        {
            if (mode == ParameterMode.PositionMode)
            {
                return direction;
            }
            else if (mode == ParameterMode.RelativeMode)
            {
                return _positionBase + direction;
            }
            else
            {
                throw new NotSupportedException($"Memory mode not supported {mode.ToString()}({(int)mode})");
            }


        }
    }
}
