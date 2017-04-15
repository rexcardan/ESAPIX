using ESAPIX.DVH.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;
using ESAPIX.Facade.Types;

namespace ESAPIX.Extensions
{
    /// <summary>
    /// This helps execute Mayo syntax queries against planning items
    /// </summary>
    public static class QueryExtensions
    {
        public static double RunQuery(this MayoQuery query, PlanningItem pi, IEnumerable<Structure> ss)
        {
            var dPres = query.GetDosePresentation();
            var vPres = query.GetVolumePresentation();
            var dvh = pi.GetComplexDVH(ss, vPres, dPres);

            switch (query.QueryType)
            {
                case QueryType.DOSE_AT_VOLUME: return QueryDose(dvh, query);
                case QueryType.DOSE_COMPLIMENT: return QueryDoseCompliment(dvh, query);
                case QueryType.VOLUME_AT_DOSE: return QueryVolume(dvh, query);
                case QueryType.COMPLIMENT_VOLUME: return QueryComplimentVolume(dvh, query);
                case QueryType.MAX_DOSE: return QueryMaxDose(dvh, query);
                case QueryType.MEAN_DOSE: return QueryMeanDose(dvh, query);
                case QueryType.MIN_DOSE: return QueryMinDose(dvh, query);
                default: throw new ArgumentException("Unknown query type!");
            }
        }

        /// <summary>
        /// Returns the dose value presentation for this query, helps in acquiring the correct dvh
        /// </summary>
        /// <param name="query">the mayo query</param>
        /// <returns>the dose value presentation of the query</returns>
        public static DoseValuePresentation GetDosePresentation(this MayoQuery query)
        {
            //If volume query return query unit to dose unit
            if (query.QueryType == QueryType.COMPLIMENT_VOLUME ||
                query.QueryType == QueryType.VOLUME_AT_DOSE)
            {
                switch (query.QueryUnits)
                {
                    case Units.CGY: return DoseValuePresentation.Absolute;
                    case Units.GY: return DoseValuePresentation.Absolute;
                    case Units.PERC: return DoseValuePresentation.Relative;
                    default: throw new ArgumentException("Unknown query type");
                }
            }
            else
            {
                //Dose query, return units desired to dose presentation
                switch (query.UnitsDesired)
                {
                    case Units.CGY: return DoseValuePresentation.Absolute;
                    case Units.GY: return DoseValuePresentation.Absolute;
                    case Units.PERC: return DoseValuePresentation.Relative;
                    default: throw new ArgumentException("Unknown query type");
                }
            }
        }

        /// <summary>
        /// Returns the dose value presentation for this query, helps in acquiring the correct dvh
        /// </summary>
        /// <param name="query">the mayo query</param>
        /// <returns>the dose value presentation of the query</returns>
        public static DoseValue.DoseUnit GetDoseUnit(this MayoQuery query)
        {
            //If volume query return query unit to dose unit
            if (query.QueryType == QueryType.COMPLIMENT_VOLUME ||
                query.QueryType == QueryType.VOLUME_AT_DOSE)
            {
                switch (query.QueryUnits)
                {
                    case Units.CGY: return DoseValue.DoseUnit.cGy;
                    case Units.GY: return DoseValue.DoseUnit.Gy;
                    case Units.PERC: return DoseValue.DoseUnit.Percent;
                    default: return DoseValue.DoseUnit.Unknown;
                }
            }
            else
            {
                //Dose query, return units desired to dose presentation
                switch (query.UnitsDesired)
                {
                    case Units.CGY: return DoseValue.DoseUnit.cGy;
                    case Units.GY: return DoseValue.DoseUnit.Gy;
                    case Units.PERC: return DoseValue.DoseUnit.Percent;
                    default: return DoseValue.DoseUnit.Unknown;
                }
            }
        }

        /// <summary>
        /// Returns the volume presentation for this query, helps in acquiring the correct dvh
        /// </summary>
        /// <param name="query">the mayo query</param>
        /// <returns>the volume presentation of the query</returns>
        public static VolumePresentation GetVolumePresentation(this MayoQuery query)
        {
            //If volume query return units desired to volume unit
            if (query.QueryType == QueryType.COMPLIMENT_VOLUME ||
                query.QueryType == QueryType.VOLUME_AT_DOSE)
            {
                switch (query.UnitsDesired)
                {
                    case Units.CC: return VolumePresentation.AbsoluteCm3;
                    case Units.PERC: return VolumePresentation.Relative;
                    default: throw new ArgumentException("Unknown query type");
                }
            }
            else if (query.QueryType == QueryType.MAX_DOSE || query.QueryType == QueryType.MIN_DOSE ||
                query.QueryType == QueryType.MEAN_DOSE)
            {
                //This is not a volume query, units don't matter. Return default relative
                return VolumePresentation.Relative;
            }
            else
            {
                //Dose query, return query units to volume presentation
                switch (query.QueryUnits)
                {
                    case Units.CC: return VolumePresentation.AbsoluteCm3;
                    case Units.PERC: return VolumePresentation.Relative;
                    default: throw new ArgumentException("Unknown query type");
                }
            }
        }

        private static double QueryDose(DVHPoint[] dvh, MayoQuery query)
        {
            var dose = dvh.GetDoseAtVolume(query.QueryValue);
            var doseUnit = query.GetDoseUnit();
            return dose.GetDose(doseUnit);
        }

        private static double QueryMaxDose(DVHPoint[] dvh, MayoQuery query)
        {
            var max = dvh.MaxDose();
            var doseUnit = query.GetDoseUnit();
            return max.GetDose(doseUnit);
        }

        private static double QueryMinDose(DVHPoint[] dvh, MayoQuery query)
        {
            var min = dvh.MinDose();
            var doseUnit = query.GetDoseUnit();
            return min.GetDose(doseUnit);
        }

        private static double QueryMeanDose(DVHPoint[] dvh, MayoQuery query)
        {
            var mean = dvh.MeanDose();
            var doseUnit = query.GetDoseUnit();
            return mean.GetDose(doseUnit);
        }

        private static double QueryDoseCompliment(DVHPoint[] dvh, MayoQuery query)
        {
            var dose = dvh.GetDoseCompliment(query.QueryValue);
            var doseUnit = query.GetDoseUnit();
            return dose.GetDose(doseUnit);
        }

        private static double QueryVolume(DVHPoint[] dvh, MayoQuery query)
        {
            var doseUnit = query.GetDoseUnit();
            var doseValue = new DoseValue(query.QueryValue, doseUnit);
            return dvh.GetVolumeAtDose(doseValue);
        }

        private static double QueryComplimentVolume(DVHPoint[] dvh, MayoQuery query)
        {
            var doseUnit = query.GetDoseUnit();
            var doseValue = new DoseValue(query.QueryValue, doseUnit);
            return dvh.GetComplimentVolumeAtDose(doseValue);
        }

    }
}
