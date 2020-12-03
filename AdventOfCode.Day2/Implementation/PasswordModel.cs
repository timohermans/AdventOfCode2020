using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day2.Implementation
{
    public record PasswordModel
    {
        public char CharacterRequired { get; init; }
        public int CharacterMinOccurrence { get; init; }
        public int CharacterMaxOccurrence { get; init; }
        public string Password { get; init; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Password)) return false;

            var requiredCharacterOccurrence = Password.ToCharArray().Where(s => s == CharacterRequired).Count();

            return requiredCharacterOccurrence >= CharacterMinOccurrence && requiredCharacterOccurrence <= CharacterMaxOccurrence;
        }

        internal bool IsValidPart2()
        {
            if (string.IsNullOrEmpty(Password)) throw new NullReferenceException(nameof(Password));

            var minIndex = CharacterMinOccurrence - 1;
            var maxIndex = CharacterMaxOccurrence - 1;

            var requiredIndices = new List<char>
            {
                Password[minIndex],
                Password[maxIndex]
            };

            return requiredIndices.Where(p => p == CharacterRequired).Count() == 1;
        }
    }
}
