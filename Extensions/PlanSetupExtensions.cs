using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Interfaces;

namespace ESAPIX.Extensions
{
    public static class PlanSetupExtensions
    {
        public static bool IsEcomp(this IPlanSetup ps)
        {
            return ps.Beams.Any(b => b.MLCPlanType == Enums.MLCPlanType.DoseDynamic && b.CalculationLogs.Any(c => c.Category == "Compensator"));
        }
    }
}
