namespace AdventOfCode.IntCode
{
    public interface IMemoryController
    {
        void IncreasePositionBase(long value);

        long GetValue(ParameterMode directionMode, long direction);

        void WriteValue(ParameterMode directionMode, long direction, long value);
    }
}