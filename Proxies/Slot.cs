using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Interfaces;

namespace ESAPIX.Proxies
{
    public class Slot : ApiDataObject, ISlot
    {
        public int Number { get; set; }
    }
}
