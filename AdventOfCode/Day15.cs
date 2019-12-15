using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using AdventOfCode.IntCode;
using AdventOfCode.IntCode.IO;
using AdventOfCode.Model;

namespace AdventOfCode
{
    public class Day15
    {

        private readonly long[] _program = IntCodeUtils.ReadInput(@"Inputs/inputDay15.txt");
        private readonly (Point point, int value)[] _grid = ReadGrid(@"Inputs/inputDay15.Grid.txt");

        public int Part1()
        {
            var oxigenGrid = new OxigenGrid();
            while (OxigenGrid.IsPosiblePaths())
            {
                try
                {
                    oxigenGrid = new OxigenGrid();
                    IntCodeComputer computer = new IntCodeComputer(oxigenGrid, oxigenGrid);
                    computer.Execute(_program);
                    Console.WriteLine("SOLUTION " + OxigenGrid.MovementsToOrigin.Count);
                    Console.Clear();
                    Console.WriteLine(Day13Utils.PrintBoard(oxigenGrid.GetGrid()));
                    Console.WriteLine("----------------------------------");
                }
                catch (Exception e)
                {
                    //Console.WriteLine("End of simulation");

                }
            }

            StringBuilder builder = new StringBuilder();

            foreach (var value in oxigenGrid.GetGrid())
            {
                builder.AppendLine($"{value.point.X},{value.point.Y},{value.value}");
            }
            File.WriteAllText("grid.txt", builder.ToString());
            Console.WriteLine("SOLUTION " + OxigenGrid.MovementsToOrigin.Count);
            Console.Clear();
            Console.WriteLine(Day13Utils.PrintBoard(oxigenGrid.GetGrid()));
            Console.WriteLine("----------------------------------");
            return 0;
        }

        public int Part2()
        {
            OxigenGrid.SetGrid(_grid);
            Dictionary<Point, TileType> values = OxigenGrid.GetDictionaryGrid();
            var oxigenPoints = _grid.Where(v => v.value== (int)TileType.Oxigen).Select(v=> v.point).ToList();

            int minute = 0;
            while (oxigenPoints.Any())
            {
                var convertedPoints = new HashSet<Point>();
                
                foreach (var oxigenPoint in oxigenPoints)
                {
                    var posibleMovements = OxigenGrid.GetPosibleMovements(oxigenPoint);
                    foreach (Point posibleMovement in posibleMovements)
                    {
                        convertedPoints.Add(posibleMovement);
                    }
                }

                oxigenPoints = convertedPoints.ToList();
                minute++;

                Console.WriteLine(Day13Utils.PrintBoard(OxigenGrid.GetGrid2()));
                Console.WriteLine("---------------------------");
                Console.ReadKey();



            }

            //_program[0] = 2;
            //var gameGrid = new GameGrid();
            //IntCodeComputer computer = new IntCodeComputer(gameGrid, gameGrid);
            //computer.Execute(_program);

            //return gameGrid.GetNumOfBlocks();

            Console.WriteLine("SOLUCION "+minute);
            Console.ReadKey();
            return 0;
        }

        public static (Point point, int value)[] ReadGrid(string path)
        {
            return File
                .ReadAllText(path)
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseLine)
                .ToArray();
        }

