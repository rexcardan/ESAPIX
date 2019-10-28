#region

using System;
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
    }
}