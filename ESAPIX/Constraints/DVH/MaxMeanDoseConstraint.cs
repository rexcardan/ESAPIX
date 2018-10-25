#region

using System.Linq;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Constraints.DVH

{
    /// <summary>
    ///     Encapsulates the requirement of a maximum mean dose to a structure
    /// </summary>
    public class MaxMeanDoseConstraint : DoseStructureConstraint
    {
        public override ConstraintResult Constrain(PlanningItem pi)
        {
            var msg = string.Empty;
            var passed = GetFailedResultType();

            var dvhs = GetStructures(pi)
                .Select(s => pi.GetDVHCumulativeData(s, ConstraintDose.GetPresentation(),
                    VolumePresentation.AbsoluteCm3, 0.01));
            var meanValue = dvhs.Average(d => d.MeanDose.GetDose(ConstraintDose.Unit));
            var mean = new DoseValue(meanValue, ConstraintDose.Unit);

            var value = $"{mean.GetDose(ConstraintDose.Unit).ToString("F3")} {ConstraintDose.UnitAsString}";
            passed = mean.LessThanOrEqualTo(ConstraintDose) ? ResultType.PASSED : GetFailedResultType();
            msg = $"Mean dose to {string.Join("/", StructureNames)} is {value}.";

            return new ConstraintResult(this, passed, msg, value);
        }

        public override string ToString()
        {
            //Mayo format
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"Mean[{doseUnit}] <= {dose}";
        }
    }
}