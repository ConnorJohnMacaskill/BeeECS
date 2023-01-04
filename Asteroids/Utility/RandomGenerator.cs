using System;

namespace Asteroids.Utility
{
    static class RandomGenerator
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

        public static float GetRandomFloat()
        {
            return (float)GetRandomDouble();
        }

        public static float GetRandomFloat(float max)
        {
            return (float)GetRandomDouble(max);
        }

        public static float GetRandomFloat(float min, float max)
        {
            return (float)GetRandomDouble(min, max);
        }

        public static double GetRandomDouble()
        {
            return GetRandomDouble(0, double.MaxValue);
        }

        public static double GetRandomDouble(double max)
        {
            return GetRandomDouble(0, max);
        }

        public static double GetRandomDouble(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}
