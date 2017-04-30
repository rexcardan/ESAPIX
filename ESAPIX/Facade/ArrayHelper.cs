#region

using ESAPIX.Facade.Types;

#endregion

namespace ESAPIX.Facade
{
    public class ArrayHelper
    {
        public static VVector[] GenerateVVectorArray(dynamic obj)
        {
            var array = new VVector[obj.Length];
            for (var i = 0; i < array.Length; i++)
                array[0] = new VVector(obj[0]);
            return array;
        }

        internal static DVHPoint[] GenerateDVHPointArray(dynamic obj)
        {
            var array = new DVHPoint[obj.Length];
            for (var i = 0; i < array.Length; i++)
                array[0] = new DVHPoint(obj[0]);
            return array;
        }
    }
}