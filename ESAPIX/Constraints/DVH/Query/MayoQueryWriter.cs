#region

using System;

#endregion

namespace ESAPIX.Constraints.DVH.Query
{
    public class MayoQueryWriter
    {
        public static string Write(MayoQuery query)
        {
            var type = GetTypeString(query.QueryType);
            var qUnits = GetUnitString(query.QueryUnits);
            var qValue = query.QueryValue.ToString();
            var dUnits = GetUnitString(query.UnitsDesired);
            return $"{type}{qValue}{qUnits}[{dUnits}]";
        }

        private static string GetTypeString(QueryType queryType)
        {
            switch (queryType)
            {
                case QueryType.COMPLEMENT_VOLUME: return "CV";
                case QueryType.DOSE_AT_VOLUME: return "D";
                case QueryType.DOSE_COMPLEMENT: return "DC";
                case QueryType.MAX_DOSE: return "MAX";
                case QueryType.MEAN_DOSE: return "MEAN";
                case QueryType.MIN_DOSE: return "MIN";
                case QueryType.VOLUME_AT_DOSE: return "V";
                default: throw new ArgumentException("Unknown type!");
            }
        }

        private static string GetUnitString(Units queryUnits)
        {
            switch (queryUnits)
            {
                case Units.CC: return "cc";
                case Units.CGY: return "cGY";
                case Units.GY: return "Gy";
                case Units.PERC: return "%";
                default: throw new ArgumentException("Unknown units!");
            }
        }
    }
}