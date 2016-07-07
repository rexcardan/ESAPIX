using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Types
{
    public struct VVector
    {
        public double this[int i]
        {
            get
            {
                if (i == 0)
                    return this.x;
                if (i == 1)
                    return this.y;
                if (i == 2)
                    return this.z;
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (i == 0)
                    this.x = value;
                else if (i == 1)
                {
                    this.y = value;
                }
                else
                {
                    if (i != 2)
                        throw new IndexOutOfRangeException();
                    this.z = value;
                }
            }
        }

        public double LengthSquared
        {
            get
            {
                return this.x * this.x + this.y * this.y + this.z * this.z;
            }
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(this.LengthSquared);
            }
        }

        public double x
        {
            get;
            set;
        }

        public double y
        {
            get;
            set;
        }

        public double z
        {
            get;
            set;
        }

        public VVector(double xi, double yi, double zi)
        {
            this = new VVector();
            this.x = xi;
            this.y = yi;
            this.z = zi;
        }

        public static VVector operator -(VVector left, VVector right)
        {
            return new VVector(left.x - right.x, left.y - right.y, left.z - right.z);
        }

        public static VVector operator +(VVector left, VVector right)
        {
            return new VVector(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        public static VVector operator *(VVector val, double mul)
        {
            return new VVector(val.x * mul, val.y * mul, val.z * mul);
        }

        public static VVector operator *(double mul, VVector val)
        {
            return new VVector(val.x * mul, val.y * mul, val.z * mul);
        }

        public static VVector operator /(VVector val, double div)
        {
            return new VVector(val.x / div, val.y / div, val.z / div);
        }

        public static double Distance(VVector left, VVector right)
        {
            return (right - left).Length;
        }

        public void ScaleToUnitLength()
        {
            double length = this.Length;
            if (length > 0.0)
            {
                this.x = this.x / length;
                this.y = this.y / length;
                this.z = this.z / length;
            }
            else
            {
                this.x = 1.0;
                this.y = 0.0;
                this.z = 0.0;
            }
        }

        public double ScalarProduct(VVector left)
        {
            return this.x * left.x + this.y * left.y + this.z * left.z;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", x, y, z);
        }
    }
}
