#region

using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Constraints.DVH
{
    public class MinComplementDoseAtVolumeConstraint : ComplementDoseAtVolumeConstraint
    {
        public MinComplementDoseAtVolumeConstraint()
        {
            PassingFunc = doseAtVol =>
            {
                return doseAtVol.GreaterThanOrEqualTo(ConstraintDose) ? ResultType.PASSED : GetFailedResultType();
            };
        }

        public override string ToString()
        {
            //Mayo format
            var vol = Volume.ToString();
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"DC{vol}{volUnit}[{doseUnit}] >= {dose}";
        }
    }
}