namespace Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Returns a random element of the specified array.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T Random<T>(this T[] array)
        {
            if (array.Length == 0) { return default(T); }
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        public static bool Contains<T>(this T[] array, T element)
        {
            if (array.Length == 0) { return false; }
            foreach(T obj in array)
            {
                if(obj.Equals(element)) { return true; }
            }
            return false;
        }

    }
}