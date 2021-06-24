#region

using System;
using System.Numerics;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Extensions
{
    public static class VVectorExtensions
    {
        public static double DistanceTo(this VVector vv, VVector v2)
        {
            return Math.Sqrt((vv.x - v2.x) * (vv.x - v2.x) + (vv.y - v2.y) * (vv.y - v2.y) +
                             (vv.z - v2.z) * (vv.z - v2.z));
        }

        /// <summary>
        /// Rounds each element in the vector (typically means to nearnest mm)
        /// </summary>
        /// <param name="v">the vector to round</param>
        /// <returns>the rounded vector</returns>
        public static VVector Round(this VVector v)
        {
            return new VVector(Math.Round(v.x), Math.Round(v.y), Math.Round(v.z));
        }

        /// <summary>
        /// Converts to a vector from System.Numerics for math operations
        /// </summary>
        /// <param name="v">the vector to convert</param>
        /// <returns>a vector from System.Numerics</returns>
        public static Vector3 ToVector3(this VVector v)
        {
            return new Vector3((float)v.x, (float)v.y, (float)v.z);
        }
    }
}