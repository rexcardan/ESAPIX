using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Brachy
{
    /// <summary>
    /// Code contributed by Richard Popple, PhD, UAB Medicine
    /// </summary>
    public class Ir192
    {
        public const double HalfLifeDays = 73.827;
        /// <summary>
        /// Calculates the decay factor from the start date to the end date such that if you 
        /// multiply the activity at the end date by the factor, the activity at the start date is
        /// calculated
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static double GetDecayBetweenDates(DateTime startDate, DateTime endDate)
        {
            return Math.Exp(-Math.Log(2) * (endDate - startDate).TotalDays / HalfLifeDays);
        }

        /// <summary>
        /// Computes the anisotropy function using bilinear interpolation from Ir192 source
        /// </summary>
        /// <param name="polar">the polar position of desired calc</param>
        /// <returns>anisotropy factor</returns>
        public static double ComputeAnisotropy(PolarPosition polar)
        {
            return Ir192AnisotropyCalculator.Compute(polar);
        }

        /// <summary>
        /// Computes the anisotropy function using bilinear interpolation from Ir192 source
        /// </summary>
        /// <param name="radialDistanceMm">radial distance in mm</param>
        /// <param name="polarAngle">polar angle</param>
        /// <returns>anisotropy factor</returns>
        public static double ComputeAnisotropy(double radialDistanceMm, double polarAngle)
        {
            var polar = new PolarPosition(radialDistanceMm, polarAngle);
            return Ir192AnisotropyCalculator.Compute(polar);
        }

        /// <summary>
        /// Computes the radial dose function from tabulated data using linear interpolation.
        /// </summary>
        /// <param name="distanceMm">the radial distance from the source in mm</param>
        /// <returns>radial dose factor</returns>
        public static double ComputeRadialDose(double distanceMm)
        {
            return Ir192RadialDoseCalculator.Compute(distanceMm);
        }
    }
}
