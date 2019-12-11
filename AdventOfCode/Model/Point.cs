using System;

namespace AdventOfCode.Model
{
    public struct Point
    {
        public Point(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public double GetAngle(Point another)
        {
            double xDelta = another.X - X;
            double yDelta = another.Y - Y;
            return ((Math.Atan2(xDelta, yDelta) * (180 / Math.PI) + 360) % 360);
        }

        public double GetDistance(Point another)
        {
            double xDelta = another.X - X;
            double yDelta = another.Y - Y;
            return Math.Sqrt((xDelta * xDelta + yDelta * yDelta));
        }

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

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

        public static Point Center => new Point(0, 0);

        public static Point Create(int x, int y) => new Point(x, y);
    }
}