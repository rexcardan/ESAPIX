using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.DVH.Constraints
{
    public class MinComplimentVolumeAtDose : ComplimentVolumeAtDoseConstraint
    {
        public MinComplimentVolumeAtDose()
        {
            PassingFunc = new Func<double, ResultType>((vol => { return vol >= Volume ? ResultType.PASSED : GetFailedResultType(); }));
        }

        public override string ToString()
        {
            //Mayo format
            var vol = Volume.ToString().Replace(",", "");
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"CV{dose}{doseUnit}[{volUnit}] >= {vol}";
        }
    }
}
