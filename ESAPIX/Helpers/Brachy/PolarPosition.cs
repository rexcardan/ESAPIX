using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Brachy
{
    public struct PolarPosition
    {
        public PolarPosition(double distance_mm, double angle_rad)
        {
            Distance_mm = distance_mm;
            Angle_rad = angle_rad;
        }

        public double Distance_mm { get; set; }
        public double Angle_rad { get; set; }
    }
}
