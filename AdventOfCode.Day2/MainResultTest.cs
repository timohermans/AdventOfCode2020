using AdventOfCode.Day2.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Day2
{
    public class MainResultTest
    {
        [Fact]
        public void ConvertMultiple_AllPasswords_ReturnsValidPasswords()
        {
            var passwords = new PasswordConverter().ConvertMultiple(Data.PasswordInput);

            Assert.Equal(477, passwords.Count(p => p.IsValid()));
        }

        [Fact]
        public void ConvertMultiple_AllPasswordsPart2_ReturnsValidPasswords()
        {
            var passwords = new PasswordConverter().ConvertMultiple(Data.PasswordInput);

            Assert.Equal(686, passwords.Count(p => p.IsValidPart2()));
        }

    }
}
