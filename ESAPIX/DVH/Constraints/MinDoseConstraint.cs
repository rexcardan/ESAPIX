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
    public class MinDoseConstraint : DoseStructureConstraint
    {
        public override ConstraintResult Constrain(PlanningItem pi)
        {
            var msg = string.Empty;
            bool? passed = false;

            var dvhs = GetStructures(pi).Select(s => pi.GetDVHCumulativeData(s, ConstraintDose.GetPresentation(), VolumePresentation.AbsoluteCm3, 0.01));
            var min = dvhs.Min(d => d.MinDose);

            var value = $"{ min.GetDose(ConstraintDose.Unit).ToString("F2") } { ConstraintDose.UnitAsString}";
            passed = min.GreaterThanOrEqualTo(ConstraintDose);
            msg = $"Minimum dose to {string.Join("/", StructureNames)} is {value}.";

            return new ConstraintResult(this, passed, msg,value);
        }

        public override string ToString()
        {
            //Mayo format
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"Min[{doseUnit}]>={dose}";
        }
    }
}
