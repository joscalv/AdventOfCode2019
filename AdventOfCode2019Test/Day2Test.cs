using AdventOfCode;
using AdventOfCode.Day2;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day2Test
    {
        [Fact]
        public void Part1Test()
        {
            var expected = 5290681;
            var result = Day2.Part1();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2Test()
        {
            var expected = 5741;
            var result = Day2.Part2();
            Assert.Equal(expected, result);
        }
    }
}
