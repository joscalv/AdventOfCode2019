namespace AdventOfCode.Day1
{
    public static class FuelCalculator
    {
        public static int GetFuel(int mass)
        {
            if (mass > 6)
            {
                int fuel = (int)(mass / 3) - 2;
                return fuel + GetFuel(fuel);
            }
            return 0;
        }
    }
}