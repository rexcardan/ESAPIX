using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Enums;

namespace ESAPIX.Types
{
    public struct MetersetValue
    {
        public double Value { get; private set; }

        public DosimeterUnit Unit { get; private set; }

        public MetersetValue(double value, DosimeterUnit unit)
        {
            this = new MetersetValue();
            this.Value = value;
            this.Unit = unit;
        }
    }
}
