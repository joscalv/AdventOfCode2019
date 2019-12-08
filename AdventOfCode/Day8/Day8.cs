using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;

namespace AdventOfCode.Day8
{
    public static class Day8
    {
        public static int Part1()
        {
            var input = ReadInput();
            var imageBytes = ImageDecoder.StringToIntArray(input);
            int width = 25;
            int height = 6;
            var image = new Image(width, height, imageBytes);

            int zeros = Int32.MaxValue;
            int unoes = 0;
            int two = 0;
            var tmp = 0;
            for (int i = 0; i < image.Layers.Length; i++)
            {
                tmp = NumberOf(image.Layers[i], 0);
                if (tmp < zeros)
                {
                    zeros = tmp;
                    unoes = NumberOf(image.Layers[i], 1);
                    two = NumberOf(image.Layers[i], 2);
                }
            }

            return unoes * two;
        }

        public static void Part2()
        {
            var input = ReadInput();
            var imageBytes = ImageDecoder.StringToIntArray(input);
            int width = 25;
            int height = 6;
            var image = new Image(width, height, imageBytes);

            var result = image.DecodeImage();

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (x == 0)
                    {
                        Console.Write(Environment.NewLine);
                    }
                    Console.Write((char)(result[y,x]));
                    
                }
            }
        }

        private static int NumberOf(int[][] dataLayer, int value)
        {
            return dataLayer.SelectMany(v => v).Count(v => v == value);
        }


        private static string ReadInput()
        {
            return File.ReadAllText(@"Inputs\inputDay8.txt");
        }


    }

    public static class ImageDecoder
    {
        public static int[] StringToIntArray(string s)
        {
            int length = s.Length;
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = s[i] - 48;
            }
            return result;
        }


        public static int[,] DecodeImage(this Image img)
        {
            var result = new int[img.Height, img.Width];
            var colors = new int[] {32, 35, 0};

            for (int layer = 0; layer < img.Layers.Length; layer++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        if (result[y,x]== 0)
                        {
                            result[y, x] = colors[img.Layers[layer][y][x]];
                        }
                    }
                }
            }

            return result;
        }
    }

    public class Image
    {
        public int Width { get; }
        public int Height { get; }
        private readonly int[] _data;

        public Image(int width, int height, int[] data)
        {
            Width = width;
            Height = height;
            _data = data;
            var layerSize = Width * Height;
            var numLayers = data.Length / layerSize;
            var layerData = new int[numLayers][][];

            for (int i = 0; i < data.Length; i++)
            {
                int layer = i / layerSize;
                int elementInLayer = i % layerSize;
                if (elementInLayer == 0)
                {
                    layerData[layer] = new int[height][];
                }

                int elementInRow = elementInLayer % width;
                int row = elementInLayer / width;
                if (elementInRow == 0)
                {
                    layerData[layer][row] = new int[width];
                }
                layerData[layer][row][elementInRow] = data[i];
            }

            Layers = layerData;
        }

        public int[][][] Layers { get; }
    }
}

