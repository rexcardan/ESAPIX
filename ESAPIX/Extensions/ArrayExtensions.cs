using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Flatten<T>(T[,] array) 
        {
            List<T> list = new List<T>();
            foreach (var l in array)
            {
                list.Add(l);
            }
            return list.ToArray();
        }
    }
}
