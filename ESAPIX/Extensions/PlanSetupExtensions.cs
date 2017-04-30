#region

using System.Linq;
using ESAPIX.Facade.API;
using ESAPIX.Facade.Types;

#endregion

namespace ESAPIX.Extensions
{
    public static class PlanSetupExtensions
    {
        public static bool IsEcomp(this PlanSetup ps)
        {
            return ps.Beams.Any(b => b.MLCPlanType == MLCPlanType.DoseDynamic &&
                                     b.CalculationLogs.Any(c => c.Category == "Compensator"));
        }
    }
}