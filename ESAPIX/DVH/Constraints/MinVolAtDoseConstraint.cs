using System;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.DVH.Constraints
{
    public class MinVolAtDoseConstraint : VolumeAtDoseConstraint
    {
        public MinVolAtDoseConstraint()
        {
            PassingFunc = new Func<double, ResultType>((vol => { return vol >= Volume ? ResultType.PASSED : GetFailedResultType(); }));
        }

        public override string ToString()
        {
            //Mayo format
            var vol = Volume.ToString();
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"V{dose}{doseUnit}[{volUnit}] >= {vol}";
        }
    }
}
