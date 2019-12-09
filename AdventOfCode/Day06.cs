using System.IO;
using System.Linq;
using AdventOfCode.Day6;

namespace AdventOfCode
{
    public class Day06
    {

        private readonly (string center, string satellite)[] _orbits = ReadInput();

        public int Part1()
        {
            var orbitAnalyzer = new OrbitAnalyzer(_orbits);
            var value = orbitAnalyzer.GetNumberOfOrbits();
            return value;
        }

        public int Part2()
        {
            var orbitAnalyzer = new OrbitAnalyzer(_orbits);
            var value = orbitAnalyzer.GetOrbitalTransfers("YOU", "SAN");
            return value;
        }


        public static (string center, string satellite)[] ReadInput()
        {
            return ReadInput(@"Inputs\inputDay06.txt");
        }

        public static (string center, string satellite)[] ReadInput(string path)
        {
            return File.ReadAllText(path)
                .Split('\n')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(ParseOrbitDescription)
                .ToArray();
        }

        private static (string center, string satellite) ParseOrbitDescription(string s)
        {
            var tmp = s.Split(')');
            return (tmp[0].Trim(), tmp[1].Trim());
        }
    }
}