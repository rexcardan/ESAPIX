using ESAPIX.DVH.Query;
using ESAPIX.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using static ESAPIX.Helpers.MathHelper;

namespace ESAPIX.Extensions
{
    public static class DVHDataExtensions
    {
        /// <summary>
        /// Gets the volume that recieves the input dose
        /// </summary>
        /// <param name="dvh">the dose volume histogram for this structure</param>
        /// <param name="dv">the dose value to sample the curve</param>
        /// <returns>the volume in the same units as the DVH point array</returns>
        public static double GetVolumeAtDose(this DVHPoint[] dvh, DoseValue dv)
        {
            var curve = dvh.Select(d => new { Dose = d.DoseValue.GetDose(dv.Unit), Volume = d.Volume, VolumeUnit = d.VolumeUnit });
            var maxDose = curve.Max(d => d.Dose);
            var minDose = curve.Min(d => d.Dose);

            //If the max dose is less than the queried dose, then there is no volume at the queried dose (out of range)
            //If the min dose is greater than the queried dose, then 100% of the volume is at the queried dose
            if (maxDose < dv.Dose || dv.Dose < minDose)
            {
                return maxDose < dv.Dose ? 0 : dvh.Max(d => d.Volume);
            }
            else
            {
                //If it makes it this far, we will have to interpolate
                var higherPoint = curve.First(p => p.Dose > dv.Dose);
                var lowerPoint = curve.Last(p => p.Dose <= dv.Dose);

                var volumeAtPoint = Interpolate(higherPoint.Dose, lowerPoint.Dose, higherPoint.Volume, lowerPoint.Volume, dv.Dose);
                return volumeAtPoint;
            }
        }

        /// <summary>
        /// Gets the compliment volume (volume about a certain dose point) for the structure dvh
        /// </summary>
        /// <param name="dvh">the dose volume histogram for this structure</param>
        /// <param name="dv">the dose value to sample the curve</param>
        /// <returns></returns>
        public static double GetComplimentVolumeAtDose(this DVHPoint[] dvh, DoseValue dv)
        {
            var maxVol = dvh.Max(d => d.Volume);
            var normalVolume = dvh.GetVolumeAtDose(dv);
            return maxVol - normalVolume;
        }

        /// <summary>
        /// Gets the dose value at the specified volume for the curve
        /// </summary>
        /// <param name="dvh">the dvhPoint array that is queried</param>
        /// <param name="volume">the volume in the same units as the DVH curve</param>
        /// <returns></returns>
        public static DoseValue GetDoseAtVolume(this DVHPoint[] dvh, double volume)
        {
            var minVol = dvh.Min(d => d.Volume);
            var maxVol = dvh.Max(d => d.Volume);

            //Check for max point dose scenario
            if (volume <= minVol) { return dvh.MaxDose(); }

            //Check dose to total volume scenario (min dose)
            if (volume == maxVol)
            {
                return dvh.MinDose();
            }

            //Overvolume scenario, undefined
            if (volume > maxVol)
            {
                return DoseValue.UndefinedDose();
            }

            //Convert to list so we can grab indices
            var dvhList = dvh.ToList();

            //Find the closest point to the requested volume,
            //If its really close, let's use it instead of interpolating
            var minVolumeDiff = dvhList.Min(d => Math.Abs(d.Volume - volume));
            var closestPoint = dvhList.First(d => Math.Abs(d.Volume - volume) == minVolumeDiff);
            if (minVolumeDiff < 0.001) { return closestPoint.DoseValue; }

            else
            {
                //Interpolate
                var index1 = dvhList.IndexOf(closestPoint);
                var index2 = closestPoint.Volume < volume ? index1 - 1 : index1 + 1;

                if (index1 >= 0 && index2 < dvh.Count())
                {
                    var point1 = dvhList[index1];
                    var point2 = dvhList[index2];
                    var doseAtPoint = Interpolate(point1.Volume, point2.Volume, point1.DoseValue.Dose, point2.DoseValue.Dose, volume);
                    return new DoseValue(doseAtPoint, point1.DoseValue.Unit);
                }
                return new DoseValue(double.NaN, closestPoint.DoseValue.Unit);
                throw new Exception(string.Format("Interpolation failed. Index was : {0}, DVH Point Count : {1}, Volume was {2}, ClosestVol was {3}", index1, dvh.Count(), volume, minVolumeDiff));
            }
        }

        /// <summary>
        /// Gets the compliment dose for the specified volume (the cold spot). Calculated by taking the total volume and subtracting the input volume.
        /// </summary>
        /// <param name="dvh">the dvhPoint array that is queried</param>
        /// <param name="volume">the volume in the same units as the DVH curve</param>
        /// <returns>the cold spot dose at the specified volume</returns>
        public static DoseValue GetDoseCompliment(this DVHPoint[] dvh, double volume)
        {
            var maxVol = dvh.Max(d => d.Volume);
            var volOfInterest = maxVol - volume;
            return GetDoseAtVolume(dvh, volOfInterest);
        }

        /// <summary>
        /// Merges DVHData from multiple structures into one DVH by summing the volumes at each dose value
        /// </summary>
        /// <param name="dvhs"></param>
        /// <returns></returns>
        public static DVHPoint[] MergeDVHs(this IEnumerable<DVHData> dvhs)
        {
            return dvhs.Select(d => d.CurveData).MergeDVHs();
        }

