using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface IWedge : IAddOn
    {
        double WedgeAngle { get; }
        double Direction { get; }
    }
}
