#region

using System;
using System.Collections.Generic;
using ESAPIX.Constraints.DVH.Query;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Extensions
{
    /// <summary>
    ///     This helps execute Mayo syntax queries against planning items
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
                case QueryType.DOSE_COMPLEMENT: return QueryDoseComplement(dvh, query);
                case QueryType.VOLUME_AT_DOSE: return QueryVolume(dvh, query);
                case QueryType.COMPLEMENT_VOLUME: return QueryComplementVolume(dvh, query);
                case QueryType.MAX_DOSE: return QueryMaxDose(dvh, query);
                case QueryType.MEAN_DOSE: return QueryMeanDose(dvh, query);
                case QueryType.MIN_DOSE: return QueryMinDose(dvh, query);
                default: throw new ArgumentException("Unknown query type!");
            }
        }

        /// <summary>
        ///     Returns the dose value presentation for this query, helps in acquiring the correct dvh
        /// </summary>
        /// <param name="query">the mayo query</param>
        /// <returns>the dose value presentation of the query</returns>
        public static DoseValuePresentation GetDosePresentation(this MayoQuery query)
        {
            //If volume query return query unit to dose unit
            if (query.QueryType == QueryType.COMPLEMENT_VOLUME ||
                query.QueryType == QueryType.VOLUME_AT_DOSE)
                switch (query.QueryUnits)
                {
                    case Units.CGY: return DoseValuePresentation.Absolute;
                    case Units.GY: return DoseValuePresentation.Absolute;
                    case Units.PERC: return DoseValuePresentation.Relative;
                    default: throw new ArgumentException("Unknown query type");
                }
            switch (query.UnitsDesired)
            {
                case Units.CGY: return DoseValuePresentation.Absolute;
                case Units.GY: return DoseValuePresentation.Absolute;
                case Units.PERC: return DoseValuePresentation.Relative;
                default: throw new ArgumentException("Unknown query type");
            }
        }

        /// <summary>
        ///     Returns the dose value presentation for this query, helps in acquiring the correct dvh
        /// </summary>
        /// <param name="query">the mayo query</param>
        /// <returns>the dose value presentation of the query</returns>
        public static DoseValue.DoseUnit GetDoseUnit(this MayoQuery query)
        {
            //If volume query return query unit to dose unit
            if (query.QueryType == QueryType.COMPLEMENT_VOLUME ||
                query.QueryType == QueryType.VOLUME_AT_DOSE)
                switch (query.QueryUnits)
                {
                    case Units.CGY: return DoseValue.DoseUnit.cGy;
                    case Units.GY: return DoseValue.DoseUnit.Gy;
                    case Units.PERC: return DoseValue.DoseUnit.Percent;
                    default: return DoseValue.DoseUnit.Unknown;
                }
            switch (query.UnitsDesired)
            {
                case Units.CGY: return DoseValue.DoseUnit.cGy;
                case Units.GY: return DoseValue.DoseUnit.Gy;
                case Units.PERC: return DoseValue.DoseUnit.Percent;
                default: return DoseValue.DoseUnit.Unknown;
            }
        }

        /// <summary>
        ///     Returns the volume presentation for this query, helps in acquiring the correct dvh
        /// </summary>
        /// <param name="query">the mayo query</param>
        /// <returns>the volume presentation of the query</returns>
        public static VolumePresentation GetVolumePresentation(this MayoQuery query)
        {
            //If volume query return units desired to volume unit
            if (query.QueryType == QueryType.COMPLEMENT_VOLUME ||
                query.QueryType == QueryType.VOLUME_AT_DOSE)
                switch (query.UnitsDesired)
                {
                    case Units.CC: return VolumePresentation.AbsoluteCm3;
                    case Units.PERC: return VolumePresentation.Relative;
                    default: throw new ArgumentException("Unknown query type");
                }
            if (query.QueryType == QueryType.MAX_DOSE || query.QueryType == QueryType.MIN_DOSE ||
                query.QueryType == QueryType.MEAN_DOSE)
                return VolumePresentation.Relative;
            switch (query.QueryUnits)
            {
                case Units.CC: return VolumePresentation.AbsoluteCm3;
                case Units.PERC: return VolumePresentation.Relative;
                default: throw new ArgumentException("Unknown query type");
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

        private static double QueryDoseComplement(DVHPoint[] dvh, MayoQuery query)
        {
            var dose = dvh.GetDoseComplement(query.QueryValue);
            var doseUnit = query.GetDoseUnit();
            return dose.GetDose(doseUnit);
        }

        private static double QueryVolume(DVHPoint[] dvh, MayoQuery query)
        {
            var doseUnit = query.GetDoseUnit();
            var doseValue = new DoseValue(query.QueryValue, doseUnit);
            return dvh.GetVolumeAtDose(doseValue);
        }

        private static double QueryComplementVolume(DVHPoint[] dvh, MayoQuery query)
        {
            var doseUnit = query.GetDoseUnit();
            var doseValue = new DoseValue(query.QueryValue, doseUnit);
            return dvh.GetComplementVolumeAtDose(doseValue);
        }
    }
}