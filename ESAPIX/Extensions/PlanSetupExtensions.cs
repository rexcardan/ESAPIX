#region

using ESAPIX.Constraints;
using ESAPIX.Constraints.DVH;
using ESAPIX.Constraints.DVH.Query;
using System.Collections.Generic;
using System.Linq;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Extensions
{
    public static class PlanSetupExtensions
    {
        public static bool IsEcomp(this ExternalPlanSetup ps)
        {
            return ps.Beams.Any(b => b.MLCPlanType == MLCPlanType.DoseDynamic &&
                                     b.CalculationLogs.Any(c => c.Category == "Compensator"));
        }

        public static bool AddObjective(this PlanSetup ps, string structureId, string mayoObjective, double priority)
        {
            var str = ps.GetStructure(structureId);
            if (str == null) { return false; }

            var query = MayoConstraint.Read(mayoObjective);
            switch (query.Query.QueryType)
            {
                case QueryType.MEAN_DOSE:
                    var meanConstraint = (DoseStructureConstraint)query.ToDVHConstraint(structureId, PriorityType.PRIORITY_3);
                    ps.OptimizationSetup.AddMeanDoseObjective(str, meanConstraint.ConstraintDose, priority);
                    return true;
                case QueryType.MAX_DOSE:
                    var maxDose = (DoseStructureConstraint)query.ToDVHConstraint(structureId, PriorityType.PRIORITY_3);
                    ps.OptimizationSetup.AddPointObjective(str, OptimizationObjectiveOperator.Upper, maxDose.ConstraintDose, 0, priority);
                    return true;
                case QueryType.MIN_DOSE:
                    var minDose = (DoseStructureConstraint)query.ToDVHConstraint(structureId, PriorityType.PRIORITY_3);
                    ps.OptimizationSetup.AddPointObjective(str, OptimizationObjectiveOperator.Lower, minDose.ConstraintDose, 100, priority);
                    return true;
                case QueryType.DOSE_AT_VOLUME:
                    var doseAtVolume = (DoseAtVolumeConstraint)query.ToDVHConstraint(structureId, PriorityType.PRIORITY_3);
                    OptimizationObjectiveOperator direction = (query.Discriminator == Discriminator.LESS_THAN ||
                         query.Discriminator == Discriminator.LESS_THAN_OR_EQUAL) ? OptimizationObjectiveOperator.Upper :
                         (query.Discriminator == Discriminator.GREATER_THAN ||
                         query.Discriminator == Discriminator.GREATER_THAN_OR_EQUAL) ? OptimizationObjectiveOperator.Lower : OptimizationObjectiveOperator.Exact;
                    ps.OptimizationSetup.AddPointObjective(str, direction, doseAtVolume.ConstraintDose, doseAtVolume.Volume, priority);
                    return true;
                case QueryType.VOLUME_AT_DOSE:
                    var volAtDose = (VolumeAtDoseConstraint)query.ToDVHConstraint(structureId, PriorityType.PRIORITY_3);
                    direction = (query.Discriminator == Discriminator.LESS_THAN ||
                         query.Discriminator == Discriminator.LESS_THAN_OR_EQUAL) ? OptimizationObjectiveOperator.Upper :
                         (query.Discriminator == Discriminator.GREATER_THAN ||
                         query.Discriminator == Discriminator.GREATER_THAN_OR_EQUAL) ? OptimizationObjectiveOperator.Lower : OptimizationObjectiveOperator.Exact;
                    ps.OptimizationSetup.AddPointObjective(str, direction, volAtDose.ConstraintDose, volAtDose.Volume, priority);
                    return true;
            }
            return false;
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