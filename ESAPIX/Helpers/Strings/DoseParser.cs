using ESAPIX.Constraints.DVH.Query;
using ESAPIX.DVH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.Helpers.Strings
{
    public class DoseParser
    {
        public static DoseValue Parse(string dose)
        {
            var value = MayoQueryReader.ReadQueryValue(dose);
            var units = MayoQueryReader.ReadQueryUnits(dose);
            var doseUnits = MayoConstraintConverter.GetDoseUnits(units);
            return new DoseValue(value, doseUnits);
        }
    }
}
