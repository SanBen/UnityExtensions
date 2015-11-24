using UnityEngine;

namespace Extensions
{
    public static class FloatExtensions
    {
        public static bool Approximately(this float inst, float compareTo, float tolerance = 0.00001f)
        {
            return (Mathf.Abs(inst - compareTo) < tolerance);
        }
    }
}
