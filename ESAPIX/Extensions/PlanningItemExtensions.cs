#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ESAPIX.DVH.Query;
using ESAPIX.Facade.API;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Extensions
{
    public static class PlanningItemExtensions
    {
        #region HELPFUL DESCENDANT OPERATORS

        /// <summary>
        ///     Returns the structures from the planning item. Removes the need to cast to plan or plan sum.
        /// </summary>
        /// <param name="plan">the planning item</param>
        /// <returns>the referenced structure set</returns>
        public static IEnumerable<Structure> GetStructures(this PlanningItem plan)
        {
            if (plan is PlanSetup && plan != null)
            {
                var p = plan as PlanSetup;
                return p.StructureSet?.Structures;
            }
            if (plan is PlanSum && plan != null)
            {
                var p = plan as PlanSum;
                return p.StructureSet?.Structures;
            }
            return null;
        }

        /// <summary>
        /// Get beams from even a plan sum by iterating over plans in plansum
        /// </summary>
        /// <param name="pi">the planning item containing beams</param>
        /// <returns>the beams from the plan(s)</returns>
        public static IEnumerable<Beam> GetBeams(this PlanningItem pi)
        {
            if (pi is PlanSetup)
            {
                foreach (var beam in (pi as PlanSetup).Beams)
                {
                    yield return beam;
                }
            }
            else if (pi is PlanSum)
            {
                foreach (var ps in (pi as PlanSum).PlanSetups)
                {
                    foreach (var beam in ps.Beams)
                    {
                        yield return beam;
                    }
                }
            }
        }

        /// <summary>
        ///     Returns the structure set from the planning item. Removes the need to cast to plan or plan sum.
        /// </summary>
        /// <param name="plan">the planning item</param>
        /// <returns>the referenced structure set</returns>
        public static StructureSet GetStructureSet(this PlanningItem plan)
        {
            if (plan is PlanSetup && plan != null)
            {
                var p = plan as PlanSetup;
                return p.StructureSet;
            }
            if (plan is PlanSum && plan != null)
            {
                var p = plan as PlanSum;
                return p.StructureSet;
            }
            return null;
        }

        /// <summary>
        ///     Returns the image from the planning item. Removes the need to cast to plan or plan sum.
        /// </summary>
        /// <param name="plan">the planning item</param>
        /// <returns>the referenced structure set</returns>
        public static Image GetImage(this PlanningItem plan)
        {
            if (plan is PlanSetup && plan != null)
            {
                var p = plan as PlanSetup;
                return p.StructureSet?.Image;
            }
            if (plan is PlanSum && plan != null)
            {
                var p = plan as PlanSum;
                return p.StructureSet?.Image;
            }
            return null;
        }

        /// <summary>
        ///     Returns true if the planning item references a structure set with the input structure id AND the structure is
        ///     contoured. Also allows a regex
        ///     expression to match to structure id.
        /// </summary>
        /// <param name="plan">the planning item</param>
        /// <param name="structId">the structure id to match</param>
        /// <param name="regex">the optional regex expression to match against a structure id</param>
        /// <returns>
        ///     Returns true if the planning item references a structure set with the input structure id AND the structure is
        ///     contoured.
        /// </returns>
        public static bool ContainsStructure(this PlanningItem plan, string structId, string regex = null)
        {
            Structure s;
            return plan.ContainsStructure(structId, regex, out s);
        }

        /// <summary>
        ///     Returns true if the planning item references a structure set with the input structure id AND the structure is
        ///     contoured. Also allows a regex
        ///     expression to match to structure id.
        /// </summary>
        /// <param name="plan">the planning item</param>
        /// <param name="structId">the structure id to match</param>
        /// <param name="regex">the optional regex expression to match against a structure id</param>
        /// <param name="s">returns the structure back for querying (if it exists and is contoured)</param>
        /// <returns>
        ///     Returns true if the planning item references a structure set with the input structure id AND the structure is
        ///     contoured.
        /// </returns>
        private static bool ContainsStructure(this PlanningItem plan, string structId, string regex, out Structure s)
        {
            s = null;
            foreach (var struc in plan.GetStructures())
            {
                var regexMatched = !string.IsNullOrEmpty(regex) &&
                                   Regex.IsMatch(struc.Id, regex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (0 == string.Compare(structId, struc.Id, true) || regexMatched) s = struc;
                if (s != null)
                    if (s.Volume > 0) return true;
            }
            return false; //None found
        }

        /// <summary>
        ///     Gets a structure (if it exists from the structure set references by the planning item
        /// </summary>
        public static Structure GetStructure(this PlanningItem plan, string structId, string regex = null)
        {
            Structure s;
            plan.ContainsStructure(structId, regex, out s);
            return s;
        }

        public static double TotalPrescribedDoseGy(this PlanningItem pi)
        {
            Func<PlanSetup, double> getDoseFromRx = ps => { return ps.TotalPrescribedDose.GetDoseGy(); };

            //Dose is prescription based

            if (pi is PlanSetup)
            {
                var plan = pi as PlanSetup;
                return getDoseFromRx(plan);
            }
            //Plan Sum
            var sum = pi as PlanSum;
            var totalDose = 0.0;
            foreach (var plan in sum.PlanSetups)
                totalDose += getDoseFromRx(plan);
            return totalDose;
        }

        #endregion

        #region DVH HELPERS

        /// <summary>
        ///     Enables a shorter method for doing a common task (getting the DVH from a structure). Contains default values.
        /// </summary>
        public static DVHData GetDefaultDVHCumulativeData(this PlanningItem plan, Structure s,
            DoseValuePresentation dvp = DoseValuePresentation.Absolute,
            VolumePresentation vp = VolumePresentation.Relative, double binWidth = 0.1)
        {
            return plan.GetDVHCumulativeData(s, dvp, vp, binWidth);
        }

        /// <summary>
        ///     The "complex" dvh in this case, is 1. Allows for plan sums to have relative dose, by adding prescriptions to
        ///     determine a
        ///     guessed prescribed dose value. (It is up to the user to determine if this is appropriate). 2). Allows for multiple
        ///     structures
        ///     to be merged into a single dvh by summing volumes as each dose value
        /// </summary>
        /// <param name="pi">the planning item containing the dose and the structures</param>
        /// <param name="ss">the structures to merge into one DVH (useful for multiple volume queries from parallel organs)</param>
        /// <param name="vPres">the volume presentation requested</param>
        /// <param name="dPres">the dose presentation requested</param>
        /// <param name="binWidth">the bin width to use when sampling the DVH</param>
        /// <returns></returns>
        public static DVHPoint[] GetComplexDVH(this PlanningItem pi, IEnumerable<Structure> ss,
            VolumePresentation vPres, DoseValuePresentation dPres, double binWidth = 0.1)
        {
            IEnumerable<DVHPoint[]> dvhs;
            if (pi is PlanSum && dPres == DoseValuePresentation.Relative)
                dvhs =
                    ss.Select(
                        s => (pi as PlanSum).GetRelativeDVHCumulativeData(s, VolumePresentation.AbsoluteCm3, binWidth));
            else
                dvhs = ss.Select(s => pi.GetDVHCumulativeData(s, dPres, VolumePresentation.AbsoluteCm3, binWidth)
                    .CurveData);
            var mergedDVH = dvhs.MergeDVHs();
            if (vPres == VolumePresentation.Relative)
                mergedDVH = mergedDVH.ConvertToRelativeVolume();
            return mergedDVH;
        }

        #endregion

        #region DOSE QUERIES

        /// <summary>
        ///     Finds the dose at a certain volume input of a structure
        /// </summary>
        /// <param name="i">the planning item</param>
        /// <param name="s">the structure to analyze</param>
        /// <param name="volume">the volume to sample (units are in the vPres variable)</param>
        /// <param name="vPres">the units of the input volume</param>
        /// <param name="dPres">the dose value presentation you want returned</param>
        /// <returns></returns>
        public static DoseValue GetDoseAtVolume(this PlanningItem i, Structure s, double volume,
            VolumePresentation vPres, DoseValuePresentation dPres)
        {
            return i.GetDoseAtVolume(new[] {s}, volume, vPres, dPres);
        }

        /// <summary>
        ///     Finds the dose at a certain volume input of a structure
        /// </summary>
        /// <param name="i">the planning item</param>
        /// <param name="ss">the structure to analyze (will be merged into one dvh)</param>
        /// <param name="volume">the volume to sample (units are in the vPres variable)</param>
        /// <param name="vPres">the units of the input volume</param>
        /// <param name="dPres">the dose value presentation you want returned</param>
        /// <returns></returns>
        public static DoseValue GetDoseAtVolume(this PlanningItem pi, IEnumerable<Structure> ss, double volume,
            VolumePresentation vPres, DoseValuePresentation dPres)
        {
            var dvh = pi.GetComplexDVH(ss, vPres, dPres);
            return dvh.GetDoseAtVolume(volume);
        }

        /// <summary>
        ///     Return the compliment dose (coldspot) for a given volume. This is equivalent to taking the total volume of the
        ///     object and subtracting the input volume
        /// </summary>
        /// <param name="i">the current planning item</param>
        /// <param name="ss">the input structures (will be merged into one dvh)</param>
        /// <param name="volume">the volume to query</param>
        /// <param name="vPres">the volume presentation of the input volume</param>
        /// <param name="dPres">the dose presentation to return</param>
        /// <returns>Return the coldspot dose for a given volume.</returns>
        public static DoseValue GetDoseComplimentAtVolume(this PlanningItem i, IEnumerable<Structure> ss, double volume,
            VolumePresentation vPres, DoseValuePresentation dPres)
        {
            if (i is PlanSetup)
            {
                var plan = i as PlanSetup;
                var dvh = plan.GetComplexDVH(ss, vPres, dPres);
                return dvh.GetDoseCompliment(volume);
            }
            else
            {
                var plan = i as PlanSum;
                var dvh = plan.GetComplexDVH(ss, vPres, dPres);
                return dvh.GetDoseCompliment(volume);
            }
        }

        /// <summary>
        ///     Return the compliment dose (coldspot) for a given volume. This is equivalent to taking the total volume of the
        ///     object and subtracting the input volume
        /// </summary>
        /// <param name="i">the current planning item</param>
        /// <param name="s">the input structure</param>
        /// <param name="volume">the volume to query</param>
        /// <param name="vPres">the volume presentation of the input volume</param>
        /// <param name="dPres">the dose presentation to return</param>
        /// <returns>Return the coldspot dose for a given volume.</returns>
        public static DoseValue GetDoseComplimentAtVolume(this PlanningItem i, Structure s, double volume,
            VolumePresentation vPres, DoseValuePresentation dPres)
        {
            return i.GetDoseComplimentAtVolume(new[] {s}, volume, vPres, dPres);
        }

        #endregion

        #region VOLUME QUERIES

        /// <summary>
        ///     Returns the volume of the input structure at a given input dose
        /// </summary>
        /// <param name="pi">the current planning item</param>
        /// <param name="s">the structure to query</param>
        /// <param name="dv">the dose value to query</param>
        /// <param name="vPres">the volume presentation to return</param>
        /// <returns>the volume at the requested presentation</returns>
        public static double GetVolumeAtDose(this PlanningItem pi, Structure s, DoseValue dv, VolumePresentation vPres)
        {
            var dPres = dv.GetPresentation();
            var dvhCurve = pi.GetComplexDVH(new List<Structure> {s}, vPres, dPres);
            return dvhCurve.GetVolumeAtDose(dv);
        }

        /// <summary>
        ///     Returns the compliment volume of the input structure at a given input dose
        /// </summary>
        /// <param name="pi">the current planning item</param>
        /// <param name="s">the structure to query</param>
        /// <param name="dv">the dose value to query</param>
        /// <param name="vPres">the volume presentation to return</param>
        /// <returns>the volume at the requested presentation</returns>
        public static double GetComplimentVolumeAtDose(this PlanningItem pi, Structure s, DoseValue dv,
            VolumePresentation vPres)
        {
            var dPres = dv.GetPresentation();
            var dvhCurve = pi.GetComplexDVH(new List<Structure> {s}, vPres, dPres);
            return dvhCurve.GetComplimentVolumeAtDose(dv);
        }

        /// <summary>
        ///     Returns the sum of the compliment volumes across the input structures at a given input dose
        /// </summary>
        /// <param name="pi">the current planning item</param>
        /// <param name="ss">the structures to query</param>
        /// <param name="dv">the dose value to query</param>
        /// <param name="vPres">the volume presentation to return</param>
        /// <returns>the volume at the requested presentation</returns>
        public static double GetComplimentVolumeAtDose(this PlanningItem pi, IEnumerable<Structure> ss, DoseValue dv,
            VolumePresentation vPres)
        {
            return ss.Sum(s => pi.GetComplimentVolumeAtDose(s, dv, vPres));
        }

        /// <summary>
        ///     Returns the sum of the volumes across the input structures at a given input dose
        /// </summary>
        /// <param name="pi">the current planning item</param>
        /// <param name="ss">the structures to query</param>
        /// <param name="dv">the dose value to query</param>
        /// <param name="vPres">the volume presentation to return</param>
        /// <returns>the volume at the requested presentation</returns>
        public static double GetVolumeAtDose(this PlanningItem pi, IEnumerable<Structure> ss, DoseValue dv,
            VolumePresentation vPres)
        {
            return ss.Sum(s => pi.GetVolumeAtDose(s, dv, vPres));
        }

        #endregion

        #region MAYO QUERIES

        public static double ExecuteQuery(this PlanningItem pi, IEnumerable<Structure> ss, string mayoFormatQuery)
        {
            var query = MayoQuery.Read(mayoFormatQuery);
            return query.RunQuery(pi, ss);
        }

        public static double ExecuteQuery(this PlanningItem pi, Structure s, string mayoFormatQuery)
        {
            var query = MayoQuery.Read(mayoFormatQuery);
            return query.RunQuery(pi, new[] {s});
        }

        public static double ExecuteQuery(this PlanningItem pi, IEnumerable<Structure> ss, MayoQuery query)
        {
            return query.RunQuery(pi, ss);
        }

        public static double ExecuteQuery(this PlanningItem pi, Structure s, MayoQuery query)
        {
            return query.RunQuery(pi, new[] {s});
        }

        #endregion
    }
}