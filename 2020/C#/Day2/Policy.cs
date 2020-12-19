using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day1
{
    public class Policy
    {
        private static readonly Regex Regex = new (@"(\d+)-(\d+)\s(\w):\s(\w+)", RegexOptions.Compiled);

        public Policy(int min, int max, char character, string password)
        {
            Min = min;
            Max = max;
            Character = character;
            Password = password;
        }

        private int Min { get; }
        private int Max { get; }
        private char Character { get; }
        private string Password { get; }

        public bool Validate(ValidationMode mode)
        {
            // Everyone: But Jelle, switch statements are bad!!
            // Me: Haha switch go brrrrrr
            switch (mode)
            {
                case ValidationMode.PartOne:
                    var occurrences = Password.Count(c => c == Character);
                    return occurrences >= Min && occurrences <= Max;
                
                case ValidationMode.PartTwo:
                    var (first, second) = (Password[Min - 1], Password[Max - 1]);
                    return first == Character ^ second == Character;
                
                default:
                    throw new InvalidOperationException("There's only two parts per day, good sir.");
            }
        }
        
        public static Policy Parse(string line)
        {
            var groups = Regex.Match(line).Groups;
            return new Policy(
                Convert.ToInt32(groups[1].Value),
                Convert.ToInt32(groups[2].Value),
                Convert.ToChar(groups[3].Value),
                groups[4].Value
            );
        }
    }

    public enum ValidationMode
    {
        PartOne,
        PartTwo
    }
}