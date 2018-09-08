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
    public class Ir192RadialDoseCalculator
    {
        // Table 2, Angelopoulos et al. MedPhys v.27, p.2521
        private static double[] radialDoseFunctionTableDistanceCm = new double[] { 0.1, 0.2, 0.3, 0.5, 0.7, 1.0, 1.5, 2.0, 2.5, 3.0, 4.0, 5.0, 6.0, 8.0, 10.0, 12.0, 14.0, 15.0 };
        private static double[] radialDoseFunctionTableValue = new double[] { 0.975,
                0.985,
                0.990,
                0.995,
                0.998,
                1.000,
                1.002,
                1.005,
                1.006,
                1.006,
                1.002,
                0.993,
                0.981,
                0.941,
                0.881,
                0.803,
                0.693,
                0.609 };

        /// <summary>
        /// Computes the radial dose function from tabulated data using linear interpolation.
        /// </summary>
        /// <param name="distanceMm"></param>
        /// <returns></returns>
        public static double Compute(double distanceMm)
        {
            double rCm = distanceMm / 10.0;
            if (rCm < radialDoseFunctionTableDistanceCm[0])
                throw new ArgumentOutOfRangeException("distanceMm", "Distance too small for calculation of radial dose function.");

            int i = 0;
            if (rCm >= radialDoseFunctionTableDistanceCm[radialDoseFunctionTableDistanceCm.Length - 1])
                i = radialDoseFunctionTableDistanceCm.Length - 2;
            else if (rCm > radialDoseFunctionTableDistanceCm[0])
                i = Array.FindLastIndex(radialDoseFunctionTableDistanceCm, r => r < rCm);

            double delta = rCm - radialDoseFunctionTableDistanceCm[i];
            double slope = (radialDoseFunctionTableValue[i + 1] - radialDoseFunctionTableValue[i]) / (radialDoseFunctionTableDistanceCm[i + 1] - radialDoseFunctionTableDistanceCm[i]);
            double result = slope * delta + radialDoseFunctionTableValue[i];

            return (result > 0.0) ? result : 0.0; ;
        }
    }
}
