using System;
using System.Collections.Generic;
using System.Text;

namespace BeehaviorTree.Utility
{
    internal static class RandomGenerator
    {
        private static Random random = new Random();

        public static int GetRandomInt()
        {
            return GetRandomInt(0, int.MaxValue);
        }

        public static int GetRandomInt(int max)
        {
            return GetRandomInt(0, max);
        }

        public static int GetRandomInt(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
