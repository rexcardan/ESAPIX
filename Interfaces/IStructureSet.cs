using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface IStructureSet : IApiDataObject
    {
        string UID { get; }

        IImage Image { get; }

        IEnumerable<IStructure> Structures { get; }
    }
}
