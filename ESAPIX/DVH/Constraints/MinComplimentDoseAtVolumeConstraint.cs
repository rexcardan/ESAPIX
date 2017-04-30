using ESAPIX.Extensions;
using ESAPIX.Facade.Types;

namespace ESAPIX.DVH.Constraints
{
    public class MinComplimentDoseAtVolumeConstraint : ComplimentDoseAtVolumeConstraint
    {
        public MinComplimentDoseAtVolumeConstraint()
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