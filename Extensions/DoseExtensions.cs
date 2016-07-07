using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Enums;
using ESAPIX.Types;

namespace ESAPIX.Extensions
{
    public static class DoseExtensions
    {
        public static double GetDoseGy(this DoseValue dv)
        {
            if (dv.Unit == DoseUnit.Gy)
            {
                return dv.Dose;
            }
            else if (dv.Unit == DoseUnit.cGy)
            {
                return dv.Dose / 100;
            }
            else
            {
                return double.NaN;
            }
        }

        public static double GetDoseGy(this DoseValue dv, double prescriptionDoseGy)
        {
            if (dv.Unit == DoseUnit.Gy)
            {
                return dv.Dose;
            }
            else if (dv.Unit == DoseUnit.cGy)
            {
                return dv.Dose / 100;
            }
            else
            {
                return dv.Dose*prescriptionDoseGy;
            }
        }

        public static double GetDose(this DoseValue dv, DoseUnit unit)
        {
            if (dv.Unit == unit)
            {
                return dv.Dose;
            }
            else if (dv.Unit == DoseUnit.cGy && unit == DoseUnit.Gy)
            {
                return dv.Dose / 100;
            }
            else if (dv.Unit == DoseUnit.Gy && unit == DoseUnit.cGy)
            {
                return dv.Dose * 100;
            }
            else
            {
                return double.NaN;
            }
        }

    }
}
