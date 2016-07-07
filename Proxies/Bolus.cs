using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Interfaces;

namespace ESAPIX.Proxies
{
    public class Bolus : VMSProxy, IBolus
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double MaterialCTValue { get; set; }
    }
}
