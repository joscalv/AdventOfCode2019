using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;
using AdventOfCode.Model;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Day11
    {
        private readonly long[] _program = IntCodeUtils.ReadInput(@"Inputs/inputDay11.txt");

        public long Part1()
        {
            return 0;
        }

        public int Part2()
        {
            return 0;
        }
    }

    public class PaintingController : IConsoleInput, IConsoleOutput
    {
        private readonly Dictionary<Point, Color> _paintedPositions = new Dictionary<Point, Color>();
        private Point _currentPosition = default(Point);
        private Direction _direction = Direction.Up;
        private OutputType _curreOutputType = OutputType.ColorPainted;

        public long Read()
        {
            Color result = Color.Black;
            if (_paintedPositions.TryGetValue(_currentPosition, out var color))
            {
                result = color;
            }

            return (long)result;
        }

        public void Write(long output)
        {
            if (_curreOutputType == OutputType.ColorPainted)
            {
                HandlePaintPosition((Color)output);
            }
            else
            {
                HandleTurn((Turn)output);
                Move();
            }

            _curreOutputType = (OutputType)(((int)_curreOutputType + 1) % Enum.GetValues(typeof(OutputType)).Length);
        }

        private void Move()
        {
            int x = _currentPosition.X;
            int y = _currentPosition.Y;
            switch (_direction)
            {
                case Direction.Up:
                    _currentPosition = Point.Create(x, y + 1);
                    break;
                case Direction.Down:
                    _currentPosition = Point.Create(x, y - 1);
                    break;
                case Direction.Right:
                    _currentPosition = Point.Create(x + 1, y);
                    break;
                case Direction.Left:
                    _currentPosition = Point.Create(x - 1, y);
                    break;
            }
        }

        private void HandlePaintPosition(Color color)
        {
            if (_paintedPositions.ContainsKey(_currentPosition))
            {
                _paintedPositions[_currentPosition] = color;
            }
            else
            {
                _paintedPositions.Add(_currentPosition, color);
            }
        }

        private void HandleTurn(Turn turn)
        {
            var increase = turn == Turn.TurnRight ? 1 : -1;
            _direction = (Direction)(((int)_direction + increase) % Enum.GetValues(typeof(Direction)).Length);
        }
    }

    public enum OutputType
    {
        ColorPainted = 0,
        Turn = 1
    }
    internal enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    internal enum Turn
    {
        TurnLeft = 0,
        TurnRight = 1
    }

    public enum Color
    {
        Black = 0,
        White = 1
    }

    public static class Day11Utils
    {
        //public static Direction Turn()
    }
}