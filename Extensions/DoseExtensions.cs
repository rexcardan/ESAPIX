using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.Extensions
{
    public static class DoseExtensions
    {
        public static double GetDoseGy(this DoseValue dv)
        {
            if (dv.Unit == DoseValue.DoseUnit.Gy)
            {
                return dv.Dose;
            }
            else if (dv.Unit == DoseValue.DoseUnit.cGy)
            {
                return dv.Dose / 100;
            }
            else
            {
                return double.NaN;
            }
        }

        public static DoseValuePresentation GetPresentation(this DoseValue dv)
        {
            if (dv.Unit == DoseValue.DoseUnit.Percent)
            {
                return DoseValuePresentation.Relative;
            }
            return DoseValuePresentation.Absolute; 
        }

        public static double GetDoseGy(this DoseValue dv, double prescriptionDoseGy)
        {
            if (dv.Unit == DoseValue.DoseUnit.Gy)
            {
                return dv.Dose;
            }
            else if (dv.Unit == DoseValue.DoseUnit.cGy)
            {
                return dv.Dose / 100;
            }
            else
            {
                return dv.Dose*prescriptionDoseGy;
            }
        }

        public static double GetDose(this DoseValue dv, DoseValue.DoseUnit unit)
        {
            if (dv.Unit == unit)
            {
                return dv.Dose;
            }
            else if (dv.Unit == DoseValue.DoseUnit.cGy && unit == DoseValue.DoseUnit.Gy)
            {
                return dv.Dose / 100;
            }
            else if (dv.Unit == DoseValue.DoseUnit.Gy && unit == DoseValue.DoseUnit.cGy)
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
