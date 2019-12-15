using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day13Test
    {
        private readonly Day13 _day13 = new Day13();

        [Fact]
        public void TestResultPart1()
        {
            long day11Part1Solution = 270;
            Assert.Equal(day11Part1Solution, _day13.Part1());
        }

    }
}
