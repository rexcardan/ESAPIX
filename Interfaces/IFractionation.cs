using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
    public interface IFractionation : IApiDataObject
    {
         DateTime? CreationDateTime { get; }

         int? NumberOfFractions { get; }

         DoseValue PrescribedDosePerFraction { get; }

         DoseValue DosePerFractionInPrimaryRefPoint { get; }
    }
}
