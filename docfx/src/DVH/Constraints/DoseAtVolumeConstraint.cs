using ESAPIX.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.DVH.Constraints
{
    public class DoseAtVolumeConstraint : DoseStructureConstraint
    {
        public double Volume { get; set; }
        public VolumePresentation VolumeType { get; set; }

        /// <summary>
        /// The function that determines if the constraint fails (greater or less than constraint dose)
        /// </summary>
        [JsonIgnore]
        public virtual Func<DoseValue, bool> PassingFunc { get; set; }

        /// <summary>
        /// Gets the dose at a volume for all structures in this constraint by merging their dvhs
        /// </summary>
        /// <param name="pi">the planning item containing the dose to be queried</param>
        /// <returns>the dose value at the volume of this constraint</returns>
        public DoseValue GetDoseAtVolume(PlanningItem pi)
        {
            var structures = StructureNames.Select(s => pi.GetStructure(s));
            var doseAtVol = pi.GetDoseAtVolume(structures, Volume, VolumeType, ConstraintDose.GetPresentation());
            return doseAtVol;
        }

        public override ConstraintResult Constrain(PlanningItem pi)
        {
            var msg = string.Empty;
            bool? passed = false;

            var structures = StructureNames.Select(s => pi.GetStructure(s));
            var doseAtVol = pi.GetDoseAtVolume(structures, Volume, VolumeType, ConstraintDose.GetPresentation());
            passed = PassingFunc(doseAtVol);

            var stringUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "CC" : "%";
            var value = $"{ doseAtVol.GetDose(ConstraintDose.Unit).ToString("F2") } { ConstraintDose.UnitAsString}";
            msg = $"Dose to {Volume.ToString("F2")} {stringUnit} of {StructureName} is {value}.";
            return new ConstraintResult(this, passed, msg, value);
        }
    }
}
