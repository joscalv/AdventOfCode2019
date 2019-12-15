using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;
using AdventOfCode.Model;

namespace AdventOfCode
{
    public class Day13
    {

        private readonly long[] _program = IntCodeUtils.ReadInput(@"Inputs/inputDay13.txt");

        public int Part1()
        {
            var gameGrid = new GameGrid();
            IntCodeComputer computer = new IntCodeComputer(gameGrid, gameGrid);
            computer.Execute(_program);

            return gameGrid.GetNumOfBlocks();
        }

        public int Part2()
        {
            _program[0] = 2;
            var gameGrid = new GameGrid();
            IntCodeComputer computer = new IntCodeComputer(gameGrid, gameGrid);
            computer.Execute(_program);

            return gameGrid.GetNumOfBlocks();
        }
    }

    public enum TileType
    {
        Empty = 0,
        Wall = 1,
        Block = 2,
        HorizontalPaddle = 3,
        Ball = 4,
        Moved = 5,
        Device = 6,
        Oxigen = 7,
    }

    public enum WriteSequence
    {
        X = 0,
        Y,
        TileId
    }

    public class GameGrid : IConsoleInput, IConsoleOutput
    {
        private WriteSequence _currentWrite = WriteSequence.X;
        private long _lastX = 0;
        private long _lastY = 0;
        private TileType _tileType = TileType.Empty;
        private Dictionary<Point, TileType> _grid = new Dictionary<Point, TileType>();

        public long Score { get; private set; }

        public long Read()
        {
            var gridString = Day13Utils.PrintBoard(GetGrid());
            Console.WriteLine($"SCORE: {Score}");
            Console.WriteLine(gridString);

            int value = int.MinValue;
            while (!(value >= -1 && value <= 1))
            {
                var readed = Console.ReadKey();
                value = readed.Key switch
                {
                    ConsoleKey.LeftArrow => -1,
                    ConsoleKey.RightArrow => 1,
                    ConsoleKey.UpArrow => 0,
                    _ => int.MinValue,
                };
            }
            return value;
        }

        public void Write(long output)
        {
            if (_currentWrite == WriteSequence.X)
            {
                _lastX = output;
            }
            else if (_currentWrite == WriteSequence.Y)
            {
                _lastY = output;
            }
            else if (_currentWrite == WriteSequence.TileId)
            {
                _tileType = (TileType)output;
                HandleMovement();
            }
            _currentWrite = (WriteSequence)((int)(_currentWrite + 1) % 3);
        }

        private void HandleMovement()
        {
            var key = Point.Create((int)_lastX, (int)_lastY);
            if (_lastX == -1 && _lastY == 0)
            {
                Score = (long)_tileType;
            }
            else if (_tileType == TileType.Empty)
            {
                HandleEmpty(key);
            }
            else if (_tileType == TileType.Ball)

            {
                HandleBall(key);
            }
            else
            {
                HandleHorizontalPaddle(key, _tileType);
            }
        }

        private void HandleHorizontalPaddle(Point point, TileType type)
        {
            if (_grid.TryGetValue(point, out var value))
            {
                if (value != TileType.Empty)
                {
                    _grid[point] = type;
                }
            }
            else
            {
                _grid.Add(point, type);
            }
        }

        private void HandleBall(Point point)
        {
            if (_grid.TryGetValue(point, out var existingTile))
            {
                if (existingTile == TileType.Block)
                {
                    _grid[point] = TileType.Ball;
                }
            }
            else
            {
                _grid.Add(point, TileType.Ball);
            }
        }

        private void HandleEmpty(Point point)
        {
            if (_grid.ContainsKey(point))
            {
                _grid.Remove(point);
            }
        }

        public int GetNumOfBlocks()
        {
            return _grid.Values.Count(v => v == TileType.Block);
        }

        public int GetNumOfTiles()
        {
            return _grid.Values.Count(v => v != TileType.Empty);
        }

        public (Point point, int value)[] GetGrid() => _grid.Select(kvp => (kvp.Key, (int)kvp.Value)).ToArray();

        public long GetScore() => Score;
    }

    public class Day13Utils
    {

        private static char GetCharacter(int value) => value switch
        {
            0 => ' ',
            1 => '#',
            2 => '@',
            3 => '-',
            4 => 'O',
            5 => '.',
            6 => 'D',
            7 => '2',
            _ => '>',
        };

        public static string PrintBoard((Point point, int value)[] grid)
        {
            var allX = grid.Select(panel => panel.point.X).ToList();
            var allY = grid.Select(panel => panel.point.Y).ToList();
            var minX = allX.Any() ? allX.Min() : 0;
            var maxX = allX.Any() ? allX.Max():0;
            var width = (maxX - minX) + 1;
            var minY = allY.Any() ? allY.Min():0;
            var maxY = allY.Any() ? allY.Max():0;
            var height = (maxY - minY) + 1;
            var result = (new string(' ', width * height)).ToCharArray();
            var result2 = new char[width, height];

            foreach ((Point point, int value) paintedPanel in grid)
            {

                int index = (paintedPanel.point.X + (-1 * minX)) + ((paintedPanel.point.Y + (-1 * minY)) * width);
                result[index] = GetCharacter((int)paintedPanel.value);
            }

            foreach ((Point point, int value) paintedPanel in grid)
            {
                int index = (paintedPanel.point.X + (-1 * minX)) * (paintedPanel.point.Y + (-1 * minY));
                int x = paintedPanel.point.X + (-1 * minX);
                int y = paintedPanel.point.Y + (-1 * minY);
                result2[x, y] = GetCharacter((int)paintedPanel.value);
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
                    builder2.Append(result2[x, y]);
                }

                builder2.Append(Environment.NewLine);
            }

            return builder2.ToString();
        }
    }
}
