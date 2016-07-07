using System;
using ESAPIX.Interfaces;
using ESAPIX.Types;


namespace ESAPIX.Fakes
{
    public class Fractionation : ApiDataObject, IFractionation
    {
        public DateTime? CreationDateTime { get; set; }

        public int? NumberOfFractions { get; set; }

        public DoseValue PrescribedDosePerFraction { get; set; }

        public DoseValue DosePerFractionInPrimaryRefPoint { get; set; }
    }
}