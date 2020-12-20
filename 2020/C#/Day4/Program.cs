using System;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt").Split("\n\n");

            var p1 = Solver.PartOne(input);
            var p2 = Solver.PartTwo(input);
            
            Console.WriteLine("Part One: {0} passports found, of which {1} are valid", input.Length, p1);
            Console.WriteLine("Part Two: {0} passports found, of which {1} are valid", input.Length, p2);
        }
    }
}