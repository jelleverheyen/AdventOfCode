using System;

namespace Day4
{
    public static class Extensions
    {
        public static void Then(this bool condition, Action action)
        {
            if (condition) action();
        }
    }
}