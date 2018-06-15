using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.Types;
using static VMS.TPS.Common.Model.Types.DoseValue;

namespace ESAPIX.Helpers.DVH
{
    public class DVHParams
    {
        public DoseValuePresentation DosePresentation { get; set; } = DoseValuePresentation.Absolute;
        public VolumePresentation VolumePresentation { get; set; } = VolumePresentation.Relative;
        public double BinWidth { get; set; } = 1;
        public DoseUnit DoseUnits { get; set; } = DoseUnit.Gy;
    }
}
