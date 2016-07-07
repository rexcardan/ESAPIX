using ESAPIX.Interfaces;
using ESAPIX.Types;

namespace ESAPIX.Proxies
{
    public class DVHData : IDVHData
    {
        public double Coverage { get; set; }

        public double Volume { get; set; }

        public DoseValue MinDose { get; set; }

        public DoseValue MaxDose { get; set; }

        public DoseValue MeanDose { get; set; }

        public DoseValue MedianDose { get; set; }

        public double StdDev { get; set; }

        public double SamplingCoverage { get; set; }

        public DVHPoint[] CurveData { get; set; }
    }
}