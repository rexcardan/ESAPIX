using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface IControlPointCollection : IEnumerable<IControlPoint>, IEnumerable
    {
        IControlPoint this[int index] { get; }

        int Count {get;}
    }
}
