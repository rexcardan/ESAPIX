#region

using ESAPIX.Constraints;
using ESAPIX.Constraints.DVH;
using ESAPIX.Constraints.DVH.Query;
using VMS.TPS.Common.Model.Types;
using static VMS.TPS.Common.Model.Types.DoseValue;

#endregion

namespace ESAPIX.DVH
{
    /// <summary>
    ///     Converts a Mayo constraint type to a DVH Constraint class
    /// </summary>
    public static class MayoConstraintConverter
    {
        public static IConstraint ConvertToDVHConstraint(string structureName, PriorityType priority, MayoConstraint mc)
        {
            IConstraint c = null;
            switch (mc.Query.QueryType)
            {
                case QueryType.MAX_DOSE:
                    BuildMaxDoseConstraint(mc, structureName, priority, out c);
                    break;
                case QueryType.MIN_DOSE:
                    BuildMinDoseConstraint(mc, structureName, priority, out c);
                    break;
                case QueryType.MEAN_DOSE:
                    BuildMeanDoseConstraint(mc, structureName, priority, out c);
                    break;
                case QueryType.DOSE_AT_VOLUME:
                    BuildDoseAtVolumeConstraint(mc, structureName, priority, out c);
                    break;
                case QueryType.VOLUME_AT_DOSE:
                    BuildVolumeAtDoseConstraint(mc, structureName, priority, out c);
                    break;
                case QueryType.DOSE_COMPLEMENT:
                    BuildDoseComplementConstraint(mc, structureName, priority, out c);
                    break;
                case QueryType.COMPLEMENT_VOLUME:
                    BuildComplementVolumeConstraint(mc, structureName, priority, out c);
                    break;
            }
            return c;
        }

        private static VolumePresentation GetVolumeUnits(Units mayoUnit)
        {
            switch (mayoUnit)
            {
                case Units.CC: return VolumePresentation.AbsoluteCm3;
                case Units.PERC: return VolumePresentation.Relative;
                default: return VolumePresentation.Relative;
            }
        }

        private static DoseUnit GetDoseUnits(Units mayoUnit)
        {
            switch (mayoUnit)
            {
                case Units.CGY: return DoseUnit.cGy;
                case Units.GY: return DoseUnit.Gy;
                case Units.PERC: return DoseUnit.Percent;
                default: return DoseUnit.Unknown;
            }
        }

        #region BUILDERS

        private static void BuildMaxDoseConstraint(MayoConstraint mc, string structureName, PriorityType priority,
            out IConstraint c)
        {
            var doseUnit = GetDoseUnits(mc.Query.UnitsDesired);
            var dose = mc.ConstraintValue;
            var dv = new DoseValue(dose, doseUnit);
            c = new MaxDoseConstraint {ConstraintDose = dv, StructureName = structureName, Priority = priority};
        }

        private static void BuildMinDoseConstraint(MayoConstraint mc, string structureName, PriorityType priority,
            out IConstraint c)
        {
            var doseUnit = GetDoseUnits(mc.Query.UnitsDesired);
            var dose = mc.ConstraintValue;
            var dv = new DoseValue(dose, doseUnit);
            c = new MinDoseConstraint {ConstraintDose = dv, StructureName = structureName, Priority = priority};
        }

        private static void BuildDoseAtVolumeConstraint(MayoConstraint mc, string structureName, PriorityType priority,
            out IConstraint c)
        {
            var volume = mc.Query.QueryValue;
            var volumeUnit = GetVolumeUnits(mc.Query.QueryUnits);
            var doseUnit = GetDoseUnits(mc.Query.UnitsDesired);
            var dose = mc.ConstraintValue;
            var dv = new DoseValue(dose, doseUnit);
            switch (mc.Discriminator)
            {
                case Discriminator.EQUAL:
                case Discriminator.GREATER_THAN:
                case Discriminator.GREATHER_THAN_OR_EQUAL:
                    c = new MinDoseAtVolConstraint
                    {
                        ConstraintDose = dv,
                        Priority = priority,
                        StructureName = structureName,
                        Volume = volume,
                        VolumeType = volumeUnit
                    };
                    break;
                case Discriminator.LESS_THAN:
                case Discriminator.LESS_THAN_OR_EQUAL:
                    c = new MaxDoseAtVolConstraint
                    {
                        ConstraintDose = dv,
                        Priority = priority,
                        StructureName = structureName,
                        Volume = volume,
                        VolumeType = volumeUnit
                    };
                    break;
                default:
                    c = null;
                    break;
            }
        }

