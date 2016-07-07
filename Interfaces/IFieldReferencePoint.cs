using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
    public interface IFieldReferencePoint : IApiDataObject
    {
         IReferencePoint ReferencePoint { get; }

         VVector RefPointLocation { get; }

         DoseValue FieldDose { get; }

         double EffectiveDepth { get; }

         double SSD { get; }

         bool IsPrimaryReferencePoint { get; }

         bool IsFieldDoseNominal { get; }
    }
}
