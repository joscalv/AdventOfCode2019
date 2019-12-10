using System.Collections.Generic;
using System.Linq;
using AdventOfCode;
using AdventOfCode.Model;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day10Test
    {
        private readonly Day10 _day10 = new Day10();
        [Fact]
        public void TestResultPart1()
        {
            long day10Part1Solution = 214;
            Assert.Equal(day10Part1Solution, _day10.Part1());
        }

        [Fact]
        public void TestResultPart2()
        {
            long day10Part2Solution = 502;
            Assert.Equal(day10Part2Solution, _day10.Part2());
        }

        [Fact]
        public void TestIntersection()
        {
            var line = new Line(new Point(3, 4), new Point(1, 0));
            Assert.Equal(0, line.DistanceTo(new Point(2, 2)));
            Assert.NotEqual(0, line.DistanceTo(new Point(2, 3)));
            line = new Line(new Point(4, 0), new Point(3, 4));
            Assert.False(line.IsInsideLine(new Point(4, 2)));

            line = new Line(new Point(4, 0), new Point(3, 4));
            Assert.False(line.IsInsideLine(new Point(2, 2)));
            Assert.False(line.IsInsideLine(new Point(4, 2)));
            Assert.False(line.IsInsideLine(new Point(4, 3)));
            Assert.False(line.IsInsideLine(new Point(4, 3)));
            Assert.False(line.IsInsideLine(new Point(4, 3)));
            Assert.False(line.IsInsideLine(new Point(3, 2)));
        }

        [Fact]
        public void TestAngleCalculation()
        {
            var origin = new Point(0, 0);
            Assert.Equal(0, origin.GetAngle(new Point(0, 100)));
            Assert.Equal(45, origin.GetAngle(new Point(100, 100)));
            Assert.Equal(90, origin.GetAngle(new Point(100, 0)));
            Assert.Equal(135, origin.GetAngle(new Point(100, -100)));
            Assert.Equal(180, origin.GetAngle(new Point(0, -100)));
            Assert.Equal(225, origin.GetAngle(new Point(-100, -100)));
            Assert.Equal(270, origin.GetAngle(new Point(-100, -0)));
            Assert.Equal(315, origin.GetAngle(new Point(-100, 100)));

            origin = new Point(10, 7);
            Assert.Equal(0, origin.GetAngle(new Point(10, 17)));
            Assert.Equal(45, origin.GetAngle(new Point(20, 17)));
            Assert.Equal(90, origin.GetAngle(new Point(20, 7)));
            Assert.Equal(135, origin.GetAngle(new Point(20, -3)));
            Assert.Equal(180, origin.GetAngle(new Point(10, -3)));
            Assert.Equal(225, origin.GetAngle(new Point(0, -3)));
            Assert.Equal(270, origin.GetAngle(new Point(0, 7)));
            Assert.Equal(315, origin.GetAngle(new Point(0, 17)));
        }

        [Fact]
        public void TestSample1()
        {
            string sample1 = $".#..#\r.....\r#####\r....#\r...##";

            var asteroids = Day10Utils.ParseInput(sample1);
            var result = Day10.GetNumberOfVisibleAsteroids(asteroids, out var asteroid);
            Assert.Equal(new Point(3, 4), asteroid);
            Assert.Equal(8, result);

        }

        [Fact]
        public void TestSample2()
        {
            string sample1 =
                $"......#.#.\r" +
                $"#..#.#....\r" +
                $"..#######.\r" +
                $".#.#.###..\r" +
                $".#..#.....\r" +
                $"..#....#.#\r" +
                $"#..#....#.\r" +
                $".##.#..###\r" +
                $"##...#..#.\r" +
                $".#....####";

            var asteroids = Day10Utils.ParseInput(sample1);
            var result = Day10.GetNumberOfVisibleAsteroids(asteroids, out var asteroid);
            Assert.Equal(33, result);
            Assert.Equal(new Point(5, 8), asteroid);

        }

        [Fact]
        public void TestSample3()
        {
            string sample1 =
                $"#.#...#.#.\r" +
                $".###....#.\r" +
                $".#....#...\r" +
                $"##.#.#.#.#\r" +
                $"....#.#.#.\r" +
                $".##..###.#\r" +
                $"..#...##..\r" +
                $"..##....##\r" +
                $"......#...\r" +
                $".####.###.";

            var asteroids = Day10Utils.ParseInput(sample1);
            var result = Day10.GetNumberOfVisibleAsteroids(asteroids, out var asteroid);
            Assert.Equal(35, result);
            Assert.Equal(new Point(1, 2), asteroid);

        }

        [Fact]
        public void TestSample4()
        {
            string sample1 =
                $".#..#..###\r" +
                $"####.###.#\r" +
                $"....###.#.\r" +
                $"..###.##.#\r" +
                $"##.##.#.#.\r" +
                $"....###..#\r" +
                $"..#.#..#.#\r" +
                $"#..#.#.###\r" +
                $".##...##.#\r" +
                $".....#.#..";

            var asteroids = Day10Utils.ParseInput(sample1);
            var result = Day10.GetNumberOfVisibleAsteroids(asteroids, out var asteroid);
            Assert.Equal(41, result);
            Assert.Equal(new Point(6, 3), asteroid);

        }

        [Fact]
        public void TestSample5()
        {
            string sample1 =
                $".#..##.###...#######\r" +
                $"##.############..##.\r" +
                $".#.######.########.#\r" +
                $".###.#######.####.#.\r" +
                $"#####.##.#.##.###.##\r" +
                $"..#####..#.#########\r" +
                $"####################\r" +
                $"#.####....###.#.#.##\r" +
                $"##.#################\r" +
                $"#####.##.###..####..\r" +
                $"..######..##.#######\r" +
                $"####.##.####...##..#\r" +
                $".#####..#.######.###\r" +
                $"##...#.##########...\r" +
                $"#.##########.#######\r" +
                $".####.#.###.###.#.##\r" +
                $"....##.##.###..#####\r" +
                $".#.#.###########.###\r" +
                $"#.#.#.#####.####.###\r" +
                $"###.##.####.##.#..##";

            var asteroids = Day10Utils.ParseInput(sample1);
            var result = Day10.GetNumberOfVisibleAsteroids(asteroids, out var asteroid);
            Assert.Equal(210, result);
            Assert.Equal(new Point(11, 13), asteroid);

        }

        [Fact]
        public void ParseInputTest()
        {
            string sample1 = $".#..#\r.....\r#####\r....#\r...##";
            List<Point> expected = new List<Point>() { new Point(1, 0), new Point(4, 0), new Point(0, 2), new Point(1, 2), new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(4, 3), new Point(3, 4), new Point(4, 4) };

            var result = Day10Utils.ParseInput(sample1);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].X, result.ToList()[i].X);
                Assert.Equal(expected[i].Y, result.ToList()[i].Y);
            }

        }


    }
}

