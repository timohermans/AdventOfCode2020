using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day4.Implementation
{
    public class Passport
    {
        public string EyeColor { get; private set; }
        public string PersonalId { get; private set; }
        public int ExpirationYear { get; private set; }
        public string HairColor { get; private set; }
        public int BirthYear { get; private set; }
        public int IssuerYear { get; private set; }
        public int Height { get; private set; }
        public string CountryId { get; private set; }

        public Passport(string input)
        {
            var parts = string.Join(' ', input.Split("\r\n")).Split(' ').ToDictionary(s => s.Split(':')[0], s => s.Split(':')[1]);

            SetEyeColor(parts.GetValueOrDefault("ecl") ?? throw new ArgumentNullException(nameof(EyeColor)));
            SetPid(parts.GetValueOrDefault("pid") ?? throw new ArgumentNullException(nameof(PersonalId)));
            ExpirationYear = GetValidNumberRange("eyr", parts, 2020, 2030);
            SetHairColor(parts.GetValueOrDefault("hcl") ?? throw new ArgumentNullException(nameof(HairColor)));
            BirthYear = GetValidNumberRange("byr", parts, 1920, 2002);
            IssuerYear = GetValidNumberRange("iyr", parts, 2010, 2020);
            SetHeight(parts.GetValueOrDefault("hgt") ?? throw new ArgumentNullException(nameof(Height)));
            CountryId = parts.GetValueOrDefault("cid");
        }

        private void SetPid(string pid)
        {
            var m = Regex.Match(pid, "^[0-9]{9}$");

            if (m.Success)
            {
                PersonalId = pid;
                return;
            }

            throw new ValidationException("pid invalid");
        }

        private void SetEyeColor(string ecl)
        {
            var validColors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            if (validColors.Contains(ecl))
            {
                EyeColor = ecl;
                return;
            }

            throw new ValidationException("Invalid eye color");
        }

        private void SetHairColor(string hclString)
        {
            var pattern = "^#[a-f0-9]{6}$";

            Match m = Regex.Match(hclString, pattern);

            if (m.Success)
            {
                HairColor = hclString;
                return;
            }

            throw new ValidationException("hcl has no valid color");
        }

        private void SetHeight(string heightString)
        {
            int heightNumber = ExtractHeightNumberFrom(heightString);
            var heightMetric = heightString.Substring(heightString.Length - 2, 2);

            if (heightMetric == "cm" && heightNumber >= 150 && heightNumber <= 193)
            {
                Height = heightNumber;
                return;
            }

            if (heightMetric == "in" && heightNumber >= 59 && heightNumber <= 76)
            {
                Height = heightNumber;
                return;
            }

            throw new ValidationException("Height provided is not allowed");
        }

        private static int ExtractHeightNumberFrom(string heightString)
        {
            var supportedMetrics = new List<string> { "cm", "in" };
            var heightNumberString = heightString;
            supportedMetrics.ForEach(m => heightNumberString = heightNumberString.Replace(m, ""));

            int heightNumber;
            if(!int.TryParse(heightNumberString, out heightNumber))
            {
                throw new ValidationException("Height provided is not supported");
            }

            return heightNumber;
        }

        private int GetValidNumberRange(string key, Dictionary<string, string> parts, int min, int max)
        {
            var yearString = parts.GetValueOrDefault(key) ?? throw new ValidationException(nameof(BirthYear));

            int year;

            if (!int.TryParse(yearString, out year))
            {
                throw new ValidationException($"{key} year is not a number");
            }

            if (year >= min && year <= max)
            {
                return year;
            }

            throw new ValidationException($"{key} year provided is not valid. Must be between {min} and {max}");
        }
    }
}
