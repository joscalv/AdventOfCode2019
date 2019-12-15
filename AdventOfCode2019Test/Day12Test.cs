using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day12Test
    {
        private readonly Day12 _day12 = new Day12();

        [Fact]
        public void TestResultPart1()
        {
            long day11Part1Solution = 14606;
            Assert.Equal(day11Part1Solution, _day12.Part1());
        }


        [Fact]
        public void SampleTest1()
        {
            Step step0 = new Step(new int[,]
            {
                {-1, 0, 2, 0, 0, 0},
                {2, -10, -7, 0, 0, 0},
                {4, -8, 8, 0, 0, 0},
                {3, 5, -1, 0, 0, 0},
            });

            var expected1 = new int[,]
            {
                {2, -1, 1, 3, -1, -1},
                {3, -7, -4, 1, 3, 3},
                {1, -7, 5, -3, 1, -3},
                {2, 2, 0, -1, -3, 1}
            };


            var expected2 = new int[,]
            {

                {5, -3, -1, 3, -2, -2},
                {1, -2, 2, -2, 5, 6},
                {1, -4, -1, 0, 3, -6},
                {1, -4, 2, -1, -6, 2},

        };

            var expected10 = new int[,]
            {
                {2, 1, -3, -3, -2, 1},
                {1, -8, 0, -1, 1, 3},
                {3, -6, 1, 3, 2, -3},
                {2, 0, 4, 1, -1, -1}
            };

            var expectedTotalEnergy = 179;

            var step1 = step0.GetNextStep();
            var step2 = step1.GetNextStep();
            var step3 = step2.GetNextStep();
            var step4 = step3.GetNextStep();
            var step5 = step4.GetNextStep();
            var step6 = step5.GetNextStep();
            var step7 = step6.GetNextStep();
            var step8 = step7.GetNextStep();
            var step9 = step8.GetNextStep();
            var step10 = step9.GetNextStep();

            Assert.Equal(expected1, step1.Status);
            Assert.Equal(expected2, step2.Status);
            Assert.Equal(expected10, step10.Status);
            Assert.Equal(expectedTotalEnergy, step10.GetTotalEnergy());
        }
    }
}
