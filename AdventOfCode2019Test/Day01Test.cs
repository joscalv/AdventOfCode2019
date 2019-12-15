using AdventOfCode.Model;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day01Test
    {
        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void FuelCalculatorTest(int input, int output)
        {
            Assert.Equal(output, FuelCalculator.GetFuel(input));
        }
    }
}