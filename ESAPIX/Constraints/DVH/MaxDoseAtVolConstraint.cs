#region

using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Constraints.DVH
{
    public class MaxDoseAtVolConstraint : DoseAtVolumeConstraint
    {
        public MaxDoseAtVolConstraint()
        {
            PassingFunc = doseAtVol =>
            {
                return doseAtVol.LessThanOrEqualTo(ConstraintDose) ? ResultType.PASSED : GetFailedResultType();
            };
        }

        public override string Name => ToString();

        public override string ToString()
        {
            //Mayo format
            var vol = Volume.ToString().Replace(",", "");
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"D{vol}{volUnit}[{doseUnit}] <= {dose}";
        }
    }
}