using System;
using System.Collections.Generic;

namespace AdventOfCode.Day6
{
    public class OrbitAnalyzer
    {
        private readonly Dictionary<string, ElementInOrbit> _elementsInOrbit;

        public OrbitAnalyzer((string, string)[] orbitDescriptions)
        {
            _elementsInOrbit = new Dictionary<string, ElementInOrbit>();
            foreach (var orbitDescription in orbitDescriptions)
            {
                var (idCenter, idOrbitElement) = orbitDescription;

                if (!_elementsInOrbit.TryGetValue(idCenter, out var center))
                {
                    center = new ElementInOrbit(idCenter, null);
                    _elementsInOrbit.Add(idCenter, center);
                }

                if (!_elementsInOrbit.TryGetValue(idOrbitElement, out var elementIdOrbit))
                {
                    _elementsInOrbit.Add(idOrbitElement, new ElementInOrbit(idOrbitElement, center));
                }
                else if (elementIdOrbit.Center == null)
                {
                    elementIdOrbit.SetCenter(center);
                }
                else
                {
                    Console.WriteLine("This must not happen");
                }
            }
        }

        public int GetNumberOfOrbits()
        {
            int orbits = 0;
            foreach (var value in _elementsInOrbit.Values)
            {
                orbits = orbits + value.GetNumberOfOrbits();
            }

            return orbits;
        }

        public int GetOrbitalTransfers(string origin, string destination)
        {
            List<string> orbitsOrigin = GetElementsInOrbit(origin);
            List<string> orbitsDestination = GetElementsInOrbit(destination);
            var orbitsOriginLength = orbitsOrigin.Count;
            var orbitsDestinationLength = orbitsDestination.Count;

            int i = 1;
            while (orbitsOrigin[orbitsOriginLength - i] == orbitsDestination[orbitsDestinationLength - i])
            {
                i++;
            }

            var distance = (orbitsOriginLength - i + 1) + (orbitsDestinationLength - i + 1);

            return distance;
        }

        public List<string> GetElementsInOrbit(string elementId)
        {
            List<string> elements = new List<string>();
            if (_elementsInOrbit.TryGetValue(elementId, out var element))
            {
                while (element.Center != null)
                {
                    elements.Add(element.Center.Id);
                    element = element.Center;
                }
            }
            return elements;
        }
    }
}