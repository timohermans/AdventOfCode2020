﻿using AdventOfCode.Day4;
using AdventOfCode.Day4.Implementation;
using System;

namespace AdventOfDay.Consoled
{
    class Program
    {
        static void Main(string[] args)
        {
            var passportString = Data.Passports;
            var validator = new PassportValidator();

            var nrOfValid = validator.GetNumberOfValidPassportsFrom(passportString);
            Console.ReadLine();
        }
    }
}
