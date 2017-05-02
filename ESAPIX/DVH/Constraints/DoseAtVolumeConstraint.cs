#region

using System;
using System.Linq;
using ESAPIX.Extensions;
using ESAPIX.Facade.API;
using Newtonsoft.Json;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.DVH.Constraints
{
    public abstract class DoseAtVolumeConstraint : DoseStructureConstraint
    {
        public double Volume { get; set; }
        public VolumePresentation VolumeType { get; set; }

        /// <summary>
        ///     The function that determines if the constraint fails (greater or less than constraint dose)
        /// </summary>
        [JsonIgnore]
        public virtual Func<DoseValue, ResultType> PassingFunc { get; set; }

        /// <summary>
        ///     Gets the dose at a volume for all structures in this constraint by merging their dvhs
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
            var passed = GetFailedResultType();

            var structures = StructureNames.Select(s => pi.GetStructure(s));
            var doseAtVol = pi.GetDoseAtVolume(structures, Volume, VolumeType, ConstraintDose.GetPresentation());
            passed = PassingFunc(doseAtVol);

            var stringUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "CC" : "%";
            var value = $"{doseAtVol.GetDose(ConstraintDose.Unit).ToString("F3")} {ConstraintDose.UnitAsString}";
            msg = $"Dose to {Volume} {stringUnit} of {StructureName} is {value}.";
            return new ConstraintResult(this, passed, msg, value);
        }
    }
}