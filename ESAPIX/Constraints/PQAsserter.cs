#region

using System;
using System.Collections.Generic;
using System.Linq;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.API;
using static ESAPIX.Constraints.ResultType;

#endregion

namespace ESAPIX.Constraints
{
    /// <summary>
    /// The Plan Quality Asserter verifies a planning item meets certain criteria, before constraining to a 
    /// particular constraint. It is designed to help with the IConstraint.CanConstrain(pi) method.
    /// </summary>
    public class PQAsserter
    {
        private PlanningItem _pi;

        public PQAsserter(PlanningItem pi)
        {
            _pi = pi;
        }

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
        /// Asserts the input assertion. Upon failure returns a Action Level 3 contraint result
        /// </summary>
        /// <param name="assertion">the assertion that if not passed, returns an "not applicable" result</param>
        /// <param name="failedMessage">the message to show in case of failure</param>
        /// <returns>the plan quality asserter</returns>
        public PQAsserter Assert(Func<PlanningItem, bool> assertion, string failedMessage)
        {
            bool passed = false;
            try
            {
                passed = assertion(_pi);
            }
            catch (Exception e) { failedMessage += $" => Exception thrown : {e.Message}"; }

            Results.Add(new ConstraintResult(null, passed ? ResultType.PASSED : ResultType.NOT_APPLICABLE, failedMessage));
            return this;
        }

        /// <summary>
        /// Asserts the input assertion. Upon failure returns a Action Level 3 contraint result
        /// </summary>
        /// <param name="assertion">the assertion that if not passed, returns an Action level 3 result</param>
        /// <param name="failedMessage">the message to show in case of failure</param>
        /// <returns>the plan quality asserter</returns>
        public PQAsserter AssertCriticalPriority(Func<PlanningItem, bool> assertion, string failedMessage)
        {
            bool passed = false;
            try
            {
                passed = assertion(_pi);
            }
            catch (Exception e) { failedMessage += $" => Exception thrown : {e.Message}"; }
            Results.Add(new ConstraintResult(null, passed ? ResultType.PASSED : ResultType.ACTION_LEVEL_3, failedMessage));
            return this;
        }

        /// <summary>
        /// Asserts the input assertion. Upon failure returns a Action Level 3 contraint result
        /// </summary>
        /// <param name="assertion">the assertion that if not passed, returns an Action level 2 result</param>
        /// <param name="failedMessage">the message to show in case of failure</param>
        /// <returns>the plan quality asserter</returns>
        public PQAsserter AssertMidPriority(Func<PlanningItem, bool> assertion, string failedMessage)
        {
            bool passed = false;
            try
            {
                passed = assertion(_pi);
            }
            catch (Exception e) { failedMessage += $" => Exception thrown : {e.Message}"; }
            Results.Add(new ConstraintResult(null, passed ? ResultType.PASSED : ResultType.ACTION_LEVEL_2, failedMessage));
            return this;
        }

        /// <summary>
        /// Asserts the input assertion. Upon failure returns a Action Level 1 contraint result
        /// </summary>
        /// <param name="assertion">the assertion that if not passed, returns an Action level 3 result</param>
        /// <param name="failedMessage">the message to show in case of failure</param>
        /// <returns>the plan quality asserter</returns>
        public PQAsserter AssertLowPriority(Func<PlanningItem, bool> assertion, string failedMessage)
        {
            bool passed = false;
            try
            {
                passed = assertion(_pi);
            }
            catch (Exception e) { failedMessage += $" => Exception thrown : {e.Message}"; }
            Results.Add(new ConstraintResult(null, passed ? ResultType.PASSED : ResultType.ACTION_LEVEL_1, failedMessage));
            return this;
        }

