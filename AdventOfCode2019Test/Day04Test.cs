using AdventOfCode;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day04Test
    {
        private readonly Day04 _day4 = new Day04();
        
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