using ESAPIX.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.DVH.Constraints
{
    public class MinComplimentDoseAtVolumeConstraint : ComplimentDoseAtVolumeConstraint
    {
        public MinComplimentDoseAtVolumeConstraint()
        {
            PassingFunc = new Func<DoseValue, ResultType>((doseAtVol => { return doseAtVol.GreaterThanOrEqualTo(ConstraintDose) ? ResultType.PASSED : GetFailedResultType(); }));
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
