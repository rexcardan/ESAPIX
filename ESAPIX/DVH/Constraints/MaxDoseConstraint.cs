using System.Linq;
using ESAPIX.Extensions;
using ESAPIX.Facade.API;
using ESAPIX.Facade.Types;

namespace ESAPIX.DVH.Constraints
{
    public class MaxDoseConstraint : DoseStructureConstraint
    {
        public override ConstraintResult Constrain(PlanningItem pi)
        {
            var msg = string.Empty;
            var passed = GetFailedResultType();

            var dvhs = GetStructures(pi)
                .Select(s => pi.GetDVHCumulativeData(s, ConstraintDose.GetPresentation(),
                    VolumePresentation.AbsoluteCm3, 0.01));
            var max = dvhs.Max(d => d.MaxDose);

            var value = $"{max.GetDose(ConstraintDose.Unit).ToString("F3")} {ConstraintDose.UnitAsString}";
            passed = max.LessThanOrEqualTo(ConstraintDose) ? ResultType.PASSED : GetFailedResultType();
            msg = $"Maximum dose to {string.Join("/", StructureNames)} is {value}.";

            return new ConstraintResult(this, passed, msg, value);
        }

        public override string ToString()
        {
            //Mayo format
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"Max[{doseUnit}] <= {dose}";
        }
    }
}