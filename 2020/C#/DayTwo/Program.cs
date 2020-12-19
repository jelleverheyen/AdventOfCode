using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        private static void Main(string[] args)
        {
            var policies = File
                .ReadAllLines("input.txt")
                .Select(Policy.Parse)
                .ToList();
            
            var partOne = policies
                .Select(x => x.Validate(ValidationMode.PartOne))
                .Count(x => x);

            var partTwo = policies
                .Select(x => x.Validate(ValidationMode.PartTwo))
                .Count(x => x);

            Console.WriteLine("Part One: {0} valid passwords found.", partOne);
            Console.WriteLine("Part Two: {0} valid passwords found.", partTwo);
        }
    }
}