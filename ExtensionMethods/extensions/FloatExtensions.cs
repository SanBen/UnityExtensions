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
	
	/// <summary>
	/// Creates an equal division array from value and count.
	/// For example, a value of 1 and a count of 3 creates [0,0.33,0.66,1].
	/// This is useful e.g. for GUI partitioning.
	/// </summary>
	public static float[] DivideEquallyBy (this float value, int count) {
		if (count < 1) {
			Debug.LogError ("Count cannot be smaller than 1! (Count: " + count + ")");
			return null;
		}
		float[] results = new float[count + 1];
		float step = value / (float)count;
		float current = 0f;
		for (int i=0; i<results.Length; i++) {
			results [i] = current;
			current += step;
		}
		return results;
	}


	///// <summary>
	///// Creates an equal division array from value, count and deltaPerElement.
	///// For example, a value of 1, a count of 4 and a delta of 0.1 creates [0,0.1], [0.3,0.4], [0.6,0.7], [0.9,1].
	///// This is useful e.g. for GUI partitioning.
	///// </summary>
	//public static floatRange[] DivideEquallyBy (this float value, int count, float deltaPerElement) {
	//	if (deltaPerElement > value) {
	//		Debug.LogError ("DeltaPerElement cannot be greater than float Value! (Delta: " + deltaPerElement + ", Value: " + value + ")");
	//		return null;
	//	}
	//	if (deltaPerElement < 0f) {
	//		Debug.LogError ("DeltaPerElement cannot be smaller than 0! (Delta: " + deltaPerElement + ")");
	//		return null;
	//	}
	//	if (count < 1) {
	//		Debug.LogError ("Count cannot be smaller than 1! (Count: " + count + ")");
	//		return null;
	//	}
	//	floatRange[] results = new floatRange[count];
	//	float step = (value - deltaPerElement) / ((float)count - 1f);
	//	float current = 0f;
	//	for (int i=0; i<results.Length; i++) {
	//		float min = current;
	//		float max = current + deltaPerElement;
	//		results [i] = new floatRange (min, max);
	//		current += step;
	//	}
	//	return results;
	//}

	public static float MoveTowards (this float value, float target, float maxDelta) {
		float delta = value - target;
		if (Mathf.Abs (delta) < maxDelta) {
			return target;
		} else {
			if (delta < 0f) {
				return value + maxDelta;
			} else {
				return value - maxDelta;
			}
		}
	}
  }
}