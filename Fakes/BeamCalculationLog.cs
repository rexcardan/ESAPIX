using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Interfaces;

namespace ESAPIX.Fakes
{
    public class BeamCalculationLog :  IBeamCalculationLog
    {
        public string Category { get; set; }

        public IEnumerable<string> MessageLines { get; set; }
    }
}
