#region

using System;
using System.Linq;
using ESAPIX.Extensions;
using ESAPIX.Facade.API;
using Newtonsoft.Json;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Constraints.DVH
{
    /// <summary>
    ///     Encapsulates the dose compliment (cold spot) of a structure. Dose compliment at 2% will give the maximum dose
    ///     in the coldest 2 % of a structure.
    /// </summary>
    public abstract class ComplimentDoseAtVolumeConstraint : DoseStructureConstraint
    {
        public double Volume { get; set; }
        public VolumePresentation VolumeType { get; set; }

        /// <summary>
        ///     The function that determines if the constraint fails (greater or less than constraint dose)
        /// </summary>
        [JsonIgnore]
        public virtual Func<DoseValue, ResultType> PassingFunc { get; set; }

        /// <summary>
        ///     Gets the dose compliment at a volume for all structures in this constraint by merging their dvhs
        /// </summary>
        /// <param name="pi">the planning item containing the dose to be queried</param>
        /// <returns>the dose value at the volume of this constraint</returns>
        public DoseValue GetDoseComplimentAtVolume(PlanningItem pi)
        {
            var structures = StructureNames.Select(s => pi.GetStructure(s));
            var doseAtVol = pi.GetDoseComplimentAtVolume(structures, Volume, VolumeType,
                ConstraintDose.GetPresentation());
            return doseAtVol;
        }

        public override ConstraintResult Constrain(PlanningItem pi)
        {
            var msg = string.Empty;
            var passed = GetFailedResultType();

            var structures = StructureNames.Select(s => pi.GetStructure(s));
            var dcAtVolume = pi.GetDoseComplimentAtVolume(structures, Volume, VolumeType,
                ConstraintDose.GetPresentation());
            passed = PassingFunc(dcAtVolume);

            var stringUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "CC" : "%";
            var value = $"{dcAtVolume.GetDose(ConstraintDose.Unit).ToString("F3")} {ConstraintDose.UnitAsString}";
            msg = $"Dose compliment to {Volume} {stringUnit} of {StructureName} is {value}.";
            return new ConstraintResult(this, passed, msg, value);
        }
    }
}