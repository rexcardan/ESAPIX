using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.Extensions
{
    public static class VVectorExtensions
    {
        public static double DistanceTo(this VVector vv, VVector v2)
        {
            return Math.Sqrt((vv.x - v2.x) * (vv.x - v2.x) + (vv.y - v2.y) * (vv.y - v2.y) + (vv.z - v2.z) * (vv.z - v2.z));
        }
    }
}
