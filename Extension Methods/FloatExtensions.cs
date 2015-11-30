using UnityEngine;

namespace Extensions
{
  public static class FloatExtensions
  {
    public static bool Approximately(this float inst, float compareTo, float tolerance = 0.00001f)
    {
      return (Mathf.Abs(inst - compareTo) < tolerance);
    }

    public static float RoundToDigits(this float number, int digits)
    {
      float multipler = Mathf.Pow(10, (float)digits);
      //float roundedNumber = ((int)(number * multipler)) / multipler;
      //Debug.Log ("number: " + number + " multipler: " + multipler + " roundedNumber: " + roundedNumber);
      //return roundedNumber;
      return ((int)(number * multipler)) / multipler;
    }
  }
}