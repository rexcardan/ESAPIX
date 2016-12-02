using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Interfaces;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.Extensions
{
    public static class PlanSetupExtensions
    {
        public static bool IsEcomp(this PlanSetup ps)
        {
            return ps.Beams.Any(b => b.MLCPlanType == MLCPlanType.DoseDynamic && b.CalculationLogs.Any(c => c.Category == "Compensator"));
        }
    }
}
