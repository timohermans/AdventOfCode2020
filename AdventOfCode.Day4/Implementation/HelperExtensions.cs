using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day4.Implementation
{
    public static class HelperExtensions
    {
        public static bool IsBetweenRange(this int number, int min, int max)
        {
            return number >= min && number <= max;
        }
    }
}
