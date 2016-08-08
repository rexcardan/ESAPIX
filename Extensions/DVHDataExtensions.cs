using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.TPS.Common.Model.Types;
using static ESAPIX.Helpers.MathHelper;

namespace ESAPIX.Extensions
{
    public static class DVHDataExtensions
    {
        /// <summary>
        /// Gets the volume that recieves the input dose
        /// </summary>
        /// <param name="dvh">the dvhPoint array that is queried</param>
        /// <param name="doseGy">the dose at which to find the volume</param>
        /// <returns>the volume in the same units as the DVH point array</returns>
        public static double GetVolumeAtDose(this DVHPoint[] dvh, DoseValue dv)
        {
            var curve = dvh.Select(d => new { Dose = d.DoseValue.Dose, Volume = d.Volume, VolumeUnit = d.VolumeUnit });
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
            if (volume <= minVol) { return dvh.FirstOrDefault(dos => dos.DoseValue.Dose == dvh.Max(d => d.DoseValue.Dose)).DoseValue; }
            var dvhList = dvh.ToList();

            //Check dose to total volume scenario
            if (volume >= maxVol)
            {
                return dvh.First(d => d.Volume == maxVol).DoseValue;
            }

            var minVolumeDiff = dvhList.Min(d => Math.Abs(d.Volume - volume));
            var closestPoint = dvhList.First(d => Math.Abs(d.Volume - volume) == minVolumeDiff);

            if (minVolumeDiff < 0.001) { return closestPoint.DoseValue; }
            else
            {
                //Interpolate
                var index1 = dvhList.IndexOf(closestPoint);
                var index2 = closestPoint.Volume < volume ? index1 - 1 : index1 + 1;

                if (index1 > 0 && index2 < dvh.Count())
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
        /// Gets the coldest dose for the specified volume (the cold spot). Calculated by taking the total volume and subtracting the input volume.
        /// </summary>
        /// <param name="dvh">the dvhPoint array that is queried</param>
        /// <param name="volume">the volume in the same units as the DVH curve</param>
        /// <returns>the cold spot dose at the specified volume</returns>
        public static DoseValue GetColdspot(this DVHPoint[] dvh, double volume)
        {
            var maxVol = dvh.Max(d => d.Volume);
            var volOfInterest = maxVol - volume;
            return GetDoseAtVolume(dvh, volOfInterest);
        }
    }
}
