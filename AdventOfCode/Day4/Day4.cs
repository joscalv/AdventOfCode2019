using System;
using System.Diagnostics;

namespace AdventOfCode.Day4
{
    public static class Day4
    {
        public const int Min = 124075;
        public const int Max = 580769;

       public static int Part1()
        {
            bool Checker(int password) =>
                Day4.IsSixDigit(password)
                && Day4.HasTwoAdjacentEqual(password)
                && Day4.NotDecrease(password);

            return CheckPasswordRange(Checker);
        }

        public static int Part2()
        {
            bool Checker(int password) =>
                Day4.IsSixDigit(password)
                && Day4.HasOnlyTwoAdjacentEqual(password)
                && Day4.NotDecrease(password);

            return CheckPasswordRange(Checker);
        }

        public static int CheckPasswordRange(Func<int, bool> checker)
        {
            int numberOfPasswords = 0;
            for (int password = Min; password <= Max; password++)
            {
                if (checker(password))
                {
                    numberOfPasswords++;
                }
            }

            return numberOfPasswords;
        }


        public static bool NotDecrease(int password)
        {
            var passwordString = password.ToString();

            for (int i = 1; i < passwordString.Length; i++)
            {
                if (passwordString[i - 1] > passwordString[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasTwoAdjacentEqual(int password)
        {
            var passwordString = password.ToString();

            for (int i = 1; i < passwordString.Length; i++)
            {
                if (passwordString[i - 1] == passwordString[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasOnlyTwoAdjacentEqual(int password)
        {
            bool hasTwo = false;
            var p = password.ToString();
            for (int i = 1; i < p.Length; i++)
            {
                if (p[i - 1] == p[i] && (i == 1 || p[i - 2] != p[i]) && (i == 5 || p[i] != p[i + 1]))
                {
                    hasTwo = true;
                }
            }

            return hasTwo;
        }

        public static bool IsSixDigit(int password)
        {
            return password > 99999 && password < 10000000;
        }
    }


}
