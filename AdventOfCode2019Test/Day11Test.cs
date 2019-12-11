using AdventOfCode;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day11Test
    {
        private readonly Day11 _day11 = new Day11();

        [Fact]
        public void TestResultPart1()
        {
            long day11Part1Solution = 2322;
            Assert.Equal(day11Part1Solution, _day11.Part1());
        }
    }
}

