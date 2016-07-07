using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface ICompensator : IApiDataObject
    {
        ITray Tray { get; }

        ISlot Slot { get; }

        IAddOnMaterial Material { get; }
    }
}
