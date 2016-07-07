using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Interfaces;

namespace ESAPIX.Fakes
{
    public class Bolus :  IBolus
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double MaterialCTValue { get; set; }
    }
}
