using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day8
{
    public class Day8
    {

        private readonly int[] Input = ReadInput().StringToIntArray();
        public static int Width = 25;
        public static int Height = 6;

       public int Part1ComplexImage()
        {
            var image = new ComplexImage(Width, Height, Input);

            int zeros = Int32.MaxValue;
            int unoes = 0;
            int two = 0;
            var tmp = 0;
            for (int i = 0; i < image.Data.Length; i++)
            {
                tmp = Utils.NumberOf(image.Data[i], 0);
                if (tmp < zeros)
                {
                    zeros = tmp;
                    unoes = Utils.NumberOf(image.Data[i], 1);
                    two = Utils.NumberOf(image.Data[i], 2);
                }
            }

            return unoes * two;
        }

        public string Part2ComplexImage()
        {
            var input = ReadInput();
            var imageBytes = input.StringToIntArray();
            var image = new ComplexImage(Width, Height, imageBytes);

            var result = image.DecodeImage();

            var resultStirng = new StringBuilder();
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (x == 0 && y != 0)
                    {
                        resultStirng.Append(Environment.NewLine);
                    }

                    resultStirng.Append((char)result[y, x]);
                }
            }

            return resultStirng.ToString();
        }

        public int Part1SimpleImage()
        {
            var image = new Image(Input, Width, Height);
            return image.GetNumberOf1Mult2WhenOfLayerWhenZeroIsMinimal();
        }

        public string Part2SimpleImage()
        {
            var image = new Image(Input, Width, Height);

            var decodedImage = image.DecodeImage();

            return decodedImage;
        }

        public static string ReadInput()
        {
            return File.ReadAllText(@"Inputs\inputDay8.txt");
        }

      
    }

    public static class Utils
    {
        public static int[] StringToIntArray(this string s)
        {
            int length = s.Length;
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = s[i] - 48;
            }

            return result;
        }

        public static int NumberOf(int[][] dataLayer, int value)
        {
            return dataLayer.SelectMany(v => v).Count(v => v == value);
        }

        public static int GetNumberOf1Mult2WhenOfLayerWhenZeroIsMinimal(this Image image)
        {
            var result = new int[] { Int32.MaxValue, 0, 0 };
            var tmp = new int[3] { 0, 0, 0 };
            var previousLayer = 0;

            for (int i = 0; i < image.Data.Length; i++)
            {
                int layer = i / image.BytesPerLayer;
                if (layer != previousLayer)
                {
                    if (tmp[0] < result[0])
                    {
                        result = tmp;
                    }
                    tmp = new int[] { 0, 0, 0, };
                    previousLayer = layer;
                }

                if (image.Data[i] < 3)
                {
                    tmp[image.Data[i]] = tmp[image.Data[i]] + 1;
                }
            }

            if (tmp[0] < result[0])
            {
                result = tmp;
            }

            return result[1] * result[2];

        }

        public static int[,] DecodeImage(this ComplexImage img)
        {
            var result = new int[img.Height, img.Width];
            var colors = new int[] { 32, 35, 0 };

            for (int layer = 0; layer < img.Data.Length; layer++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        if (result[y, x] == 0)
                        {
                            result[y, x] = colors[img.Data[layer][y][x]];
                        }
                    }
                }
            }

            return result;
        }
    }


    [ObsoleteAttribute]
    public class ComplexImage
    {
        public ComplexImage(int width, int height, int[] data)
        {
            Width = width;
            Height = height;
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

            Data = layerData;
        }

        public int Width { get; }

        public int Height { get; }

        public int[][][] Data { get; }
    }

    public class Image
    {
        public Image(int[] data, int width, int height)
        {
            Data = data;
            Width = width;
            Height = height;
            BytesPerLayer = Width * Height;
            NumLayers = Data.Length / (BytesPerLayer);
        }

        public int[] Data { get; }
        public int Width { get; }
        public int Height { get; }
        public int BytesPerLayer { get; }
        public int NumLayers { get; }

        public string DecodeImage()
        {
            var result = new int[Height, Width];
            var colors = new[] { ' ', '#', 0 };

            for (int layer = 0; layer < NumLayers; layer++)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        if (result[y, x] == colors[2])
                        {
                            int index = GetIndex(layer, x, y);
                            result[y, x] = colors[Data[index]];
                        }
                    }
                }
            }

            var resultString = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (y != 0 && x == 0)
                    {
                        resultString.Append(Environment.NewLine);
                    }

                    resultString.Append((char)result[y, x]);
                }
            }

            return resultString.ToString();
        }

        private int GetIndex(int layer, int x, int y)
        {
            return layer * BytesPerLayer + y * Width + x;
        }
    }
}
