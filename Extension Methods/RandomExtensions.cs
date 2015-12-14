using System;

namespace Extensions
{
    public static class RandomExtensions
    {

        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        public static float NextFloat(this Random random)
        {
            return (float)random.NextDouble();
        }

        public static float NextFloat(this Random random, float from, float to)
        {
            return from + (random.NextFloat() * ((to - from) + 1));
        }

        public static double NextDouble(this Random random, double from, double to)
        {
            return from + (random.NextFloat() * ((to - from) + 1));

        }

        /// <summary>
        /// Returns a random int within a range with certain numbers omited.
        /// </summary>
        public static int NextExclusive(this Random random, int from, int to, int[] exclusive)
        {
            int newRandom = random.Next(from, to);

            while (exclusive.Contains(newRandom))
            {
                newRandom = random.Next(from, to);
            }

            return newRandom;
        }

        /// <summary>
        /// Returns a random int with certain numbers omited.
        /// </summary>
        public static int NextExclusive(this Random random, int[] exclusive)
        {
            int newRandom = random.Next();

            while (exclusive.Contains(newRandom))
            {
                newRandom = random.Next();
            }

            return newRandom;
        }

    }


}