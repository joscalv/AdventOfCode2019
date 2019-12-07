using System.Collections.Generic;
using AdventOfCode;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day3Test
    {

        [Fact]
        public void Part1Version1Test()
        {
            var expected = 375;
            var result = Day3.Part1_Version1();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1Version2Test()
        {
            var expected = 375;
            var result = Day3.Part1_Version2();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2()
        {
            var expected = 14746;
            var result = Day3.Part2();
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(0, 0, "R1", 1, 0)]
        [InlineData(0, 0, "L1", -1, 0)]
        [InlineData(0, 0, "U1", 0, 1)]
        [InlineData(0, 0, "D1", 0, -1)]
        public void TestMovement(int x, int y, string movement, int expectedX, int expectedY)
        {
            var origin = new Point(x, y);
            var expectedResult = new Point(expectedX, expectedY);

            var result = Utils.Move(origin, movement);

            //Assert.Equal(expectedResult, result);
        }

        [Fact]
        [InlineData(0, 0, "R1,R1,R1,R1")]
        public void TestGetPositions()
        {
            Point oirgin = new Point(0, 0);
            var movements = new List<string> { "R1", "R1", "R1", "R1" };
            var expected = new Point[] { new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0) };

            var result = Utils.GetPath(oirgin, movements);

            Assert.Equal(expected, result);
        }




    }
}
