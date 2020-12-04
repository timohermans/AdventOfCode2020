using AdventOfCode.Day4.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day4.Tests
{
    public class PassportValidatorTests
    {
        [Fact]
        public void GetNumberOfValidPassports_AllFieldsValid_IsValid()
        {
            var input = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm"
;
            var validator = new PassportValidator();

            var nrOfValid = validator.GetNumberOfValidPassportsFrom(input);

            Assert.Equal(2, nrOfValid);
        }
    }
}

