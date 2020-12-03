using AdventOfCode.Day2.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Day2
{
    public class PasswordModelTests
    {
        [Fact]
        public void IsValid_GoodPassword_IsTrue()
        {
            var password = new PasswordConverter().Convert("2-4 q: shbqwqpps");

            Assert.True(password.IsValid());
        }

        [Fact]
        public void IsValid_WrongPassword_IsFalse()
        {
            var password = new PasswordConverter().Convert("6-7 w: wwhmzwtwwk");

            Assert.False(password.IsValid());
        }
    }
}