        public static (Point point, int value) ParseLine(string line)
        {
            int[] values = line.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return (Point.Create(values[0], values[1]), values[2]);
        }
    }

    public enum RobotResponse
    {
        Wall = 0,
        Moved = 1,
        OxigenSystem = 2,
    }

    public enum RobotCommands
    {
        North = 1,
        South = 2,
        West = 3,
        East = 4
    }

    public class OxigenGrid : IConsoleInput, IConsoleOutput
    {
        private int _lastX = 0;
        private int _lastY = 0;
        private RobotCommands _lastRobotCommand = RobotCommands.North;


        private static Dictionary<Point, TileType> _grid = new Dictionary<Point, TileType>() { };
        private static HashSet<Point> _gridAdded = new HashSet<Point>();


        private static readonly Queue<List<RobotCommands>> PosiblePaths = new Queue<List<RobotCommands>>();
        private readonly List<RobotCommands> _currentMovements;
        private int index = 0;

        public static bool IsPosiblePaths() => PosiblePaths.Any();

        public OxigenGrid()
        {
            _currentMovements = PosiblePaths.Dequeue();
            AddPoint(Point.Create(0, 0), TileType.Device);
        }

        static OxigenGrid()
        {
            var currentPoint = Point.Create(0, 0);
            AddPosibleMovements(currentPoint, new List<RobotCommands>());
        }

        private static void AddPosibleMovements(Point currentPoint, List<RobotCommands> currentList)
        {
            if (!_gridAdded.Contains(currentPoint))
            {
                AddMovementIfPosible(currentList, currentPoint, RobotCommands.East);
                AddMovementIfPosible(currentList, currentPoint, RobotCommands.West);
                AddMovementIfPosible(currentList, currentPoint, RobotCommands.North);
                AddMovementIfPosible(currentList, currentPoint, RobotCommands.South);
                _gridAdded.Add(currentPoint);
            }
        }

        private static void AddMovementIfPosible(List<RobotCommands> currentList, Point currentPosition, RobotCommands command)
        {
            var nextPoint = Move(currentPosition.X, currentPosition.Y, command);
            if (!_grid.ContainsKey(nextPoint)
                || (_grid[nextPoint] != TileType.Wall && _grid[nextPoint] != TileType.Moved && _grid[nextPoint] != TileType.Ball))
            {
                PosiblePaths.Enqueue(currentList.Select(x => x).Append(command).ToList());
            }
        }

        public long Read()
        {
            if (index >= _currentMovements.Count)
            {

                AddPoint(Point.Create(_lastX, _lastY), TileType.Moved);
                //if (index % 10 == 0)
                //{
                //    Console.Clear();
                //    Console.WriteLine(Day13Utils.PrintBoard(GetGrid()));
                //    Console.WriteLine("----------------------------------");
                //}

                //throw new Exception("End");
            }
            _lastRobotCommand = _currentMovements[index];
            index = index + 1;
            return (long)_lastRobotCommand;

        }

        //public long Read()
        //{
        //    int value = int.MinValue;
        //    while (!(value >= 1 && value <= 4))
        //    {
        //        var readed = Console.ReadKey();
        //        value = readed.Key switch
        //        {
        //            ConsoleKey.LeftArrow => (int)RobotCommands.West,
        //            ConsoleKey.RightArrow => (int)RobotCommands.East,
        //            ConsoleKey.UpArrow => (int)RobotCommands.North,
        //            ConsoleKey.DownArrow => (int)RobotCommands.South,
        //            _ => int.MinValue,
        //        };
        //    }

        //    _lastRobotCommand = (RobotCommands)value;
        //    return value;
        //}

        private void AddPoint(Point point, TileType response)
        {
            if (point.X == 0 && point.Y == 0 && response == TileType.Moved)
            {
                response = TileType.Ball;
            }

            if (_grid.ContainsKey(point) && _grid[point] != TileType.Block)
            {
                _grid[point] = response;
            }
            else
            {
                _grid.Add(Point.Create(_lastX, _lastY), response);
            }
        }



        public void Write(long output)
        {

            AddPoint(Point.Create(_lastX, _lastY), TileType.Moved);
            if (output == (int)RobotResponse.Wall)
            {
                var previousLastx = _lastX;
                var previousLasty = _lastY;
                Move();
                AddPoint(Point.Create(_lastX, _lastY), TileType.Wall);
                _lastX = previousLastx;
                _lastY = previousLasty;
                AddPoint(Point.Create(_lastX, _lastY), TileType.Device);

            }
            else if (output == (int)RobotResponse.Moved)
            {
                AddPoint(Point.Create(_lastX, _lastY), TileType.Moved);
                Move();
                AddPoint(Point.Create(_lastX, _lastY), TileType.Device);

            }
            else if (output == (int)RobotResponse.OxigenSystem)
            {
                Move();
                AddPoint(Point.Create(_lastX, _lastY), TileType.Block);
                OxigenPoint = Point.Create(_lastX, _lastY);
                MovementsToOrigin = _currentMovements;
            }
            AddPosibleMovements(Point.Create(_lastX, _lastY), _currentMovements);
        }

        public static List<RobotCommands> MovementsToOrigin { get; set; }

        public static Point OxigenPoint { get; set; }

        private void Move()
        {
            var ppp = Move(_lastX, _lastY, _lastRobotCommand);
            _lastX = ppp.X;
            _lastY = ppp.Y;
        }

        private static Point Move(int x, int y, RobotCommands command)
        {
            int newX = command switch
            {
                RobotCommands.West => x - 1,
                RobotCommands.East => x + 1,
                _ => x
            };
            int newY = command switch
            {
                RobotCommands.South => y + 1,
                RobotCommands.North => y - 1,
                _ => y
            };
            return Point.Create(newX, newY);
        }


        public (Point point, int value)[] GetGrid() => _grid.Select(kvp => (kvp.Key, (int)kvp.Value)).ToArray();
        public static (Point point, int value)[] GetGrid2() => _grid.Select(kvp => (kvp.Key, (int)kvp.Value)).ToArray();

        public static void SetGrid((Point point, int value)[] gridData)
        {
            foreach ((Point point, int value) valueTuple in gridData)
            {
                _grid.Add(valueTuple.point, (TileType)valueTuple.value);
            }
        }

        public static Dictionary<Point, TileType> GetDictionaryGrid() => _grid;

        public static List<Point> GetPosibleMovements(Point oxigenPoint)
        {
            List<Point> points = new List<Point>();
            var movements = new List<RobotCommands> { RobotCommands.North, RobotCommands.South, RobotCommands.West, RobotCommands.East };
            foreach (RobotCommands robotCommandse in movements)
            {
                var point = Move(oxigenPoint.X, oxigenPoint.Y, robotCommandse);
                var value = _grid[point];
                if (value != TileType.Oxigen && value != TileType.Wall)
                {
                    _grid[point] = TileType.Oxigen;
                    points.Add(point);
                }
            }
            return points;

        }
    }


}
