using System.IO;
using System.Linq;

namespace AdventOfCode.IntCode
{
    public static class IntCodeUtils
    {
        public static long[] ReadInput(string path)
        {
            return File
                .ReadAllText(path)
                .Split(',')
                .Select(long.Parse).ToArray();
        }
    }
}
