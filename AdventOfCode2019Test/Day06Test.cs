using AdventOfCode;
using AdventOfCode.Day6;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day06Test
    {
        private readonly Day06 _day6 = new Day06();

        [Fact]
        public void Part1()
        {
            var expected = 333679;
            var value = _day6.Part1();

            Assert.Equal(expected, value);
        }

        [Fact]
        public void Part1Sample()
        {
            var expected = 42;
            var orbits = Day06.ReadInput(@"Inputs\inputDay06Test1.txt");
            var orbitAnalyzer = new OrbitAnalyzer(orbits);
            var value = orbitAnalyzer.GetNumberOfOrbits();
            Assert.Equal(expected, value);
        }

        [Fact]
        public void Part2()
        {
            var expected = 370;
            var value = _day6.Part2();

            Assert.Equal(expected, value);
        }

        [Fact]
        public void Part2Sample()
        {
            var expected = 4;
            var orbits = Day06.ReadInput(@"Inputs\inputDay06Test2.txt");
            var orbitAnalyzer = new OrbitAnalyzer(orbits);
            var value = orbitAnalyzer.GetOrbitalTransfers("YOU", "SAN");
            Assert.Equal(expected, value);
        }
    }
}