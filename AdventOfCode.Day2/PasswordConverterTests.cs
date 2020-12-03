using AdventOfCode.Day2.Implementation;
using System;
using Xunit;

namespace AdventOfCode.Day2
{
    public class PasswordConverterTests
    {
        [Fact]
        public void Convert_SingleRow_Successful()
        {
            var password = "6-7 w: wwhmzwtwwk";

            var actualPassword = new PasswordConverter().Convert(password);

            Assert.Equal(new PasswordModel { 
                CharacterRequired = 'w',
                CharacterMinOccurrence = 6,
                CharacterMaxOccurrence = 7,
                Password = "wwhmzwtwwk"
            }, actualPassword);
        }

        [Fact]
        public void ConvertMultiple_TwoRows_Converts2Rows()
        {
            var passwords = @"
6-7 w: wwhmzwtwwk
2-4 q: shbqwqpps";

            var actualPasswords = new PasswordConverter().ConvertMultiple(passwords);

            Assert.Equal(2, actualPasswords.Count);
        }
    }
}
