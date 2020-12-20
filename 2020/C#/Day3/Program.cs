using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        private const int HorizontalStep = 3;
        private const int VerticalStep = 1;

        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            Console.WriteLine("Part One: {0} trees encountered.", Ski(input, (3, 1)));

            var p2 = Ski(input, (1, 1), (3, 1), (5, 1), (7, 1), (1, 2));
            Console.WriteLine(
                "Part Two: {0} trees encountered.",
                p2
            );
        }

        private static long Ski(string[] plane, params (int x, int y)[] slopes)
        {
            var results = new List<long>();
            foreach (var slope in slopes)
            {
                int horizontal = 0;
                int width = plane[0].Length;
                int trees = 0;
                for (int vertical = 0; vertical < plane.Length; vertical += slope.y)
                {
                    if (plane[vertical][horizontal % width] == '#') trees++;

                    horizontal += slope.x;
                }

                results.Add(trees);
            }

            return results.Aggregate(1L, (a, b) => a * b);
        }
    }
}