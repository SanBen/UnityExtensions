using UnityEngine;

namespace Extensions
{
  public static class IntExtensions
  {
    /// <summary>
    /// Returns a round Integer except this one.
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static int GetRandomWithException(this int exception, int from, int to)
    {
      int newRandom = Random.Range(from, to);

      while (exception == newRandom) {
        newRandom = Random.Range(from, to);
      }

      return newRandom;
    }
  }
}