#region

using VMS.TPS.Common.Model.API;
using System;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Extensions
{
    public static class DoseExtensions
    {
        /// <summary>
        ///     Forces the units to be gray. Used for quick comparison
        /// </summary>
        /// <param name="dv">the dose value</param>
        /// <returns>dose in units of gray</returns>
        public static double GetDoseGy(this DoseValue dv)
        {
            return dv.GetDose(DoseValue.DoseUnit.Gy);
        }

        /// <summary>
        ///     Forces the units to be gray, and can convert from prescripting if necessary
        /// </summary>
        /// <param name="dv">the dose value</param>
        /// <param name="prescriptionDoseGy">the prescription dose to use for normalizataion if necessary</param>
        /// <returns>the dose in gray</returns>
        public static double GetDoseGy(this DoseValue dv, double prescriptionDoseGy)
        {
            if (dv.Unit == DoseValue.DoseUnit.Gy)
                return dv.Dose;
            if (dv.Unit == DoseValue.DoseUnit.cGy)
                return dv.Dose / 100;
            return dv.Dose * prescriptionDoseGy;
        }

        /// <summary>
        ///     Forces the units to be centigray. Used for quick comparison
        /// </summary>
        /// <param name="dv">the dose value</param>
        /// <returns>dose in units of centigray</returns>
        public static double GetDoseCGy(this DoseValue dv)
        {
            return dv.GetDose(DoseValue.DoseUnit.cGy);
        }

        /// <summary>
        ///     Converts the units of the dose into dose value presentation
        /// </summary>
        /// <param name="dv">the current dose value</param>
        /// <returns>the dose value presentation corresponding to the units of the input dose</returns>
        public static DoseValuePresentation GetPresentation(this DoseValue dv)
        {
            if (dv.Unit == DoseValue.DoseUnit.Percent)
                return DoseValuePresentation.Relative;
            return DoseValuePresentation.Absolute;
        }

        /// <summary>
        ///     Converts the dose to the unit requested. It cannot convert from % to abs dose. Will return NaN if asked
        /// </summary>
        /// <param name="dv">the dose value to be converted</param>
        /// <param name="unit">the unit desired for the returned dose</param>
        /// <returns>the dose in the desired units</returns>
        public static double GetDose(this DoseValue dv, DoseValue.DoseUnit unit)
        {
            if (dv.Unit == unit)
                return dv.Dose;
            if (dv.Unit == DoseValue.DoseUnit.cGy && unit == DoseValue.DoseUnit.Gy)
                return dv.Dose / 100;
            if (dv.Unit == DoseValue.DoseUnit.Gy && unit == DoseValue.DoseUnit.cGy)
                return dv.Dose * 100;
            return double.NaN;
        }

        /// <summary>
        /// Converts the dose to the unit requested. It cannot convert from % to abs dose. Will return NaN if asked
        /// </summary>
        /// <param name="dv">the dose value to be converted</param>
        /// <param name="unit">the unit desired for the returned dose</param>
        /// <returns>the dose in the desired units</returns>
        public static DoseValue ConvertUnits(this DoseValue dv, DoseValue.DoseUnit unit)
        {
            var dose = dv.GetDose(unit);
            return new DoseValue(dose, unit);
        }

        /// <summary>
        /// Converts the dose to the system units. It cannot convert from % to abs dose. Will return NaN if asked
        /// </summary>
        /// <param name="dv">the dose value to be converted</param>
        /// <param name="unit">the unit desired for the returned dose</param>
        /// <returns>the dose in the desired units</returns>
        public static DoseValue ConvertToSystemUnits(this DoseValue dv, PlanningItem pi)
        {
            var newDv = new DoseValue(dv.Dose, dv.Unit);
            if (dv.GetPresentation() != DoseValuePresentation.Relative)
            {
                // Need to convert to system units first (ugh!)
                var oldPresentation = pi.DoseValuePresentation;
                pi.DoseValuePresentation = DoseValuePresentation.Absolute;
                if (pi?.Dose != null)
                {
                    var systemUnits = pi.Dose.DoseMax3D.Unit;
                    pi.DoseValuePresentation = oldPresentation;
                    //Thanks ESAPIX!
                    newDv = dv.ConvertUnits(systemUnits);
                }
                else
                {
                    throw new Exception("Cannot determine system units for dose. Plan dose is null");
                }
            }
            return newDv;
        }

        /// <summary>
        /// Converts the dose to the system units. It cannot convert from % to abs dose. Will return NaN if asked
        /// </summary>
        /// <param name="dv">the dose value to be converted</param>
        /// <param name="unit">the unit desired for the returned dose</param>
        /// <returns>the dose in the desired units</returns>
        public static DoseValue ConvertToSystemUnits(this DoseValue dv, ESAPIX.Facade.API.PlanningItem pi)
        {
            var newDv = new DoseValue(dv.Dose, dv.Unit);
            if (dv.GetPresentation() != DoseValuePresentation.Relative)
            {
                // Need to convert to system units first (ugh!)
                var oldPresentation = pi.DoseValuePresentation;
                pi.DoseValuePresentation = DoseValuePresentation.Absolute;
                if (pi?.Dose != null)
                {
                    var systemUnits = pi.Dose.DoseMax3D.Unit;
                    pi.DoseValuePresentation = oldPresentation;
                    //Thanks ESAPIX!
                    newDv = dv.ConvertUnits(systemUnits);
                }
                else
                {
                    throw new Exception("Cannot determine system units for dose. Plan dose is null");
                }
            }
            return newDv;
        }

        #region COMPARISONS

        /// <summary>
        ///     Returns true if value is less than or equal to input value
        /// </summary>
        /// <param name="dv">the first dose value</param>
        /// <param name="dv2">the second dose value</param>
        /// <returns>Returns true if value is less than or equal to input value</returns>
        public static bool LessThanOrEqualTo(this DoseValue dv, DoseValue dv2)
        {
            return DoseValueComparer(dv, dv2, (v1, v2) => v1 < v2 || Math.Abs(v1 - v2) < 0.0001);
        }

        /// <summary>
        ///     Returns true if value is less than input value
        /// </summary>
        /// <param name="dv">the first dose value</param>
        /// <param name="dv2">the second dose value</param>
        /// <returns>Returns true if value is less than input value</returns>
        public static bool LessThan(this DoseValue dv, DoseValue dv2)
        {
            return DoseValueComparer(dv, dv2, (v1, v2) => v1 < v2);
        }

        /// <summary>
        ///     Returns true if value is greater than input value
        /// </summary>
        /// <param name="dv">the first dose value</param>
        /// <param name="dv2">the second dose value</param>
        /// <returns>Returns true if value is greater than input value</returns>
        public static bool GreaterThan(this DoseValue dv, DoseValue dv2)
        {
            return DoseValueComparer(dv, dv2, (v1, v2) => v1 > v2);
        }

        /// <summary>
        ///     Returns true if value is greater than or equal to input value
        /// </summary>
        /// <param name="dv">the first dose value</param>
        /// <param name="dv2">the second dose value</param>
        /// <returns>Returns true if value is greater than or equal to input value</returns>
        public static bool GreaterThanOrEqualTo(this DoseValue dv, DoseValue dv2)
        {
            return DoseValueComparer(dv, dv2, (v1, v2) => v1 > v2 || Math.Abs(v1 - v2) < 0.0001);
        }

        /// <summary>
        ///     Used as the backing method for the comparision methods
        /// </summary>
        /// <param name="dv">the first dose value</param>
        /// <param name="dv2">the second dose value</param>
        /// <param name="comparer">the test to perform between the two values</param>
        /// <returns>the result of the input comparison</returns>
        private static bool DoseValueComparer(DoseValue dv, DoseValue dv2, Func<double, double, bool> comparer)
        {
            if (dv.Unit == DoseValue.DoseUnit.Percent && dv2.Unit != DoseValue.DoseUnit.Percent ||
                dv.Unit != DoseValue.DoseUnit.Percent && dv2.Unit == DoseValue.DoseUnit.Percent)
                throw new ArgumentException("Dose units are not the same - Can't compare!");

            if (dv.Unit == dv2.Unit) return comparer.Invoke(dv.Dose, dv2.Dose);
            return comparer.Invoke(dv.GetDoseGy(), dv2.GetDoseGy());
        }

        #endregion

        #region

        public static DoseValue Divide(this DoseValue numerator, DoseValue denominator)
        {
            var sameUnit = denominator.GetDose(numerator.Unit);
            var mathOp = numerator.Dose / sameUnit;
            return new DoseValue(mathOp, numerator.Unit);
        }

        public static DoseValue Multiply(this DoseValue val, DoseValue val2)
        {
            var sameUnit = val2.GetDose(val.Unit);
            var mathOp = val.Dose * sameUnit;
            return new DoseValue(mathOp, val.Unit);
        }

        #endregion
    }
}