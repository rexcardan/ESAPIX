#region

using ESAPIX.Constraints;
using ESAPIX.Constraints.DVH;
using System.Collections.Generic;
using System.Linq;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

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


        public static int? NumberOfFractions(this PlanSetup ps)
        {
#if (VMS110 || VMS136 || VMS137)
            return ps.UniqueFractionation?.NumberOfFractions;

#else        
            return ps.NumberOfFractions;
#endif
        }

#if (!VMS110 && !VMS136 && !VMS137 && !VMS150)
        public static (List<ProtocolPhasePrescription> rxs, List<ProtocolPhaseMeasure> measures) GetProtocolPrescriptionsAndMeasures(this PlanSetup ps)
        {
            List<ProtocolPhasePrescription> rxs = new List<ProtocolPhasePrescription>();
            List<ProtocolPhaseMeasure> measures = new List<ProtocolPhaseMeasure>();
            ps.GetProtocolPrescriptionsAndMeasures(ref rxs, ref measures);
            return (rxs, measures);
        }

        public static List<DoseStructureConstraint> GetConstraints(this PlanSetup ps)
        {
            List<ProtocolPhasePrescription> rxs = new List<ProtocolPhasePrescription>();
            List<ProtocolPhaseMeasure> measures = new List<ProtocolPhaseMeasure>();
            ps.GetProtocolPrescriptionsAndMeasures(ref rxs, ref measures);
            return rxs.Select(r => r.ToConstraint()).ToList();
        }
#endif
    }
}