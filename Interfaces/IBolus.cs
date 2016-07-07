using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface IBolus
    {
         string Id { get; }

         string Name { get; }

         double MaterialCTValue { get; }
    }
}
