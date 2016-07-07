using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Interfaces;

namespace ESAPIX.Proxies
{
    public class BeamCalculationLog : VMSProxy, IBeamCalculationLog
    {
        public string Category { get; set; }

        public IEnumerable<string> MessageLines { get; set; }
    }
}
