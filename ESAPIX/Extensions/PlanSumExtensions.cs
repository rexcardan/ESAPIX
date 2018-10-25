#region

using VMS.TPS.Common.Model.API;
using System.Linq;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Extensions
{
    public static class PlanSumExtensions
    {
        /// <summary>
        ///     This method exists to guess the prescription of a plan sum by summing all plan setup prescribed doses and
        ///     generating a
        ///     relative dvh curve. Can't technically do relative dose with plan sum...but let's try to do it anyway
        /// </summary>
        /// <param name="ps">the plan sum where relative dose dvh curve is desired</param>
        /// <param name="s">the structure to sample</param>
        /// <param name="vPres">the volume presentation to create the curve</param>
        /// <param name="binWidth">the bin width to create the curve</param>
        /// <returns></returns>
        public static DVHPoint[] GetRelativeDVHCumulativeData(this PlanSum ps, Structure s, VolumePresentation vPres,
            double binWidth)
        {
            var guessedRxGy = ps.TotalPrescribedDoseGy();
            var psDVH = ps.GetDVHCumulativeData(s, DoseValuePresentation.Absolute, vPres, binWidth);
            var scalingPoint = new DoseValue(guessedRxGy, DoseValue.DoseUnit.Gy);
            var dvhCurve = psDVH.CurveData.ConvertToRelativeDose(scalingPoint);
            return dvhCurve;
        }

        public static Course Course(this PlanSum ps)
        {
#if VMS110
            return ps.PlanSetups.FirstOrDefault()?.Course;
#else
            return ps.Course;
#endif
        }
    }
}