        public PQAsserter ContainsValidFractionNum()
        {
            int? numFx = 0;
            if (_pi is PlanSum)
            {
                numFx = (_pi as PlanSum).PlanSetups.Sum(p => p?.NumberOfFractions());
            }
            else
                numFx = (_pi as PlanSetup)?.NumberOfFractions();

            Results.Add(new ConstraintResult(null, numFx != null ? ResultType.PASSED : ResultType.NOT_APPLICABLE, "Not valid fraction number", string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts contains image (not null)
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter HasImage()
        {
            if (_pi.GetImage() == null)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "No image", string.Empty));
            else
                Results.Add(new ConstraintResult(null, PASSED, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts contains structure set (not null)
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter HasStructureSet()
        {
            // Check for structure set. If plan does not have a structure set, test is not applicable
            if (_pi.GetStructures() == null)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "No structure set.", string.Empty));
            else
                Results.Add(new ConstraintResult(null, PASSED, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts planning item is plan setup type
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter IsPlanSetup()
        {
            // Check for structure set. If plan does not have a structure set, test is not applicable
            if (_pi is PlanSum)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Must be plan setup only", string.Empty));
            else Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));

            return this;
        }

        /// <summary>
        /// Asserts planning item is ion plan setup type
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter IsIonPlanSetup()
        {
            // Check for structure set. If plan does not have a structure set, test is not applicable
            if (_pi is IonPlanSetup)
                Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            else
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Must be ion plan setup only", string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts planning item is brachy plan setup type
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter IsBrachyPlanSetup()
        {
            // Check for structure set. If plan does not have a structure set, test is not applicable
            if (_pi is BrachyPlanSetup)
                Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            else
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Must be brachy plan setup only", string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts planning item is brachy plan setup type
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter IsExternalPlanSetup()
        {
            // Check for structure set. If plan does not have a structure set, test is not applicable
            if (_pi is ExternalPlanSetup)
                Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            else
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Must be external plan setup only", string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts is plan setup AND contains electron fields
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsOneOrMoreElectronBeams()
        {
            var isPlanSetup = IsPlanSetup().Results.Last();
            if (!isPlanSetup.IsSuccess)
            {
                Results.Add(isPlanSetup);
                return this;
            }

            var ps = _pi as PlanSetup;
            var ens = ps.Beams.Select(b => b.EnergyModeDisplayName).ToList();
            var containsElectrons = ens.Any(e => e.EndsWith("E"));

            if (!containsElectrons)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Doesn't contain electron fields", string.Empty));
            else
                Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains a non emtpy structure with the structure id equal to the input ids
        /// </summary>
        /// <param name="structureIds">the ids required for the plan</param>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsNonEmptyStructuresById(params string[] structureIds)
        {
            var structures = _pi.GetStructures();
            if (structures == null)
            {
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE_MISSING_STRUCTURE, "No structure set", string.Empty));
                return this;
            }
            foreach (var id in structureIds)
                if (!_pi.ContainsStructure(id))
                {
                    Results.Add(new ConstraintResult(null, NOT_APPLICABLE_MISSING_STRUCTURE, $"Missing {id}, or {id} is empty",
                        string.Empty));
                    return this;
                }
            Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains at least one non emtpy structure with the structure id equal to the input ids
        /// </summary>
        /// <param name="structureIds">the ids required for the plan</param>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsOneOrMoreNonEmptyStructureById(params string[] structureIds)
        {
            var structures = _pi.GetStructures();
            if (structures == null)
            {
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE_MISSING_STRUCTURE, "No structure set", string.Empty));
                return this;
            }
            foreach (var id in structureIds)
            {
                if (_pi.ContainsStructure(id))
                {
                    Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
                    return this;
                }
            }

            Results.Add(new ConstraintResult(null, NOT_APPLICABLE_MISSING_STRUCTURE, $"Does not contain one: {string.Join(",", structureIds)}, or all are empty",
                         string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains a non emtpy structure with the DICOM type equal to the input DICOM types
        /// </summary>
        /// <param name="dicomTypes">the required DICOM types for this plan</param>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsNonEmptyStructuresByDICOMType(params string[] dicomTypes)
        {
            var structures = _pi.GetStructures();
            if (structures == null)
            {
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE_MISSING_STRUCTURE, "No structure set", string.Empty));
                return this;
            }
            foreach (var dt in dicomTypes)
            {
                if (!structures.Any(s => s.DicomType == dt && !s.IsEmpty))
                {
                    Results.Add(new ConstraintResult(null, NOT_APPLICABLE_MISSING_STRUCTURE,
                        $"Missing type {dt}, or {dt} structure is empty", string.Empty));
                    return this;
                }
            }

            Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains at least one non emtpy structure with the DICOM type equal to the input DICOM types
        /// </summary>
        /// <param name="dicomTypes">the required DICOM types for this plan</param>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsOneOrMoreNonEmptyStructuresByDICOMType(params string[] dicomTypes)
        {
            var structures = _pi.GetStructures();
            if (structures == null)
            {
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE_MISSING_STRUCTURE, "No structure set", string.Empty));
                return this;
            }
            foreach (var dt in dicomTypes)
            {
                if (structures.Any(s => s.DicomType == dt && !s.IsEmpty))
                {
                    Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
                    return this;
                }
            }

            Results.Add(new ConstraintResult(null, NOT_APPLICABLE_MISSING_STRUCTURE,
                       $"Does not contain one: {string.Join(",", dicomTypes)}, or all are empty", string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains all fields of specified MLCPlanType
        /// </summary>
        /// <param name="mType">the MLC type which all beams must have</param>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsTreatmentBeamsByMLCPlanType(VMS.TPS.Common.Model.Types.MLCPlanType mType)
        {
            var beams = _pi.GetBeams();
            if (beams == null || !beams.Any())
            {
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE,
                     $"Does not contain any beams", string.Empty));
                return this;
            }
            foreach (var beam in beams)
            {
                if (beam.MLCPlanType != mType)
                {
                    Results.Add(new ConstraintResult(null, NOT_APPLICABLE,
                    $"Beam {beam.Id} is not of type {mType}", string.Empty));
                    return this;
                }
            }
            Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains all fields of specified MLCPlanType
        /// </summary>
        /// <param name="mType">the MLC type which all beams must have</param>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsOneOrMoreTreatmentBeamsByMLCPlanType(VMS.TPS.Common.Model.Types.MLCPlanType mType)
        {
            var beams = _pi.GetBeams();
            if (beams == null || !beams.Any())
            {
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE,
                     $"Does not contain any beams", string.Empty));
                return this;
            }
            foreach (var beam in beams)
            {
                if (beam.MLCPlanType == mType)
                {
                    Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
                    return this;
                }
            }

            Results.Add(new ConstraintResult(null, NOT_APPLICABLE,
                  $"No beam is not of type {mType}", string.Empty));
            return this;

        }

        /// <summary>
        /// Asserts the plan contains at least one photon beam
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsOneOrMorePhotonBeams()
        {
            var isPlanSetup = IsPlanSetup().Results.Last();
            if (!isPlanSetup.IsSuccess)
            {
                Results.Add(isPlanSetup);
                return this;
            }

            var ps = _pi as PlanSetup;
            var ens = ps.Beams.Select(b => b.EnergyModeDisplayName).ToList();
            var containsPhotons = ens.Any(e => e.EndsWith("X"));

            if (!containsPhotons)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Doesn't contain photon fields", string.Empty));
            else
                Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains at least one proton beam
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter ContainsOneOrMoreProtonBeams()
        {
            var isPlanSetup = IsPlanSetup().Results.Last();
            if (!isPlanSetup.IsSuccess)
            {
                Results.Add(isPlanSetup);
                return this;
            }

            var ps = _pi as PlanSetup;
            var ens = ps.Beams.Select(b => b.EnergyModeDisplayName).ToList();
            var containsProtons = ens.Any(e => e.EndsWith("P"));

            if (!containsProtons)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Doesn't contain proton fields", string.Empty));
            else
                Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }

        /// <summary>
        /// Asserts the plan contains at least one proton beam
        /// </summary>
        /// <returns>the asserter object</returns>
        public PQAsserter IsIonPlan()
        {
            var isPlanSetup = IsPlanSetup().Results.Last();
            if (!isPlanSetup.IsSuccess)
            {
                Results.Add(isPlanSetup);
                return this;
            }

            var ps = _pi as PlanSetup;
            var ens = ps.Beams.Select(b => b.EnergyModeDisplayName).ToList();
            var containsProtons = ens.Any(e => e.EndsWith("P"));

            if (!containsProtons)
                Results.Add(new ConstraintResult(null, NOT_APPLICABLE, "Doesn't contain proton fields", string.Empty));
            else
                Results.Add(new ConstraintResult(null, PASSED, string.Empty, string.Empty));
            return this;
        }
    }
}