using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface IMLC : IAddOn
    {
        string SerialNumber { get; }

        string Model { get; }

        double MinDoseDynamicLeafGap { get; }
    }
}
