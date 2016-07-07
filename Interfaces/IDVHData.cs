using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Types;

namespace ESAPIX.Interfaces
{
    public interface IDVHData
    {
        double Coverage { get; }

        double Volume { get; }

        DoseValue MinDose { get; }

        DoseValue MaxDose { get; }

        DoseValue MeanDose { get; }

        DoseValue MedianDose { get; }

        double StdDev { get; }

        double SamplingCoverage { get; }

        DVHPoint[] CurveData { get; }
    }
}
