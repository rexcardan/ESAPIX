using ESAPIX.Facade.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Facade
{
    public class ArrayHelper
    {
        public static VVector[] GenerateVVectorArray(dynamic obj)
        {
            var array = new VVector[obj.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[0] = new VVector(obj[0]);
            }
            return array;
        }

        internal static DVHPoint[] GenerateDVHPointArray(dynamic obj)
        {
            var array = new DVHPoint[obj.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[0] = new DVHPoint(obj[0]);
            }
            return array;
        }
    }
}
