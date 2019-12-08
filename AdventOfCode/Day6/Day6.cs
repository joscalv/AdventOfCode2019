using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day6
{
    public static class Day6
    {
        public static int Part1()
        {
            var orbits = ReadInput();
            var orbitAnalyzer = new OrbitAnalyzer(orbits);
            var value = orbitAnalyzer.GetNumberOfOrbits();
            return value;
        }

        public static int Part2()
        {
            var orbits = ReadInput();
            var orbitAnalyzer = new OrbitAnalyzer(orbits);
            var value = orbitAnalyzer.GetOrbitalTransfers("YOU", "SAN");
            return value;
        }


        public static (string center, string satellite)[] ReadInput()
        {
            return ReadInput(@"Inputs\inputDay6.txt");
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