#region

using System.Linq;
using ESAPIX.Facade.API;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Extensions
{
    public static class FPlanSetupExtensions
    {
        public static bool IsEcomp(this PlanSetup ps)
        {
            return ps.Beams.Any(b => b.MLCPlanType == MLCPlanType.DoseDynamic &&
                                     b.CalculationLogs.Any(c => c.Category == "Compensator"));
        }


        public static int? NumberOfFractions(this PlanSetup ps)
        {
#if (VMS110 || VMS136 || VMS137)
            return ps.UniqueFractionation?.NumberOfFractions;

#else        
            return ps.NumberOfFractions;
#endif
        }

    }
}