using AdventOfCode;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day10Test
    {
        private readonly Day10 _day10 = new Day10();
        [Fact]
        public void TestResultPart1()
        {
            long day10Part1Solution = 0;
            Assert.Equal(day10Part1Solution, _day10.Part1());
        }

        [Fact]
        public void TestResultPart2()
        {
            long day10Part2Solution = 0;
            Assert.Equal(day10Part2Solution, _day10.Part2());
        }
    }
}
