using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day03
    {
        private readonly List<string> _movesLine1;
        private readonly List<string> _movesLine2;

        public Day03()
        {
            ReadInput(out _movesLine1, out _movesLine2);
        }

        public static void ReadInput(out List<string> movesLine1, out List<string> movesLine2)
        {
            var input = System.IO.File.ReadAllText(@"Inputs\inputDay03.txt");
            movesLine1 = input.Split("\n")[0].Split(',').ToList();
            movesLine2 = input.Split("\n")[1].Split(',').ToList();
        }

        public int Part1_Version1()
        {

            var minDistanceSolution1 = GetDistanceToClosestIntersectionUsingSegments(
                _movesLine1,
                _movesLine2,
                out int minDistance11,
                out Point nearestPoint11,
                out List<Point> joinList11);
            return minDistanceSolution1;
        }

        public int Part1_Version2()
        {
            var minDistanceSolution2 = GetDistanceToClosestIntersectionUsingAllPoints(
                _movesLine1,
                _movesLine2,
                out int minDistance,
                out Point nearestJoin,
                out List<Point> joinList,
                out var positionsLine1,
                out var positionsLine2);
            return minDistanceSolution2;
        }

        public int Part2()
        {
            ReadInput(out var movesLine1, out var movesLine2);

            var minDistanceSolution2 = GetDistanceToClosestIntersectionUsingAllPoints(
                movesLine1,
                movesLine2,
                out int minDistance,
                out Point nearestJoin,
                out List<Point> joinList,
                out var positionsLine1,
                out var positionsLine2);

            var solution2 = Day03.Solution2(nearestJoin, joinList, positionsLine1, positionsLine2);

            return solution2;
        }

        public static int GetDistanceToClosestIntersectionUsingSegments(List<string> movesLine1, List<string> movesLine2, out int minDistance, out Point nearestJoin, out List<Point> intersectionList)
        {
            var origin = new Point(0, 0);
            minDistance = int.MaxValue;
            nearestJoin = Point.Center;

            var segmentsLine1 = UtilsDay3.GetSegments(new Point(0, 0), movesLine1);
            var segmentsLine2 = UtilsDay3.GetSegments(new Point(0, 0), movesLine2);

            intersectionList = segmentsLine1
                .SelectMany(l1 => segmentsLine2.Select(l1.GetIntersection))
                .Where(p => p.X != 0 && p.Y != 0).ToList()
                .ToList();


            foreach (var point in intersectionList)
            {
                var distance = Math.Abs(point.X - origin.X) + Math.Abs(point.Y - origin.Y);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestJoin = point;
                }
            }

            return minDistance;
        }

        public static int GetDistanceToClosestIntersectionUsingAllPoints(List<string> commands1, List<string> commands2, out int minDistance, out Point nearestJoin, out List<Point> joinList, out List<Point> positionsLine1, out List<Point> positionsLine2)
        {
            var origin = new Point(0, 0);
            minDistance = int.MaxValue;
            nearestJoin = Point.Center;

            positionsLine1 = UtilsDay3.GetPath(origin, commands1);
            positionsLine2 = UtilsDay3.GetPath(origin, commands2);

            var d2 = positionsLine2.ToHashSet();

            joinList = new List<Point>();
            Point tmp;

            for (int i = 0; i < positionsLine1.Count; i++)
            {
                tmp = positionsLine1[i];
                if (d2.Contains(tmp) && tmp.X != 0 && tmp.Y != 0)
                {
                    joinList.Add(tmp);
                }
            }

            foreach (var point in joinList)
            {
                var distance = Math.Abs(point.X - origin.X) + Math.Abs(point.Y - origin.Y);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestJoin = point;
                }
            }

            return minDistance;
        }

        public static int Solution2(Point nearestJoin, List<Point> intersections, List<Point> positionsWire1, List<Point> positionsWire2)
        {
            var joins1 = GetMinDistanceToJoin(intersections, positionsWire1);
            var joins2 = GetMinDistanceToJoin(intersections, positionsWire2);
            var distance = int.MaxValue;

            foreach (var join in joins1.Keys)
            {
                var total = joins1[join] + joins2[join];
                if (total < distance)
                {
                    distance = total;
                }
            }

            return distance;
        }

        private static Dictionary<Point, int> GetMinDistanceToJoin(List<Point> joinList, List<Point> path)
        {
            var result = joinList.ToDictionary(join => join, join => int.MaxValue);
            var distance = 1;
            foreach (var point in path)
            {
                if (result.ContainsKey(point) && distance < result[point])
                {
                    result[point] = distance;
                }

                distance++;
            }
            return result;
        }

    }

    public static class UtilsDay3
    {
        public static List<Point> GetJoins(List<Point> positionsLine1, List<Point> positionsLine2)
        {
            return positionsLine1.Intersect(positionsLine2).ToList();
        }

        public static Point Move(Point origin, string movement)
        {
            var direction = movement[0];
            int positions = Int32.Parse(movement.Substring(1));
            return Move(origin, direction, positions);
        }

        public static List<Point> GetPath(Point origin, List<string> movements)
        {
            var previous = origin;
            var path = new List<Point>();
            foreach (var movement in movements)
            {
                var subPath = GetPath(previous, movement);
                path.AddRange(subPath);
                previous = path.Last();
            }

            return path;
        }

        public static List<Point> GetPath(Point origin, string movement)
        {
            var direction = movement[0];
            var previous = origin;
            int positions = Int32.Parse(movement.Substring(1));
            var path = new List<Point>();
            for (int i = 0; i < positions; i++)
            {
                var current = Move(previous, direction, 1);
                path.Add(current);
                previous = current;
            }

            return path;
        }

        public static Point Move(Point origin, char direction, int length)
        {
            Point result = new Point();
            switch (direction)
            {
                case 'R':
                    result = new Point(origin.X + length, origin.Y);
                    break;
                case 'L':
                    result = new Point(origin.X - length, origin.Y);
                    break;
                case 'U':
                    result = new Point(origin.X, origin.Y + length);
                    break;
                case 'D':
                    result = new Point(origin.X, origin.Y - length);
                    break;
            }
            return result;
        }

        public static List<Line> GetSegments(Point point, List<string> movements)
        {
            var result = new List<Line>() { };
            Point previous = point;
            foreach (var movement in movements)
            {
                var end = Move(previous, movement);
                result.Add(new Line(previous, end));
                previous = end;
            }

            return result;
        }
    }

    public class Line
    {
        public Line(Point point0, Point point1)
        {
            Point0 = point0;
            Point1 = point1;
        }

        public Point Point0 { get; }
        public Point Point1 { get; }

        public Point GetIntersection(Line other)
        {
            int a1 = Point1.Y - Point0.Y;
            int b1 = Point0.X - Point1.X;
            int c1 = a1 * Point0.X + b1 * Point0.Y;

            int a2 = other.Point1.Y - other.Point0.Y;
            int b2 = other.Point0.X - other.Point1.X;
            int c2 = a2 * other.Point0.X + b2 * other.Point0.Y;

            int delta = a1 * b2 - a2 * b1;
            //If lines are parallel, the result will be (NaN, NaN).
            var intersection = delta == 0 ? new Point(0, 0)
                : new Point((b2 * c1 - b1 * c2) / delta, (a1 * c2 - a2 * c1) / delta);

            if (intersection.X != 0 && intersection.Y != 0 && IsInsideLine(intersection.X, intersection.Y) &&
                other.IsInsideLine(intersection.X, intersection.Y))
            {
                return intersection;
            }
            else
            {
                return new Point(0, 0);
            }

        }

        private bool IsInsideLine(double x, double y)
        {
            return (x >= Point0.X && x <= Point1.X
                    || x >= Point1.X && x <= Point0.X)
                   && (y >= Point0.Y && y <= Point1.Y
                       || y >= Point1.Y && y <= Point0.Y);
        }
    }

    public struct Point
    {
        public Point(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                return false;
            }

            return Equals((Point)obj);
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }


        public static Point Center => new Point(0, 0);
    }

}
