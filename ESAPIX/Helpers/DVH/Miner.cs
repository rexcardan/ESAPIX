using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Exceptions;
using ESAPIX.Extensions;
using VMS.TPS.Common.Model.API;
using ESAPIX.Helpers.Filters;
using ESAPIX.Helpers.IO;
using ESAPIX.Logging;
using ESAPIX.Helpers.Strings;

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

        public CsvFile GetMetrics(Application app, params StructureQuery[] metricsDesired)
        {
            CsvFile csv = new CsvFile();
            var header = new List<dynamic>();
            header.AddRange(new dynamic[] { "Patient Id", "Course", "Plan Id", "Structure", "Volume" });
            var metrics = metricsDesired.SelectMany(m => m.Queries).Distinct().ToList();
            header.AddRange(metrics);

            if (_doIncludeDVH)
            {
                header.Add($"DVH[{_dvhParams.DoseUnits}]");
                header.AddRange(Enumerable.Range(0, 120).Select(i => (dynamic)i));
            }
            csv.AddRow(header.ToArray());

            foreach (var id in _patientIds)
            {
                try
                {
                    Logger.Log($"Opening patient {id}");
                    var pat = app.OpenPatientById(id);
                    if (pat == null)
                    {
                        Logger.Log($"Couldn't find patient {id}");
                        throw new PatientNotFoundException(id);
                    }

                    //Match structure sets
                    Logger.Log($"Filtering structure sets...");
                    var s_structureSets = FilterStructureSets(pat).ToList();
                    Logger.Log($"{s_structureSets.Count()} structure sets match criteria");
                    Logger.Log($"Filtering planning items...");
                    var s_plans = FilterPlanningItems(pat, s_structureSets).ToList();
                    Logger.Log($"{s_plans.Count()} plans match criteria");

                    foreach (var pi in s_plans)
                    {
                        var s_structures = GetFilteredStructures(pi, metricsDesired);
                        foreach (var str in s_structures)
                        {
                            List<dynamic> rowItems = new List<dynamic>();
                            rowItems.AddRange(new dynamic[] { pat.Id, pi.GetCourse().Id, pi.Id });
                            rowItems.Add(str.Id);
                            rowItems.Add(str.Volume);
                            foreach (var met in metrics)
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
                                for (int i = 0; i < Math.Ceiling(maxDose) + 3; i++)
                                {
                                    var val = dvh.CurveData.GetVolumeAtDose(new VMS.TPS.Common.Model.Types.DoseValue(i, _dvhParams.DoseUnits));
                                    rowItems.Add(val);
                                }
                            }
                            csv.AddRow(rowItems.ToArray());
                        }
                    }

                    Logger.Log($"Closing patient {id}");
                    app.ClosePatient();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    app.ClosePatient();
                }
            }
            return csv;
        }

        /// <summary>
        /// Finds only the structures to be queries based on input structure Ids
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="metricsDesired"></param>
        /// <returns></returns>
        private IEnumerable<Structure> GetFilteredStructures(PlanningItem pi, StructureQuery[] metricsDesired)
        {
            var structureIds = metricsDesired.Select(m => m.StructureId).Distinct().ToList();
            return pi.GetStructureSet().Structures.Where(s => structureIds.Contains(s.Id));
        }

        private IEnumerable<PlanningItem> FilterPlanningItems(Patient pat, IEnumerable<StructureSet> s_structureSets)
        {
            IEnumerable<PlanningItem> planSetups = pat.Courses.SelectMany(c => c.PlanSetups)
                    .Where(p => s_structureSets.Any(s => s.Id == p.StructureSet.Id));

            if (IncludePlanSums)
            {
                IEnumerable<PlanningItem> planSums = pat.Courses.SelectMany(c => c.PlanSums)
                  .Where(p => s_structureSets.Any(s => s.Id == p.StructureSet.Id));
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
        /// Adds a patient id to the patients to be sampled
        /// </summary>
        /// <param name="id">the id of the patient</param>
        public void AddPatientId(string id)
        {
            _patientIds.Add(id);
        }
    }
}
