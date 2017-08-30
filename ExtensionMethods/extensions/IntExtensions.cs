using System;

namespace Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns an int with this one excluded.
        /// </summary>
        [Obsolete("GetRandomWithException is deprecated please use NextExclusive with a System.Random object")]
        public static int GetRandomWithException(this int exception, int from, int to)
        {
            int newRandom = UnityEngine.Random.Range(from, to);

            while (exception == newRandom)
            {
                newRandom = UnityEngine.Random.Range(from, to);
            }

            return newRandom;
        }
    }
}