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
    /// <summary>
    ///     Encapsulates the compliment volume (cold spot) of a structure. Volume compliment is the volume which recieves equal
    ///     or
    ///     LESS than the constraint dose. This is equivalent to STRUCTURE volume - VolumeAtDose(). Represents the amount of
    ///     tissue spared
    /// </summary>
    public abstract class ComplimentVolumeAtDoseConstraint : DoseStructureConstraint
    {
        public double Volume { get; set; }
        public VolumePresentation VolumeType { get; set; }

        /// <summary>
        ///     The function that determines if the constraint fails (greater or less than constraint volume)
        /// </summary>
        [JsonIgnore]
        public virtual Func<double, ResultType> PassingFunc { get; set; }

        /// <summary>
        ///     Gets the dose at a volume for all structures in this constraint by merging their dvhs
        /// </summary>
        /// <param name="pi">the planning item containing the dose to be queried</param>
        /// <returns>the dose value at the volume of this constraint</returns>
        public double GetComplimentVolumeAtDose(PlanningItem pi)
        {
            var structures = StructureNames.Select(s => pi.GetStructure(s));
            var volAtDose = pi.GetComplimentVolumeAtDose(structures, ConstraintDose, VolumeType);
            return volAtDose;
        }

        public override ConstraintResult Constrain(PlanningItem pi)
        {
            var msg = string.Empty;
            var passed = GetFailedResultType();

            var volAtDose = GetComplimentVolumeAtDose(pi);
            passed = PassingFunc(volAtDose);

            var stringUnit = VolumeType == VolumePresentation.AbsoluteCm3 ? "CC" : "%";
            var val = $"{volAtDose.ToString("F3")} {stringUnit}";

            msg =
                $"Compliment volume of {StructureName} at {ConstraintDose.Dose} {ConstraintDose.UnitAsString} was {val}.";
            return new ConstraintResult(this, passed, msg, val);
        }
    }
}