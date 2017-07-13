#region

using System.Collections.Generic;
using System.Linq;
using ESAPIX.Extensions;
using ESAPIX.Facade.API;
using static ESAPIX.Constraints.ResultType;

#endregion

namespace ESAPIX.Constraints
{
    public class PQAsserter
    {
        public List<ConstraintResult> Results { get; set; } = new List<ConstraintResult>();

        /// <summary>
        /// Returns the cumulative result of all assertions. Will either return the first failing or a passing result
        /// </summary>
        public ConstraintResult CumulativeResult
        {
            get
            {
                //If there are any failures, return first one, otherwise return the first result (which will be passing)
                return Results.Any(r => r.ResultType != PASSED)
                    ? Results.FirstOrDefault(r => r.ResultType != PASSED)
                    : Results.FirstOrDefault();
            }
        }

        /// <summary>
        /// Asserts contains image (not null)
        /// </summary>
        /// <param name="pi">the planing item</param>
        /// <returns>the asserter object</returns>
        public PQAsserter HasImage(PlanningItem pi)
        {
            if (pi.GetImage() == null)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "No image", string.Empty));
            else
                Results.Add(new ConstraintResult(null, PASSED, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts contains structure set (not null)
        /// </summary>
        /// <param name="pi">the planing item</param>
        /// <returns>the asserter object</returns>
        public PQAsserter HasStructureSet(PlanningItem pi)
        {
            // Check for structure set. If plan does not have a structure set, test is not applicable
            if (pi.GetStructures() == null)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "No structure set.", string.Empty));
            else
                Results.Add(new ConstraintResult(null, PASSED, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts planning item is plan setup type
        /// </summary>
        /// <param name="pi">the planing item</param>
        /// <returns>the asserter object</returns>
        public PQAsserter IsPlanSetup(PlanningItem pi)
        {
            // Check for structure set. If plan does not have a structure set, test is not applicable
            if (pi is PlanSum)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Must be plan setup only", string.Empty));
            else Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));

            return this;
        }

        /// <summary>
        /// Asserts is plan setup AND contains electron fields
        /// </summary>
        /// <param name="pi">the planing item</param>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsElectronFields(PlanningItem pi)
        {
            var isPlanSetup = IsPlanSetup(pi).Results.Last();
            if (!isPlanSetup.IsSuccess)
            {
                Results.Add(isPlanSetup);
                return this;
            }

            var ps = pi as PlanSetup;
            var ens = ps.Beams.Select(b => b.EnergyModeDisplayName).ToList();
            var containsElectrons = ens.Any(e => e.EndsWith("E"));

            if (!containsElectrons)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Must contain electron fields", string.Empty));
            else
                Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains a non emtpy structure with the structure id equal to the input ids
        /// </summary>
        /// <param name="structureIds">the ids required for the plan</param>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsNonEmptyStructuresById(PlanningItem pi, params string[] structureIds)
        {
            var structures = pi.GetStructures();
            if (structures == null)
            {
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "No structure set", string.Empty));
                return this;
            }
            foreach (var id in structureIds)
                if (!pi.ContainsStructure(id))
                {
                    Results.Add(new ConstraintResult(null, NOT_APPLICABLE, $"Missing {id}, or {id} is empty",
                        string.Empty));
                    return this;
                }
            Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains a non emtpy structure with the DICOM type equal to the input DICOM types
        /// </summary>
        /// <param name="dicomTypes">the required DICOM types for this plan</param>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsNonEmptyStructuresByDICOMType(PlanningItem pi, params string[] dicomTypes)
        {
            var structures = pi.GetStructures();
            if (structures == null)
            {
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "No structure set", string.Empty));
                return this;
            }
            foreach (var dt in dicomTypes)
                if (!structures.Any(s => s.DicomType == dt && !s.IsEmpty))
                {
                    Results.Add(new ConstraintResult(null, NOT_APPLICABLE,
                        $"Missing type {dt}, or {dt} structure is empty", string.Empty));
                    return this;
                }
            Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }
    }
}