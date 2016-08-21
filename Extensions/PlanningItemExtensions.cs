using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ESAPIX.Interfaces;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using static ESAPIX.Helpers.MathHelper;
namespace ESAPIX.Extensions
{
    public static class PlanningItemExtensions
    {
        /// <summary>
        /// Returns the structures from the planning item. Removes the need to cast to plan or plan sum.
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
        /// Returns the structure set from the planning item. Removes the need to cast to plan or plan sum.
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
        /// Returns the image from the planning item. Removes the need to cast to plan or plan sum.
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
        /// Returns true if the planning item references a structure set with the input structure id. Also allows a regex
        /// expression to match to structure id.
        /// </summary>
        /// <param name="plan">the planning item</param>
        /// <param name="structId">the structure id to match</param>
        /// <param name="regex">the optional regex expression to match against a structure id</param>
        /// <returns></returns>
        public static bool ContainsStructure(this PlanningItem plan, string structId, string regex = null)
        {
            Structure s;
            return plan.ContainsStructure(structId, regex, out s);
        }

        private static bool ContainsStructure(this PlanningItem plan, string structId, string regex, out Structure s)
        {
            foreach (var struc in plan.GetStructures())
            {
                bool regexMatched = (!string.IsNullOrEmpty(regex)) && Regex.IsMatch(struc.Id, regex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (((0 == string.Compare(structId, struc.Id, true)) || regexMatched)) { s = struc; return true; }//This means a match (if true)!
            }
            s = null;
            return false; //None found

        }

        /// <summary>
        /// Gets a structure (if it exists from the structure set references by the planning item
        /// </summary>
        public static Structure GetStructure(this PlanningItem plan, string structId, string regex = null)
        {
            Structure s;
            plan.ContainsStructure(structId, regex, out s);
            return s;
        }

        /// <summary>
        /// Enables a shorter method for doing a common task (getting the DVH from a structure). Contains default values.
        /// </summary>
        public static DVHData GetDefaultDVHCumulativeData(this PlanningItem plan, Structure s, DoseValuePresentation dvp = DoseValuePresentation.Absolute, VolumePresentation vp = VolumePresentation.Relative, double binWidth = 0.1)
        {
            return plan.GetDVHCumulativeData(s, dvp, vp, binWidth);
        }

        /// <summary>
        /// Finds the dose at a certain volume input of a structure
        /// </summary>
        /// <param name="i">the planning item</param>
        /// <param name="s">the structure to analyze</param>
        /// <param name="volume">the volume to sample (units are in the vPres variable)</param>
        /// <param name="vPres">the units of the input volume</param>
        /// <param name="dPres">the dose value presentation you want returned</param>
        /// <returns></returns>
        public static DoseValue GetDoseAtVolume(this PlanningItem i, Structure s, double volume, VolumePresentation vPres, DoseValuePresentation dPres)
        {
            var dvh = i.GetDVHCumulativeData(s, dPres, vPres, 0.1);
            var curve = dvh.CurveData;

            var point = dvh.MaxDose;

            //Max vol scenario
            if ((s.Volume == volume && vPres == VolumePresentation.AbsoluteCm3) || (vPres == VolumePresentation.Relative && volume == 100.0))
            {
                return dvh.MinDose;
            }
            //Min vol scenario
            if ((s.Volume == 0.0))
            {
                return dvh.MaxDose;
            }
            //Overvolume scenario
            if ((s.Volume < volume && vPres == VolumePresentation.AbsoluteCm3) || (vPres == VolumePresentation.Relative && volume > 100.0))
            {
                return new DoseValue(double.NaN, point.Unit);
            }
            else
            {
                //Interpolate
                var higherPoints = curve.Where(p => p.Volume > volume);
                var lowerPoints = curve.Where(p => p.Volume <= volume);

                var point1 = higherPoints.Last();
                var point2 = lowerPoints.First();
                var doseAtPoint = Interpolate(point1.Volume, point2.Volume, point1.DoseValue.Dose, point2.DoseValue.Dose, volume);
                return new DoseValue(doseAtPoint, point.Unit);
            }
        }

        /// <summary>
        /// Finds the dose at a certain volume input of a structure
        /// </summary>
        /// <param name="i">the planning item</param>
        /// <param name="s">the structure to analyze</param>
        /// <param name="volume">the volume to sample (units are in the vPres variable)</param>
        /// <param name="vPres">the units of the input volume</param>
        /// <param name="dPres">the dose value presentation you want returned</param>
        /// <returns></returns>
        public static DoseValue GetDoseAtVolume(this PlanningItem pi, IEnumerable<Structure> ss, double volume, VolumePresentation vPres, DoseValuePresentation dPres)
        {
            var dvhs = ss.Select(s => pi.GetDVHCumulativeData(s, dPres, VolumePresentation.AbsoluteCm3, 0.1));
            var mergedDVH = dvhs.MergeDVHs();

            if(vPres == VolumePresentation.Relative)
            {
                mergedDVH = mergedDVH.ConvertToRelativeVolume();
            }
            return mergedDVH.GetDoseAtVolume(volume);    
        }

        /// <summary>
        /// Return the coldspot dose for a given volume. This is equivalent to taking the total volume of the object and subtracting the input volume
        /// </summary>
        /// <param name="i">the current planning item</param>
        /// <param name="s">the input structure</param>
        /// <param name="volume">the volume to query</param>
        /// <param name="vPres">the volume presentation of the input volume</param>
        /// <param name="dPres">the dose presentation to return</param>
        /// <returns>Return the coldspot dose for a given volume.</returns>
        public static DoseValue GetColdspotAtVolume(this PlanningItem i, Structure s, double volume, VolumePresentation vPres, DoseValuePresentation dPres)
        {
            if (i is PlanSetup)
            {
                var plan = i as PlanSetup;
                var dvh = plan.GetDefaultDVHCumulativeData(s, dPres, vPres);
                return dvh.CurveData.GetColdspot(volume);
            }
            else
            {
                var plan = i as PlanSum;
                var dvh = plan.GetDefaultDVHCumulativeData(s, dPres, vPres);
                return dvh.CurveData.GetColdspot(volume);
            }
        }

        /// <summary>
        /// Returns the volume of the input structure at a given input dose
        /// </summary>
        /// <param name="pi">the current planning item</param>
        /// <param name="ss">the structure to query</param>
        /// <param name="dv">the dose value to query</param>
        /// <param name="vPres">the volume presentation to return</param>
        /// <returns>the volume at the requested presentation</returns>
        public static double GetVolumeAtDose(this PlanningItem pi, Structure s, DoseValue dv, VolumePresentation vPres)
        {
            var dpres = dv.GetPresentation();
            return pi
                .GetDVHCumulativeData(s, dpres, vPres, 0.1)
                .CurveData
                .GetVolumeAtDose(dv);
        }

        /// <summary>
        /// Returns the sum of the volumes across the input structures at a given input dose
        /// </summary>
        /// <param name="pi">the current planning item</param>
        /// <param name="ss">the structures to query</param>
        /// <param name="dv">the dose value to query</param>
        /// <param name="vPres">the volume presentation to return</param>
        /// <returns>the volume at the requested presentation</returns>
        public static double GetVolumeAtDose(this PlanningItem pi, IEnumerable<Structure> ss, DoseValue dv, VolumePresentation vPres)
        {
            return ss.Sum(s => pi.GetVolumeAtDose(s, dv, vPres));
        }

        public static double TotalPrescribedDoseGy(this PlanningItem pi)
        {
            Func<PlanSetup, double> getDoseFromRx = new Func<PlanSetup, double>(ps =>
            {
                return ps.TotalPrescribedDose.GetDoseGy();
            });

            //Dose is prescription based

            if (pi is PlanSetup)
            {
                var plan = pi as PlanSetup;
                return getDoseFromRx(plan);
            }
            else
            {
                //Plan Sum
                var sum = pi as PlanSum;
                var totalDose = 0.0;
                foreach (var plan in sum.PlanSetups)
                {
                    totalDose += getDoseFromRx(plan);
                }
                return totalDose;
            }
        }
    }
}
