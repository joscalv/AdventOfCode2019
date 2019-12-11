using AdventOfCode.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day10
    {
        private readonly Point[] _program = Day10Utils.ReadInput();

        public long Part1()
        {
            return GetNumberOfVisibleAsteroids(_program, out _);
        }

        public static int GetNumberOfVisibleAsteroidsOld(Point[] asteroids, out Point mostVisibleAsteroid)
        {
            Dictionary<Point, int> dPoints = asteroids.ToDictionary(p => p, p => 0);
            int maxValue = 0;

            foreach (Point asteroid in asteroids)
            {
                var lines = asteroid
                    .GetCandidateVisibleAsteroids(asteroids)
                    .Select(visibleAsteroid =>
                        new Line(asteroid, visibleAsteroid)
                    )
                    .ToList();


                var withoutObstacles = lines
                    .Where(line => line.GetCandidateObstacles(asteroids).Count(line.IsInsideLine) == 0)
                    .Select(line => line.Point1).ToList();

                var tmp = withoutObstacles.Count();
                if (tmp > maxValue)
                {
                    maxValue = tmp;
                    mostVisibleAsteroid = asteroid;
                }

                dPoints[asteroid] = tmp;
            }

            mostVisibleAsteroid = dPoints.OrderByDescending(kvp => kvp.Value).First().Key;
            return dPoints.Values.Max();
        }

        public static int GetNumberOfVisibleAsteroids(Point[] asteroids, out Point mostVisibleAsteroid)
        {
            int max = 0;
            mostVisibleAsteroid = default(Point);

            foreach (var asteroid in asteroids)
            {
                var test = asteroids.Except(new[] { asteroid }).GroupBy(other => asteroid.GetAngle(other));

                var numberOfVisible = test.Count();
                if (numberOfVisible > max)
                {
                    mostVisibleAsteroid = asteroid;
                    max = numberOfVisible;
                }
            }

            return max;
        }



        public int Part2()
        {
            var center = new Point(8, 16);
            var points = new List<(double angle, double distance, Point asteroid)>();


            var orderedAsteroids = _program
                .Where(p => p != center)
                .Select(point => (angle: center.GetAngle(point), dist: center.GetDistance(point), asteroid: point))
                .GroupBy(a => a.angle)
                .OrderBy(g => g.First().angle)
                .SelectMany(g =>
                {
                    var angle = 0;
                    var elements = new List<(double angle, double distance, Point asteroid)>();
                    foreach ((double angle, double dist, Point asteroid) valueTuple in g.OrderBy(e => e.dist))
                    {
                        elements.Add((valueTuple.angle + angle, valueTuple.dist, valueTuple.asteroid));
                        angle = angle + 360;
                    }

                    return elements;
                });

            var asteroidDestroid200 = orderedAsteroids.ElementAt(200).asteroid;
            return asteroidDestroid200.X * 100 + asteroidDestroid200.Y;
        }



        public int MaxNumberOfSatilleVisible(string input)
        {
            throw new System.NotImplementedException();
        }
    }

    public static class Day10Utils
    {
        public static Point[] ReadInput()
        {
            return File
                .ReadAllText(@"Inputs\inputDay10.txt")
                .ParseInput();

        }

        public static Point[] ParseInput(this string input)
        {
            var result = new List<Point>();
            string[] lines = input.Split('\n', '\r');
            int maxX = lines?.First()?.Length ?? 0;

            for (int y = 0; y < lines?.Length; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (lines[y][x] == '#')
                    {
                        result.Add(new Point(x, y));
                    }
                }
            }

            return result.ToArray();
        }

        public static Point[] GetCandidateVisibleAsteroids(this Point origin, Point[] asteroids)
        {
            return asteroids.Where(a => a != origin).ToArray();
        }

        public static Point[] GetCandidateObstacles(this Line line, Point[] asteroids)
        {
            return asteroids.Where(a => line.Point0 != a && line.Point1 != a).ToArray();
        }
    }
}