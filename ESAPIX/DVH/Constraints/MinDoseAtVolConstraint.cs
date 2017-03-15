using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Interfaces;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.Types;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.DVH.Constraints
{
    public class MinDoseAtVolConstraint : DoseAtVolumeConstraint
    {
        public MinDoseAtVolConstraint()
        {
            PassingFunc = new Func<DoseValue, ResultType>((doseAtVol => { return doseAtVol.GreaterThanOrEqualTo(ConstraintDose)? ResultType.PASSED : GetFailedResultType(); }));
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
