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
    public class Ir192AnisotropyCalculator
    {
        // Table 3, Angelopoulos et al. MedPhys v.27, p.2521
        private static double[] anisotropyFunctionTableRadialDistanceCm = new double[] { 0.25, 0.5, 1, 3, 5, 7, 10, 12, 15 };
        private static double[] anisotropyFunctionTablePolarAngleDeg = new double[] { 179.5,
                178.5,
                177.5,
                176.5,
                175.5,
                174.5,
                172.5,
                170.5,
                167.5,
                165.5,
                160.5,
                150.5,
                140.5,
                130.5,
                110.5,
                90.5,
                70.5 ,
                50.5,
                40.5,
                30.5,
                20.5,
                15.5,
                12.5,
                10.5,
                7.5,
                6.5,
                5.5,
                4.5 ,
                3.5 ,
                2.5,
                1.5 };
        private static double[,] anisotropyFunctionTableValue = new double[,] { { Double.NaN, 0.564, 0.530, 0.550, 0.616, 0.663, 0.720, 0.736, 0.728 },
                { Double.NaN, 0.574, 0.538, 0.581, 0.642, 0.685, 0.727, 0.748, 0.756 },
                { Double.NaN, 0.588, 0.557, 0.601, 0.657, 0.697, 0.746, 0.760, 0.773 },
                { Double.NaN, 0.620, 0.591, 0.634, 0.687, 0.722, 0.762, 0.777, 0.787 },
                { Double.NaN, 0.646, 0.624, 0.663, 0.706, 0.736 ,0.778, 0.790, 0.796 },
                { Double.NaN, 0.675, 0.653, 0.690, 0.730, 0.762, 0.794, 0.805, 0.813 },
                { 0.849, 0.736, 0.721, 0.745, 0.773, 0.802, 0.824, 0.831, 0.836 },
                { 0.880, 0.787, 0.766, 0.779, 0.808, 0.827, 0.847, 0.853, 0.860 },
                { 0.910, 0.837, 0.816, 0.821, 0.841, 0.856, 0.876, 0.882, 0.883 },
                { 0.925, 0.859, 0.843, 0.845, 0.859, 0.872, 0.884, 0.889, 0.894 },
                { 0.948, 0.905, 0.890, 0.889, 0.901, 0.907, 0.915, 0.916, 0.918 },
                { 0.968, 0.949, 0.940, 0.938, 0.943, 0.945, 0.948, 0.952, 0.951 },
                { 0.983, 0.970, 0.966, 0.965, 0.968, 0.968, 0.971, 0.970, 0.972 },
                { 0.989, 0.985, 0.982, 0.983, 0.982, 0.983, 0.985, 0.984, 0.984 },
                { 0.999, 0.998, 0.996, 0.997, 0.995, 0.996, 0.996, 0.995, 0.997 },
                { 0.999, 1.000, 1.001, 0.999, 1.002, 1.002, 1.000, 1.000, 0.999 },
                { 0.998, 0.995, 0.995, 0.995, 0.998, 0.997, 0.995, 0.996, 0.998 },
                { 0.990, 0.986, 0.982, 0.984, 0.985, 0.983, 0.982, 0.984, 0.984 },
                { 0.982, 0.972, 0.968, 0.968, 0.969, 0.969, 0.971, 0.971, 0.971  },
                { 0.970, 0.952, 0.945, 0.941, 0.947, 0.949, 0.952, 0.952, 0.953  },
                { 0.950, 0.910, 0.894, 0.896, 0.902, 0.910, 0.918, 0.922, 0.922  },
                { 0.929, 0.871, 0.854, 0.856, 0.868, 0.880, 0.895, 0.898, 0.897  },
                { 0.911, 0.836, 0.816, 0.827, 0.843, 0.857, 0.874, 0.875, 0.879 },
                { 0.891, 0.807, 0.784, 0.793, 0.814, 0.832, 0.848, 0.860, 0.859 },
                { 0.844, 0.741, 0.711, 0.725, 0.762, 0.789, 0.808, 0.825, 0.829 },
                { Double.NaN, 0.702, 0.677, 0.706, 0.741, 0.769, 0.802, 0.810, 0.819 },
                { Double.NaN, 0.670, 0.641, 0.671, 0.716, 0.747, 0.778, 0.789, 0.798 },
                { Double.NaN, 0.627, 0.594, 0.632, 0.685, 0.718, 0.756, 0.772, 0.782 },
                { Double.NaN, Double.NaN, 0.549, 0.593, 0.646, 0.687, 0.731, 0.753, 0.771 },
                { Double.NaN, Double.NaN, Double.NaN, 0.544, 0.611, 0.652, 0.710, 0.730, 0.736 },
                { Double.NaN, Double.NaN, Double.NaN, 0.460, 0.544, 0.596, 0.661, 0.684, 0.711 } };
        private static bool areTablesPopulated = false;
        /// <summary>
        /// Computes the anisotropy function using bilinear interpolation.
        /// </summary>
        /// <param name="radialDistanceMm"></param>
        /// <param name="polarAngle"></param>
        /// <returns></returns>
        public static double Compute(PolarPosition polar)
        {
            if (!areTablesPopulated) PopulateTable();

            double rCm = polar.Distance_mm / 10.0;
            double angleDeg = 180.0 * polar.Angle_rad / Math.PI;

            if (rCm < anisotropyFunctionTableRadialDistanceCm[0] || rCm >= anisotropyFunctionTableRadialDistanceCm[anisotropyFunctionTableRadialDistanceCm.Length - 1])
                throw new ArgumentOutOfRangeException("radialDistanceMm", "Distance is not within range of the anisotropy function table.");

            if (angleDeg < 0.0 || angleDeg > 180.0)
                throw new ArgumentOutOfRangeException("polarAngle", "Invalid polar angle - polar angle must be in range 0-180 degrees.");

            int j = 0;
            if (rCm >= anisotropyFunctionTableRadialDistanceCm[anisotropyFunctionTableRadialDistanceCm.Length - 1])
                j = anisotropyFunctionTableRadialDistanceCm.Length - 2;
            else if (rCm > anisotropyFunctionTableRadialDistanceCm[0])
                j = Array.FindLastIndex(anisotropyFunctionTableRadialDistanceCm, r => r < rCm);

            int i = 0;
            if (angleDeg >= anisotropyFunctionTablePolarAngleDeg[anisotropyFunctionTablePolarAngleDeg.Length - 1])
                i = anisotropyFunctionTablePolarAngleDeg.Length - 2;
            else if (angleDeg > anisotropyFunctionTablePolarAngleDeg[0])
                i = Array.FindLastIndex(anisotropyFunctionTablePolarAngleDeg, a => a < angleDeg);

            if (Double.IsNaN(anisotropyFunctionTableValue[i, j]) || Double.IsNaN(anisotropyFunctionTableValue[i, j + 1]) || Double.IsNaN(anisotropyFunctionTableValue[i + 1, j]) || Double.IsNaN(anisotropyFunctionTableValue[i + 1, j + 1]))
                throw new ArgumentOutOfRangeException("radialDistanceMm", "Interpolation of anisotropy function requires data points that are not defined - calculation point is inside the source.");

            double delta = rCm - anisotropyFunctionTableRadialDistanceCm[j];
            double slope = (anisotropyFunctionTableValue[i, j + 1] - anisotropyFunctionTableValue[i, j]) / (anisotropyFunctionTableRadialDistanceCm[j + 1] - anisotropyFunctionTableRadialDistanceCm[j]);
            double result1 = slope * delta + anisotropyFunctionTableValue[i, j];

            delta = rCm - anisotropyFunctionTableRadialDistanceCm[j];
            slope = (anisotropyFunctionTableValue[i + 1, j + 1] - anisotropyFunctionTableValue[i + 1, j]) / (anisotropyFunctionTableRadialDistanceCm[j + 1] - anisotropyFunctionTableRadialDistanceCm[j]);
            double result2 = slope * delta + anisotropyFunctionTableValue[i + 1, j];

            delta = angleDeg - anisotropyFunctionTablePolarAngleDeg[i];
            slope = (result2 - result1) / (anisotropyFunctionTablePolarAngleDeg[i + 1] - anisotropyFunctionTablePolarAngleDeg[i]);
            double result = slope * delta + result1;

            return result;
        }

        private static void PopulateTable()
        {
            // Definition of polar angle in Angelopoulos et al. is complementary to the source orientation in Eclipse
            for (int i = 0; i < anisotropyFunctionTablePolarAngleDeg.Length; i++)
                anisotropyFunctionTablePolarAngleDeg[i] = 180.0 - anisotropyFunctionTablePolarAngleDeg[i];
            areTablesPopulated = true;
        }
    }
}
