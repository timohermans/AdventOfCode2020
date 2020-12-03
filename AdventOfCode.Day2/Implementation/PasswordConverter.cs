using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Day2.Implementation
{
    public class PasswordConverter
    {
        public IList<PasswordModel> ConvertMultiple(string passwordsString)
        {
            var passwords = passwordsString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();

            return passwords.Select(Convert).ToList();
        }

        public PasswordModel Convert(string input)
        {
            var passwordModelParts = input.Split(' ');
            var minMaxOccurrences = GetMinMaxOccurrencesFrom(passwordModelParts[0]);

            return new PasswordModel
            {
                CharacterMinOccurrence = minMaxOccurrences.Item1,
                CharacterMaxOccurrence = minMaxOccurrences.Item2,
                CharacterRequired = GetCharacterRequiredFrom(passwordModelParts[1]),
                Password = passwordModelParts[2]
            };
        }

        private char GetCharacterRequiredFrom(string characterRequiredSplit)
        {
            return characterRequiredSplit[0];
        }

        private (int, int) GetMinMaxOccurrencesFrom(string minMaxSplit)
        {
            var splits = minMaxSplit.Split('-');
            return (System.Convert.ToInt32(splits[0]), System.Convert.ToInt32(splits[1]));
        }
    }
}
