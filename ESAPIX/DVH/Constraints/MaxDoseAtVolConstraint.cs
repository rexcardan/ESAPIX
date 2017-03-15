using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Interfaces;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.DVH.Constraints
{
    public class MaxDoseAtVolConstraint : DoseAtVolumeConstraint
    {
        public MaxDoseAtVolConstraint()
        {
            PassingFunc = new Func<DoseValue, ResultType>((doseAtVol => { return doseAtVol.LessThanOrEqualTo(ConstraintDose)? ResultType.PASSED : GetFailedResultType(); }));
        }

        public override string ToString()
        {
            //Mayo format
            var vol = Volume.ToString().Replace(",", "");
            var volUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "cc" : "%";
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"D{vol}{volUnit}[{doseUnit}] <= {dose}";
        }

        public override string Name { get { return ToString(); } }
    }
}
