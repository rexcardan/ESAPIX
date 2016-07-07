using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Extensions
{
    public static class ListExtensions
    {
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }
}
