using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ESAPIX.Enums;
using ESAPIX.Interfaces;
using ESAPIX.Proxies;
using ESAPIX.Types;


namespace ESAPIX.Extensions
{
    public static class PlanningItemExtensions
    {
        /// <summary>
        /// Returns the structure set from the planning item. Removes the need to cast to plan or plan sum.
        /// </summary>
        /// <param name="plan">the planning item</param>
        /// <returns>the referenced structure set</returns>
        public static IEnumerable<IStructure> GetStructures(this IPlanningItem plan)
        {
            if (plan is PlanSetup && plan != null)
            {
                var p = plan as PlanSetup;
                if (p.StructureSet != null)
                {
                    return p.StructureSet.Structures;
                }
            }
            if (plan is PlanSum && plan != null)
            {
                var p = plan as PlanSum;
                if (p.StructureSet != null)
                {
                    return p.StructureSet.Structures;
                }
            }
            MessageBox.Show("Structure set from plan " + plan.Id + " was null!");
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
        public static bool ContainsStructure(this IPlanningItem plan, string structId, string regex = null)
        {
            IStructure s;
            return plan.ContainsStructure(structId, regex, out s);
        }

        private static bool ContainsStructure(this IPlanningItem plan, string structId, string regex, out IStructure s)
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
        public static IStructure GetStructure(this IPlanningItem plan, string structId, string regex = null)
        {
            IStructure s;
            plan.ContainsStructure(structId, regex, out s);
            return s;
        }

        /// <summary>
        /// Enables a shorter method for doing a common task (getting the DVH from a structure). Contains default values.
        /// </summary>
        public static IDVHData GetDefaultDVHCumulativeData(this IPlanningItem plan, IStructure s, DoseValuePresentation dvp = DoseValuePresentation.Absolute, VolumePresentation vp = VolumePresentation.Relative, double binWidth = 0.1)
        {
            return plan.GetDVHCumulativeData(s, dvp, vp, binWidth);
        }

        public static DoseValue GetDoseAtVolume(this IPlanningItem i, IStructure s, double volume, VolumePresentation vPres, DoseValuePresentation dPres)
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
                point.Dose = double.NaN;
                return point;
            }
            else
            {
                //Interpolate
                var higherPoints = curve.Where(p => p.Volume > volume);
                var lowerPoints = curve.Where(p => p.Volume <= volume);

                var point1 = higherPoints.Last();
                var point2 = lowerPoints.First();
                var doseAtPoint = Interpolate(point1.Volume, point2.Volume, point1.DoseValue.Dose, point2.DoseValue.Dose, volume);
                point.Dose = doseAtPoint;
                return point;
            }
        }


        //TODO This
        public static DoseValue GetMinimumDoseAtVolume(this IPlanningItem i, IStructure s, double volume, VolumePresentation vPres, DoseValuePresentation dPres)
        {
            if (i is IPlanSetup)
            {
                var plan = i as IPlanSetup;
                var dvh = plan.GetDefaultDVHCumulativeData(s, dPres, vPres);
                return dvh.CurveData.GetMinimumDoseAtVolume(volume);
            }
            else
            {
                var plan = i as IPlanSum;
                var dvh = plan.GetDefaultDVHCumulativeData(s, dPres, vPres);
                return dvh.CurveData.GetMinimumDoseAtVolume(volume);
            }
        }

        public static double GetVolumeAtDose(this IPlanningItem pi, IStructure s, double dose, VolumePresentation vPres, DoseValuePresentation dPres)
        {
            var dvh = pi.GetDVHCumulativeData(s, dPres, vPres, 0.1);
            var point = dvh.MaxDose;
            point.Dose = dose;

            if (dvh != null)
            {
                var curve = dvh.CurveData;
                var rx = pi.TotalPrescribedDoseGy();
                if (dvh.MaxDose.GetDoseGy(rx) < point.GetDoseGy(rx)) { return 0; }
                if (dvh.MinDose.GetDoseGy(rx) > point.GetDoseGy(rx)) { return vPres == VolumePresentation.AbsoluteCm3 ? s.Volume : 1.0; } //100
                else
                {
                    var dosePointGy = dPres == DoseValuePresentation.Absolute ? dose : dose * rx;
                    //Interpolate
                    var higherPoints = curve.Where(p => p.DoseValue.GetDoseGy(rx) > point.GetDoseGy(rx));
                    var lowerPoints = curve.Where(p => p.DoseValue.GetDoseGy(rx) <= point.GetDoseGy(rx));

                    var point1 = higherPoints.First();
                    var point2 = lowerPoints.Last();
                    var volumeAtPoint = Interpolate(point1.DoseValue.GetDoseGy(rx), point2.DoseValue.GetDoseGy(rx), point1.Volume, point2.Volume, dosePointGy);
                    return volumeAtPoint;
                }

            }
            return double.NaN;
        }

        private static double Interpolate(double x1, double x3, double y1, double y3, double x2)
        {
            return (x2 - x1) * (y3 - y1) / (x3 - x1) + y1;
        }

        public static double TotalPrescribedDoseGy(this IPlanningItem pi)
        {
            Func<IPlanSetup, double> getDoseFromRx = new Func<IPlanSetup, double>(ps =>
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
