#region

using ESAPIX.Extensions;
using VMS.TPS.Common.Model.API;

#endregion

namespace ESAPIX.Constraints
{
    /// <summary>
    ///     Checks to make sure the structure name is present in the planning item structure set, and structure is not empty
    /// </summary>
    public class StructureNameConstraint : IConstraint
    {
        public string Regex { get; set; }
        public string StructureName { get; set; }
        public string Name => $"{StructureName} required";
        public string FullName => Name;

        public ConstraintResult CanConstrain(PlanningItem pi)
        {
            var message = string.Empty;
            //Check for null plan
            var valid = pi != null;
            if (!valid) message = "Plan is null";

            //Check structure exists
            valid = valid && pi.GetStructureSet() != null;
            if (!valid) message = $"No structure set in {pi.Id}";
            return new ConstraintResult(this, ResultType.NOT_APPLICABLE, message);
        }

        public ConstraintResult Constrain(PlanningItem pi)
        {
            var msg = string.Empty;
            var structure = pi.GetStructure(StructureName, Regex);
            var passed = ResultType.ACTION_LEVEL_1;
            if (structure != null)
            {
                passed = ResultType.PASSED;
                msg = $"{pi.Id} contains structure {StructureName}";

                if (structure.Volume < 0.0001)
                {
                    passed = ResultType.ACTION_LEVEL_1;
                    msg = $"{StructureName} is empty";
                }
            }
            return new ConstraintResult(this, passed, msg);
        }

        public override string ToString()
        {
            return $"Required Structure {StructureName}";
        }
    }
}