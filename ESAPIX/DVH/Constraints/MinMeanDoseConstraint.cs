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
    /// <summary>
    /// Encapsulates the requirement of a minimum mean dose to a structure
    /// </summary>
    public class MinMeanDoseConstraint : DoseStructureConstraint
    {
        public override ConstraintResult Constrain(PlanningItem pi)
        {
            var msg = string.Empty;
            ResultType passed = GetFailedResultType();

            var dvhs = GetStructures(pi).Select(s => pi.GetDVHCumulativeData(s, ConstraintDose.GetPresentation(), VolumePresentation.AbsoluteCm3, 0.01));
            var meanValue = dvhs.Average(d => d.MeanDose.GetDose(ConstraintDose.Unit));
            var mean = new DoseValue(meanValue, ConstraintDose.Unit);

            var value = $"{ mean.GetDose(ConstraintDose.Unit).ToString() } { ConstraintDose.UnitAsString}";
            passed = mean.GreaterThanOrEqualTo(ConstraintDose)? ResultType.PASSED : GetFailedResultType();
            msg = $"Mean dose to {string.Join("/", StructureNames)} is {value}.";

            return new ConstraintResult(this, passed, msg,value);
        }

        public override string ToString()
        {
            //Mayo format
            var doseUnit = ConstraintDose.UnitAsString;
            var dose = ConstraintDose.ValueAsString;
            return $"Mean[{doseUnit}] >= {dose}";
        }
    }
}
