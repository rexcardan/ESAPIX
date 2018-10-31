#region

using System;
using System.Collections.Generic;
using ESAPIX.Constraints.DVH.Query;
using ESAPIX.Facade.API;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Extensions
{
    /// <summary>
    ///     This helps execute Mayo syntax queries against planning items
    /// </summary>
    public static class FQueryExtensions
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