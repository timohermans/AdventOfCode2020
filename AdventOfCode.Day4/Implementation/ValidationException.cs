using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day4.Implementation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
