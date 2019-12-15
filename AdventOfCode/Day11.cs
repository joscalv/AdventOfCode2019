using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;
using AdventOfCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace AdventOfCode
{
    public class Day11
    {
        private readonly long[] _program = IntCodeUtils.ReadInput(@"Inputs/inputDay11.txt");

        public long Part1()
        {
            PaintingController paintingController = new PaintingController();
            IntCodeComputer computer = new IntCodeComputer(paintingController, paintingController);
            computer.Execute(_program);
            return paintingController.GetPaintedPanels().Count;
        }

        public string Part2()
        {
            PaintingController paintingController = new PaintingController(Color.White);
            IntCodeComputer computer = new IntCodeComputer(paintingController, paintingController);
            computer.Execute(_program);
            var paintedPanels = paintingController.GetPaintedPanels();
            var allX = paintedPanels.Select(panel => panel.point.X).ToList();
            var allY = paintedPanels.Select(panel => panel.point.Y).ToList();
            var minX = allX.Min();
            var maxX = allX.Max();
            var width = (maxX - minX) + 1;
            var minY = allY.Min();
            var maxY = allY.Max();
            var height = (maxY - minY) + 1;
            var result = (new string(' ', width * height)).ToCharArray();
            var result2 = new char[width, height];

            foreach ((Point point, Color color) paintedPanel in paintedPanels)
            {
                if (paintedPanel.color == Color.White)
                {
                    int index = (paintedPanel.point.X + (-1 * minX)) + ((paintedPanel.point.Y + (-1 * minY)) * width);
                    result[index] = '#';
                }
            }

            foreach ((Point point, Color color) paintedPanel in paintedPanels)
            {
                if (paintedPanel.color == Color.White)
                {
                    int index = (paintedPanel.point.X + (-1 * minX)) * (paintedPanel.point.Y + (-1 * minY));
                    int x = paintedPanel.point.X + (-1 * minX);
                    int y = paintedPanel.point.Y + (-1 * minY);
                    result2[x, y] = '#';
                }
            }


            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                builder.Append(result[i]);
                if (i % width == 0)
                {
                    builder.Append(Environment.NewLine);
                }
            }

            StringBuilder builder2 = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    builder2.Append(result2[x, y] == '#' ? '#' : ' ');
                }

                builder2.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }

    public class PaintingController : IConsoleInput, IConsoleOutput
    {
        private readonly Color _firstPanelColor;
        private readonly Dictionary<Point, Color> _paintedPositions = new Dictionary<Point, Color>();
        private Point _currentPosition = default(Point);
        private Direction _direction = Direction.Up;
        private OutputType _currentOutputType = OutputType.ColorPainted;

        public PaintingController(Color firstPanelColor = Color.Black)
        {
            _firstPanelColor = firstPanelColor;
        }

        public long Read()
        {
            Color result = Color.Black;

            if (_paintedPositions.TryGetValue(_currentPosition, out var color))
            {
                result = color;
            }
            else if (_currentPosition == Point.Create(0, 0))
            {
                result = _firstPanelColor;
            }

            return (long)result;
        }

        public void Write(long output)
        {
            if (_currentOutputType == OutputType.ColorPainted)
            {
                HandlePaintPosition((Color)output);
            }
            else
            {
                HandleTurn((Turn)output);
                Move();
            }

            _currentOutputType = (OutputType)(((int)_currentOutputType + 1) % Enum.GetValues(typeof(OutputType)).Length);
        }

        public List<(Point point, Color color)> GetPaintedPanels() => _paintedPositions.Select(kvp => (kvp.Key, kvp.Value)).ToList();

        private void Move()
        {
            int x = _currentPosition.X;
            int y = _currentPosition.Y;
            switch (_direction)
            {
                case Direction.Up:
                    _currentPosition = Point.Create(x, y - 1);
                    break;
                case Direction.Down:
                    _currentPosition = Point.Create(x, y + 1);
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
            _direction = (Direction)(((int)_direction + increase + Enum.GetValues(typeof(Direction)).Length) % Enum.GetValues(typeof(Direction)).Length);
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
}