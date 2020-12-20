using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    public static class Solver
    {
        private static readonly IDictionary<string, string> Regexes = new Dictionary<string, string>()
        {
            {"byr", "19[0-9][0-9]|200[0-2]"},
            {"iyr", "201[0-9]|2020"},
            {"eyr", "202[0-9]|2030"},
            {"hgt", "1[5-8][0-9]cm|19[0-3]cm|59in|6[0-9]in|7[0-6]in"},
            {"hcl", "#[0-9a-f]{6}"},
            {"ecl", "amb|blu|brn|gry|grn|hzl|oth"},
            {"pid", "[0-9]{9}"}
        };

        public static int PartOne(string[] data)
        {
            int valid = 0;
            foreach (var passport in data)
            {
                Regexes.Keys
                    .All(f => passport.Contains(f))
                    .Then(() => valid++);
            }

            return valid;
        }

        public static int PartTwo(string[] data)
        {
            return data.Select(passport =>
                    // Parse passport fields
                    passport.Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                        .Select(fields => fields.Split(':'))
                        .ToDictionary(field => field[0], field => field[1]))
                // Run regexes against all fields, per passport
                .Count(
                    field =>
                        Regexes.All(regex =>
                            field.TryGetValue(regex.Key, out var value) && // Fetch the field value
                            Regex.IsMatch(value, "^(" + regex.Value + ")$") // Validate the field
                        ) // ???
                ); // Profit
        }
    }
}