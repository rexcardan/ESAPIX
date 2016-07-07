using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface IBeamCalculationLog
    {
        string Category { get; }

        IEnumerable<string> MessageLines { get; }
    }
}
