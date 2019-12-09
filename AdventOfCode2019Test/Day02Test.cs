using AdventOfCode;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day02Test
    {
        private readonly Day02 _day2 = new Day02();
        [Fact]
        public void Part1Test()
        {
            var expected = 5290681;
            var result = _day2.Part1();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2Test()
        {
            var expected = 5741;
            var result = _day2.Part2();
            Assert.Equal(expected, result);
        }
    }
}
