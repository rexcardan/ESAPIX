#region

using System.Collections.Generic;

#endregion

namespace ESAPIX.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Flatten<T>(T[,] array)
        {
            var list = new List<T>();
            foreach (var l in array)
                list.Add(l);
            return list.ToArray();
        }
    }
}