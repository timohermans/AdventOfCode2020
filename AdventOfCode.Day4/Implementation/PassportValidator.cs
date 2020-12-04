using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode.Day4.Implementation
{
    public class PassportValidator
    {

        public int GetNumberOfValidPassportsFrom(string passportsString)
        {
            var passports = passportsString.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var nrOfValidPassports = 0;

            foreach (var passportString in passports)
            {
                try
                {
                    new Passport(passportString);
                    nrOfValidPassports++;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Invalid passport: \r\n {passportString} \r\n Missing property: \r\n {ex.ParamName}");
                }
                catch (ValidationException ex)
                {
                    Console.WriteLine($"Passport has and invalid value: \r\n {ex.Message}");
                }
            }

            return nrOfValidPassports;
        }
    }
}
