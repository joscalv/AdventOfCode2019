using AdventOfCode;
using AdventOfCode.Day5;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day5Test
    {
        [Fact]
        public void Part1Test()
        {
            var expected = 15508323;
            var result= Day5.Part1();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2Test()
        {
            var expected = 9006327;
            var result = Day5.Part2();
            Assert.Equal(expected, result);
        }
    }
}
