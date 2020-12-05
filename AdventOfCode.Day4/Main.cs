using AdventOfCode.Day4.Implementation;
using System;
using Xunit;

namespace AdventOfCode.Day4
{
    public class Main
    {
        [Fact]
        public void GetNumberOfValidPassport_Part1_AmountValid()
        {
            var passportString = Data.Passports;
            var validator = new PassportValidator();

            var nrOfValid = validator.GetNumberOfValidPassportsFrom(passportString);

            Assert.Equal(224, nrOfValid);
        }
    }
}
