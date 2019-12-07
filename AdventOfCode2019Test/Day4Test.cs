using AdventOfCode;
using AdventOfCode.Day4;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day4Test
    {
        [Fact]
        public void Part1Test()
        {
            var expected = 2150;
            var result = Day4.Part1();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2Test()
        {
            var expected = 1462;
            var result = Day4.Part2();
            Assert.Equal(expected, result);
        }
    }
}