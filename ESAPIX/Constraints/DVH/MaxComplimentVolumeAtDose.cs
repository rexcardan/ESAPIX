#region

using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Constraints.DVH
{
    public class MaxComplementVolumeAtDose : ComplementVolumeAtDoseConstraint
    {
        public MaxComplementVolumeAtDose()
        {
            PassingFunc = vol => { return vol <= Volume ? ResultType.PASSED : GetFailedResultType(); };
        }

        public override string ToString()
        {
            //Mayo format
            var vol = Volume.ToString().Replace(",", "");
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"CV{dose}{doseUnit}[{volUnit}] <= {vol}";
        }
    }
}