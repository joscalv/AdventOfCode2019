namespace AdventOfCode.Day6
{
    public class ElementInOrbit
    {

        public ElementInOrbit(string id, ElementInOrbit center)
        {
            Id = id;
            Center = center;
        }

        public string Id { get; }

        public ElementInOrbit Center { get; private set; }

        public int GetNumberOfOrbits()
        {
            int i = 0;
            ElementInOrbit currentElement = this;
            while (currentElement.Center != null)
            {
                i++;
                currentElement = currentElement.Center;
            }

            return i;
        }

        public void SetCenter(ElementInOrbit center)
        {
            Center = center;
        }
    }
}