using UnityEngine;

namespace Extensions
{
    //____________________Vector4____________________//
    public static class VectorExtensions
    {
        public static Vector4 WithX(this Vector4 inst, float x)
        {
            inst.x = x;
            return inst;
        }

        public static Vector4 WithY(this Vector4 inst, float y)
        {
            inst.y = y;
            return inst;
        }

        public static Vector4 WithZ(this Vector4 inst, float z)
        {
            inst.z = z;
            return inst;
        }

        public static Vector4 WithW(this Vector4 inst, float w)
        {
            inst.w = w;
            return inst;
        }

        /// <summary>
        /// Compares vectors with an approximation defined by tolerance
        /// </summary>
        /// <param name="inst"></param>
        /// <param name="toCompare">Vector to compare to</param>
        /// <param name="tolerance">Tolerance for the approximation</param>
        /// <returns>Are the vectors approximately the same defined by tolerance?</returns>
        public static bool Approximately(this Vector4 inst, Vector toCompare, float tolerance = 0.00001f)
        {
            return toCompare.Approximately(inst, tolerance);
        }


        //____________________Vector3____________________//

        public static Vector3 WithX(this Vector3 inst, float x)
        {
            inst.x = x;
            return inst;
        }

        public static Vector3 WithY(this Vector3 inst, float y)
        {
            inst.y = y;
            return inst;
        }

        public static Vector3 WithZ(this Vector3 inst, float z)
        {
            inst.z = z;
            return inst;
        }


        /// <summary>
        /// Compares vectors with an approximation defined by tolerance
        /// </summary>
        /// <param name="inst"></param>
        /// <param name="toCompare">Vector to compare to</param>
        /// <param name="tolerance">Tolerance for the approximation</param>
        /// <returns>Are the vectors approximately the same defined by tolerance?</returns>
        public static bool Approximately(this Vector3 inst, Vector toCompare, float tolerance = 0.00001f)
        {
            return toCompare.Approximately(inst, tolerance);
        }




        //____________________Vector2____________________//
        public static Vector2 WithX(this Vector2 inst, float x)
        {
            inst.x = x;
            return inst;
        }

        public static Vector2 WithY(this Vector2 inst, float y)
        {
            inst.y = y;
            return inst;
        }

        /// <summary>
        /// Compares vectors with an approximation defined by tolerance
        /// </summary>
        /// <param name="inst"></param>
        /// <param name="toCompare">Vector to compare to</param>
        /// <param name="tolerance">Tolerance for the approximation</param>
        /// <returns>Are the vectors approximately the same defined by tolerance?</returns>
        public static bool Approximately(this Vector2 inst, Vector toCompare, float tolerance = 0.00001f)
        {
            return toCompare.Approximately(inst, tolerance);
        }




        //____________________Generic____________________//

        public static bool Approximately(this Vector inst, Vector toCompare, float tolerance = 0.00001f)
        {
            return inst.x.Approximately(toCompare.x, tolerance) &&
                    inst.y.Approximately(toCompare.y, tolerance) &&
                    inst.z.Approximately(toCompare.z, tolerance) &&
                    inst.w.Approximately(toCompare.w, tolerance);
        }

        public class Vector
        {
            public float x;
            public float y;
            public float z;
            public float w;

            public Vector(float x, float y, float z = 0, float w = 0)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                this.w = w;
            }


            static public implicit operator Vector(Vector2 value)
            {
                return new Vector(value.x, value.y);
            }

            static public implicit operator Vector(Vector3 value)
            {
                return new Vector(value.x, value.y, value.z);
            }

            static public implicit operator Vector(Vector4 value)
            {
                return new Vector(value.x, value.y, value.z, value.w);
            }

        }
    }
}
