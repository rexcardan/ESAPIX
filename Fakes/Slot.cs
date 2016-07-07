using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Interfaces;

namespace ESAPIX.Fakes
{
    public class Slot : ApiDataObject, ISlot
    {
        public int Number { get; set; }
    }
}
