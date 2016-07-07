using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESAPIX.Enums;

namespace ESAPIX.Types
{
    public struct DoseValue
    {
        public DoseValue(double dose, DoseUnit doseUnit)
        {
            this = new DoseValue();
            Dose = dose;
            Unit = doseUnit;
        }

        public double Dose
        {
            get;
            set;
        }

        public DoseUnit Unit
        {
            get;
            set;
        }

        public string UnitAsString
        {
            get;
            set;
        }
    }
}
