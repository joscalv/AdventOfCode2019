using System;
using System.Drawing;

namespace AdventOfCode.Model
{
    public class Line
    {
        private readonly float dx;
        private readonly float dy;
        public Line(Point point0, Point point1)
        {
            Point0 = point0;
            Point1 = point1;
            dx = Point1.X - Point0.X;
            dy = Point1.Y - Point0.Y;
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

            if (intersection.X != 0 && intersection.Y != 0 && IsInsideArea(intersection.X, intersection.Y) &&
                other.IsInsideArea(intersection.X, intersection.Y))
            {
                return intersection;
            }
            else
            {
                return new Point(0, 0);
            }

        }

        public bool IsInsideLine(Point point)
        {
            return IsInsideArea(point.X, Point1.Y) && !(DistanceTo(point) != 0);
        }



        private bool IsInsideArea(double x, double y)
        {
            return (x >= Point0.X && x <= Point1.X
                    || x >= Point1.X && x <= Point0.X)
                   && (y >= Point0.Y && y <= Point1.Y
                       || y >= Point1.Y && y <= Point0.Y);
        }

        public double DistanceTo(Point pt)
        {
            return DistanceTo(pt, out _);
        }

        public double DistanceTo(Point pt, out PointF closest)
        {
            float deltaX, deltaY;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = new PointF(Point0.X, Point0.Y);
                deltaX = pt.X - Point0.X;
                deltaY = pt.Y - Point0.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            // Calculate the t that minimizes the distance.
            float t = ((pt.X - Point0.X) * dx + (pt.Y - Point0.Y) * dy) /
                      (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new PointF(Point0.X, Point0.Y);
                deltaX = pt.X - Point0.X;
                deltaY = pt.Y - Point0.Y;
            }
            else if (t > 1)
            {
                closest = new PointF(Point1.X, Point1.Y);
                deltaX = pt.X - Point1.X;
                deltaY = pt.Y - Point1.Y;
            }
            else
            {
                closest = new PointF((Point0.X + t * dx), (Point0.Y + t * dy));
                deltaX = pt.X - closest.X;
                deltaY = pt.Y - closest.Y;
            }

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Line))
            {
                return false;
            }

            return Equals((Line)obj);
        }

        public bool Equals(Line other)
        {
            return (other.Point1 == Point1 && other.Point0 == Point0)
                   || (other.Point1 == Point0 && other.Point0 == Point1);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Point0.GetHashCode() * Point1.GetHashCode()^ 133;
            }
        }
    }
}