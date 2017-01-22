using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.DVH.Constraints
{
    public class MaxMeanDoseConstraint : DoseStructureConstraint
    {
        public override ConstraintResult Constrain(PlanningItem pi)
        {
            var msg = string.Empty;
            bool? passed = false;

            var dvhs = GetStructures(pi).Select(s => pi.GetDVHCumulativeData(s, ConstraintDose.GetPresentation(), VolumePresentation.AbsoluteCm3, 0.01));
            var meanValue = dvhs.Average(d => d.MeanDose.GetDose(ConstraintDose.Unit));
            var mean = new DoseValue(meanValue, ConstraintDose.Unit);

            var value = $"{ mean.GetDose(ConstraintDose.Unit).ToString("F2") } { ConstraintDose.UnitAsString}";
            passed = mean.LessThanOrEqualTo(ConstraintDose);
            msg = $"Mean dose to {string.Join("/", StructureNames)} is {value}.";

            return new ConstraintResult(this, passed, msg,value);
        }

        public override string ToString()
        {
            //Mayo format
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"Mean[{doseUnit}]<={dose}";
        }
    }
}