        /// <summary>
        /// Merges DVHData from multiple structures into one DVH by summing the volumes at each dose value
        /// </summary>
        /// <param name="dvhs">the multiple dvh curves to merge</param>
        /// <returns>the combined dvh from multiple structures</returns>
        public static DVHPoint[] MergeDVHs(this IEnumerable<DVHPoint[]> dvhs)
        {
            //The merged DVH must be the same length as the maximum length DVH input
            var maxLength = dvhs.Max(d => d.Length);
            var maxDVH = dvhs.First(d => d.Length == maxLength);
            var mergedDVH = maxDVH.Select(d => new DVHPoint(d.DoseValue, 0, d.VolumeUnit)).ToArray();

            //Lets check units before we continue
            var volUnit = dvhs.First().First().VolumeUnit;
            var doseUnit = dvhs.First().First().DoseValue.Unit;

            if (dvhs.Any(d => d.First().DoseValue.Unit != doseUnit)) { throw new ArgumentException("Cannot merge relative DVHs. All DVHs must have the same dose units"); }
            if (dvhs.Any(d => d.First().VolumeUnit != volUnit)) { throw new ArgumentException("Cannot merge relative DVHs. All DVHs must have the same volume units"); }
            if (volUnit == MagicStrings.VolumeUnits.PERCENT) { throw new ArgumentException("Cannot merge relative DVHs. Must be in absolute volume format"); }

            //Everything looks good, let's do it
            foreach (var dvh in dvhs)
            {
                for (int i = 0; i < dvh.Length; i++)
                {
                    var current = dvh[i];
                    mergedDVH[i] = new DVHPoint(current.DoseValue, current.Volume + mergedDVH[i].Volume, current.VolumeUnit);
                }
            }
            return mergedDVH;
        }

        /// <summary>
        /// If appropriate, converts the DVH curve into relative volume points instead of absolute volume
        /// </summary>
        /// <param name="dvh">the input DVH</param>
        /// <returns>the dvh with relative volume points</returns>
        public static DVHPoint[] ConvertToRelativeVolume(this DVHPoint[] dvh)
        {
            var maxVol = dvh.Max(d => d.Volume);

            if (dvh.Any() && dvh.First().VolumeUnit != MagicStrings.VolumeUnits.PERCENT)
            {
                for (int i = 0; i < dvh.Length; i++)
                {
                    dvh[i] = new DVHPoint(dvh[i].DoseValue, 100 * dvh[i].Volume / maxVol, MagicStrings.VolumeUnits.PERCENT);
                }
            }
            return dvh;
        }

        /// <summary>
        /// If appropriate, converts the DVH curve into relative dose points instead of absolute dose
        /// </summary>
        /// <param name="dvh">the input DVH</param>
        /// <param name="scalingPoint">the dose value which represents 100%, all doses will be scaled in reference to this</param>
        /// <returns>the dvh with relative dose points</returns>
        public static DVHPoint[] ConvertToRelativeDose(this DVHPoint[] dvh, DoseValue scalingPoint)
        {
            if (dvh.Any() && dvh.First().DoseValue.Unit == DoseValue.DoseUnit.Percent)
            {
                return dvh; //Already in relative format
            }
            else
            {
                for (int i = 0; i < dvh.Length; i++)
                {
                    var dv = new DoseValue(dvh[i].DoseValue.Divide(scalingPoint).Dose * 100, DoseValue.DoseUnit.Percent);
                    dvh[i] = new DVHPoint(dv, dvh[i].Volume, dvh[i].VolumeUnit);
                }
                return dvh;
            }
        }

        /// <summary>
        /// Returns the max dose from the dvh curve
        /// </summary>
        /// <param name="dvh">the dvh curve</param>
        /// <returns>the max dose in the same units as the curve</returns>
        public static DoseValue MaxDose(this DVHPoint[] dvh)
        {
            if (dvh.Any())
            {
                var unit = dvh.First().DoseValue.Unit;
                var maxVal = dvh.Max(d => d.DoseValue.Dose);
                return new DoseValue(maxVal, unit);
            }
            return DoseValue.UndefinedDose();
        }

        /// <summary>
        /// Returns the min dose from the dvh curve
        /// </summary>
        /// <param name="dvh">the dvh curve</param>
        /// <returns>the minimum dose in the same units as the curve</returns>
        public static DoseValue MinDose(this DVHPoint[] dvh)
        {
            if (dvh.Any())
            {
                var unit = dvh.First().DoseValue.Unit;
                var minVal = dvh.Min(d => d.DoseValue.Dose);
                return new DoseValue(minVal, unit);
            }
            return DoseValue.UndefinedDose();
        }

        /// <summary>
        /// Returns the mean dose from the dvh curve
        /// </summary>
        /// <param name="dvh">the dvh curve</param>
        /// <returns>the mean dose in the same units as the curve</returns>
        public static DoseValue MeanDose(this DVHPoint[] dvh)
        {
            if (dvh.Any())
            {
                var unit = dvh.First().DoseValue.Unit;
                var meanVal = dvh.Average(d => d.DoseValue.Dose);
                return new DoseValue(meanVal, unit);
            }
            return DoseValue.UndefinedDose();
        }

    }
}
