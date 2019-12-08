using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode.Day8;
using Xunit;

namespace AdventOfCode2019Test
{
    public class Day8Test
    {
        private string expectedResult2 =
            $"#    #  #  ##  ###  #  # \r\n" +
            $"#    #  # #  # #  # #  # \r\n" +
            $"#    #### #    #  # #### \r\n" +
            $"#    #  # #    ###  #  # \r\n" +
            $"#    #  # #  # #    #  # \r\n" +
            $"#### #  #  ##  #    #  # ";
        
        
        [Fact]
        public void Part1ComplexTest()
        {
            var value = Day8.Part1ComplexImage();

            Assert.Equal(1215, value);

        }

        [Fact]
        public void Part1TestSimpleImage()
        {
            var value = Day8.Part1SimpleImage();

            Assert.Equal(1215, value);

        }

        [Fact]
        public void Part2TestComplexImage()
        {
            var value = Day8.Part2ComplexImage();

            Assert.Equal(expectedResult2, value);

        }

         [Fact]
        public void Part2TestSimpleImage()
        {
            var value = Day8.Part2ComplexImage();

            Assert.Equal(expectedResult2, value);

        }

        [Fact]
        public void DecodeTest()
        {
            string image = "123456789012";
            var data = Day8.StringToIntArray(image);
            var img = new ComplexImage(3, 2, data);
            Assert.Equal(new int[] { 1, 2, 3 }, img.Data[0][0]);
            Assert.Equal(new int[] { 4, 5, 6 }, img.Data[0][1]);
            Assert.Equal(new int[] { 7, 8, 9 }, img.Data[1][0]);
            Assert.Equal(new int[] { 0, 1, 2 }, img.Data[1][1]);
        }

        [Fact]
        public void StringToIntTest()
        {
            string image = "123456789012";
            int[] expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };

            var result = Day8.StringToIntArray(image);
            Assert.Equal(expected, result);

        }
    }
}
