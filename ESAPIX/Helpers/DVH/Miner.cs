using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Exceptions;
using ESAPIX.Extensions;
using ESAPIX.Facade.API;
using ESAPIX.Helpers.Filters;
using ESAPIX.Helpers.IO;
using ESAPIX.Logging;

namespace ESAPIX.Helpers.DVH
{
    public class Miner
    {
        /// <summary>
        /// The patient ids which will be mined when GetMetrics is called
        /// </summary>
        private List<string> _patientIds = new List<string>();
        /// <summary>
        /// The structure set id containing the structures. Will sample all sets if this is
        /// not specified
        /// </summary>
        private string _structureSetId;
        /// <summary>
        /// The matching criteria for the structure set id
        /// </summary>
        private MatchType _structureSetMatchType;
        /// <summary>
        /// The exclusive structures to be sampled. Will sample all if this list is empty
        /// </summary>
        private List<string> _structures = new List<string>();
        private bool _doIncludeDVH;
        private DVHParams _dvhParams;

        public Logger Logger { get; private set; } = new Logger();

        public bool IncludePlanSums { get; set; }

        public void IncludeDVH(DVHParams dvhParams)
        {
            if (dvhParams == null) { throw new ArgumentNullException("DVH Params cannot be null!"); }
            _doIncludeDVH = true;
            _dvhParams = dvhParams;
        }

        /// <summary>
        /// Gets the metrics requested for the patient ids and specific filters set
        /// </summary>
        /// <param name="metrics">a list of Mayo format DVH criteria</param>
        /// <returns></returns>
        public CsvFile GetMetrics(Facade.API.Application app, params string[] metrics)
        {
            CsvFile csv = new CsvFile();
            var header = new List<dynamic>();
            header.AddRange(new dynamic[] { "Patient Id", "Course", "Plan Id", "Structure", "Volume" });
            header.AddRange(metrics);
            if (_doIncludeDVH)
            {
                header.Add($"DVH[{_dvhParams.DoseUnits}]");
                header.AddRange(Enumerable.Range(0, 120).Select(i => (dynamic)i));
            }
            csv.AddRow(header.ToArray());

            foreach (var id in _patientIds)
            {
                Logger.Log($"Opening patient {id}");
                var pat = app.OpenPatientById(id);
                if (pat == null) { Logger.Log($"Couldn't find patient {id}"); throw new PatientNotFoundException(id); }

                //Match structure sets
                Logger.Log($"Filtering structure sets...");
                var s_structureSets = FilterStructureSets(pat);
                Logger.Log($"{s_structureSets.Count()} structure sets match criteria");
                Logger.Log($"Filtering planning items...");
                var s_plans = FilterPlanningItems(pat, s_structureSets);
                Logger.Log($"{s_plans.Count()} plans match criteria");

                foreach (var pi in s_plans)
                {
                    List<dynamic> rowItems = new List<dynamic>();
                    rowItems.AddRange(new dynamic[] { pat.Id, pi.GetCourse().Id, pi.Id });
                    var s_structures = GetFilteredStructures(pi);
                    foreach(var str in s_structures)
                    {

                        rowItems.Add(str.Id);
                        rowItems.Add(str.Volume);
                        foreach(var met in metrics)
                        {
                            Logger.Log($"Querying {met} from item {pi.Id}, structure {str.Id}...");
                            var val = pi.ExecuteQuery(met, str);
                            Logger.Log($"Storing value {met} = {val} for item {pi.Id}, structure {str.Id}...");
                            rowItems.Add(val);
                        }
                        if (_doIncludeDVH)
                        {
                            Logger.Log($"Recording DVH from item {pi.Id}, structure {str.Id}...");
                            rowItems.Add(string.Empty); //cell space
                            var dvh = pi.GetDVHCumulativeData(str, _dvhParams.DosePresentation, _dvhParams.VolumePresentation, _dvhParams.BinWidth);
                            var maxDose = dvh.MaxDose.Dose;
                            for(int i = 0; i < Math.Ceiling(maxDose) + 3; i++)
                            {
                                var val = dvh.CurveData.GetVolumeAtDose(new VMS.TPS.Common.Model.Types.DoseValue(i, _dvhParams.DoseUnits));
                                rowItems.Add(val);
                            }
                        }
                    }
                    csv.AddRow(rowItems.ToArray());
                   
                }
                Logger.Log($"Closing patient {id}");
                app.ClosePatient();
            }
            return csv;
        }

        private IEnumerable<Structure> GetFilteredStructures(PlanningItem pi)
        {
            if (!_structures.Any()) { return pi.GetStructureSet().Structures; }
            else
            {
                return pi.GetStructureSet().Structures
                    .Where(s => _structures.Any(st => st.ToUpper().Equals(s.Id.ToUpper())));
            }
        }

        private IEnumerable<PlanningItem> FilterPlanningItems(Patient pat, IEnumerable<StructureSet> s_structureSets)
        {
            IEnumerable<PlanningItem> planSetups = pat.Courses.SelectMany(c => c.PlanSetups)
                    .Where(p => s_structureSets.Contains(p.StructureSet));
            IEnumerable<PlanningItem> planSums = pat.Courses.SelectMany(c => c.PlanSums)
                .Where(p => s_structureSets.Contains(p.StructureSet));
            if (IncludePlanSums)
            {
                return planSetups.Concat(planSums);
            }
            else
            {
                return planSetups;
            }
        }

        private IEnumerable<StructureSet> FilterStructureSets(Patient pat)
        {
            double smallestLD = double.NaN;
            return _structureSetId == null ? pat.StructureSets ://all
                    pat.StructureSets.Where(ss =>
                    {
                        if (_structureSetMatchType == MatchType.EXACT_MATCH)
                        {
                            return ss.Id.ToUpper() == _structureSetId.ToUpper();
                        }
                        else
                        {
                            smallestLD = double.IsNaN(smallestLD) ?
                               CalculateMinLDistance(pat.StructureSets) : smallestLD;
                            return Levenshtein.ComputeDistance(ss.Id.ToUpper(), _structureSetId.ToUpper()) == smallestLD;
                        }
                    });
        }

        private double CalculateMinLDistance(IEnumerable<StructureSet> structureSets)
        {
            return structureSets.Min(s => Levenshtein.ComputeDistance(s.Id.ToUpper(), _structureSetId.ToUpper()));
        }

        /// <summary>
        /// Specify a particular structure set to be sampled for each patient. If set the other
        /// structure sets not matching the id/match type will be ignored
        /// </summary>
        /// <param name="structureSetId">the structure set id to be sampled</param>
        /// <param name="matchType">the matching type criteria for the structure set id</param>
        public void SetStructureSetFilter(string structureSetId, MatchType matchType)
        {
            _structureSetId = structureSetId;
            _structureSetMatchType = matchType;
        }

        /// <summary>
        /// Specify the particular structures to be sampled for each patient. If not set,
        /// all structures will be sampled. Will not be case sensitive in the search
        /// </summary>
        /// <param name="structures">the structure ids to be sampled</param>
        public void SetStructures(params string[] structures)
        {
            _structures = structures.ToList();
        }

        /// <summary>
        /// Adds a patient id to the patients to be sampled
        /// </summary>
        /// <param name="id">the id of the patient</param>
        public void AddPatientId(string id)
        {
            _patientIds.Add(id);
        }
    }
}
