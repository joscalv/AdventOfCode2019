using AdventOfCode;
using AdventOfCode.Day4;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day4Test
    {
        private readonly Day4 _day4 = new Day4();
        
        [Fact]
        public void Part1Test()
        {
            var expected = 2150;
            var result = _day4.Part1();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2Test()
        {
            var expected = 1462;
            var result = _day4.Part2();
            Assert.Equal(expected, result);
        }
    }
}