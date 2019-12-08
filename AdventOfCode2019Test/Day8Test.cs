using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode.Day8;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day8Test
    {
        [Fact]
        public void Part1Test()
        {

            var value = Day8.Part1();

            Assert.Equal(1215, value);

        }

        [Fact]
        public void DecodeTest()
        {
            string image = "123456789012";
            var data = ImageDecoder.StringToIntArray(image);
            var img = new Image(3, 2, data);
            Assert.Equal(new int[] { 1, 2, 3 }, img.Layers[0][0]);
            Assert.Equal(new int[] { 4, 5, 6 }, img.Layers[0][1]);
            Assert.Equal(new int[] { 7, 8, 9 }, img.Layers[1][0]);
            Assert.Equal(new int[] { 0, 1, 2 }, img.Layers[1][1]);
        }

        [Fact]
        public void StringToIntTest()
        {
            string image = "123456789012";
            int[] expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };

            var result = ImageDecoder.StringToIntArray(image);
            Assert.Equal(expected, result);

        }
    }
}
