using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Types
{
    public struct VRect<T> where T : struct
    {
        public T X1 { get; set; }

        public T Y1 { get; set; }

        public T X2 { get; set; }

        public T Y2 { get; set; }

        public VRect(T x1, T y1, T x2, T y2)
        {
            this = new VRect<T>();
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        public override string ToString()
        {
            return "VRect(X1=" + (object)this.X1 + ",Y1=" + (string)(object)this.Y1 + ",X2=" + (string)(object)this.X2 + ",Y2=" + (string)(object)this.Y2 + ")";
        }
    }
}