        private static void BuildMeanDoseConstraint(MayoConstraint mc, string structureName, PriorityType priority,
            out IConstraint c)
        {
            var doseUnit = GetDoseUnits(mc.Query.UnitsDesired);
            var dose = mc.ConstraintValue;
            var dv = new DoseValue(dose, doseUnit);
            switch (mc.Discriminator)
            {
                case Discriminator.EQUAL:
                case Discriminator.GREATER_THAN:
                case Discriminator.GREATHER_THAN_OR_EQUAL:
                    c = new MinMeanDoseConstraint
                    {
                        ConstraintDose = dv,
                        StructureName = structureName,
                        Priority = priority
                    };
                    break;
                case Discriminator.LESS_THAN:
                case Discriminator.LESS_THAN_OR_EQUAL:
                    c = new MaxMeanDoseConstraint
                    {
                        ConstraintDose = dv,
                        StructureName = structureName,
                        Priority = priority
                    };
                    break;
                default:
                    c = null;
                    break;
            }
        }

        private static void BuildComplementVolumeConstraint(MayoConstraint mc, string structureName,
            PriorityType priority, out IConstraint c)
        {
            var dose = mc.Query.QueryValue;
            var doseUnit = GetDoseUnits(mc.Query.QueryUnits);
            var volumeUnit = GetVolumeUnits(mc.Query.UnitsDesired);
            var volume = mc.ConstraintValue;
            var dv = new DoseValue(dose, doseUnit);
            switch (mc.Discriminator)
            {
                case Discriminator.EQUAL:
                case Discriminator.GREATER_THAN:
                case Discriminator.GREATHER_THAN_OR_EQUAL:
                    c = new MinComplementVolumeAtDose
                    {
                        ConstraintDose = dv,
                        Priority = priority,
                        StructureName = structureName,
                        Volume = volume,
                        VolumeType = volumeUnit
                    };
                    break;
                case Discriminator.LESS_THAN:
                case Discriminator.LESS_THAN_OR_EQUAL:
                    c = new MaxComplementVolumeAtDose
                    {
                        ConstraintDose = dv,
                        Priority = priority,
                        StructureName = structureName,
                        Volume = volume,
                        VolumeType = volumeUnit
                    };
                    break;
                default:
                    c = null;
                    break;
            }
        }

        private static void BuildDoseComplementConstraint(MayoConstraint mc, string structureName,
            PriorityType priority, out IConstraint c)
        {
            var volume = mc.Query.QueryValue;
            var volumeUnit = GetVolumeUnits(mc.Query.QueryUnits);
            var doseUnit = GetDoseUnits(mc.Query.UnitsDesired);
            var dose = mc.ConstraintValue;
            var dv = new DoseValue(dose, doseUnit);
            switch (mc.Discriminator)
            {
                case Discriminator.EQUAL:
                case Discriminator.GREATER_THAN:
                case Discriminator.GREATHER_THAN_OR_EQUAL:
                    c = new MinComplementDoseAtVolumeConstraint
                    {
                        ConstraintDose = dv,
                        Priority = priority,
                        StructureName = structureName,
                        Volume = volume,
                        VolumeType = volumeUnit
                    };
                    break;
                case Discriminator.LESS_THAN:
                case Discriminator.LESS_THAN_OR_EQUAL:
                    c = new MaxComplementDoseAtVolumeConstraint
                    {
                        ConstraintDose = dv,
                        Priority = priority,
                        StructureName = structureName,
                        Volume = volume,
                        VolumeType = volumeUnit
                    };
                    break;
                default:
                    c = null;
                    break;
            }
        }

        private static void BuildVolumeAtDoseConstraint(MayoConstraint mc, string structureName, PriorityType priority,
            out IConstraint c)
        {
            var dose = mc.Query.QueryValue;
            var doseUnit = GetDoseUnits(mc.Query.QueryUnits);
            var volumeUnit = GetVolumeUnits(mc.Query.UnitsDesired);
            var volume = mc.ConstraintValue;
            var dv = new DoseValue(dose, doseUnit);
            switch (mc.Discriminator)
            {
                case Discriminator.EQUAL:
                case Discriminator.GREATER_THAN:
                case Discriminator.GREATHER_THAN_OR_EQUAL:
                    c = new MinVolAtDoseConstraint
                    {
                        ConstraintDose = dv,
                        Priority = priority,
                        StructureName = structureName,
                        Volume = volume,
                        VolumeType = volumeUnit
                    };
                    break;
                case Discriminator.LESS_THAN:
                case Discriminator.LESS_THAN_OR_EQUAL:
                    c = new MaxVolAtDoseConstraint
                    {
                        ConstraintDose = dv,
                        Priority = priority,
                        StructureName = structureName,
                        Volume = volume,
                        VolumeType = volumeUnit
                    };
                    break;
                default:
                    c = null;
                    break;
            }
        }

        #endregion
    }
}