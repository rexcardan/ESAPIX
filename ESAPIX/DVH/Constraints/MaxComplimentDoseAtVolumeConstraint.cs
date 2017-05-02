#region

using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.DVH.Constraints
{
    public class MaxComplimentDoseAtVolumeConstraint : ComplimentDoseAtVolumeConstraint
    {
        public MaxComplimentDoseAtVolumeConstraint()
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
            var vol = Volume.ToString();
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"DC{vol}{volUnit}[{doseUnit}] <= {dose}";
        }
    }
}