#region

using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Constraints.DVH
{
    public class MinDoseAtVolConstraint : DoseAtVolumeConstraint
    {
        public MinDoseAtVolConstraint()
        {
            PassingFunc = doseAtVol =>
            {
                return doseAtVol.GreaterThanOrEqualTo(ConstraintDose) ? ResultType.PASSED : GetFailedResultType();
            };
        }

        public override string ToString()
        {
            //Mayo format
            var vol = Volume.ToString().Replace(",", "");
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"D{vol}{volUnit}[{doseUnit}] >= {dose}";
        }
    }
}