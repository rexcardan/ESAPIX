using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface ISlot : IApiDataObject
    {
        int Number { get; }
    }
}
