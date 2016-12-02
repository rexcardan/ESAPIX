using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.DVH.Query
{
    public class MayoQueryWriter
    {
        public static string Write(MayoQuery query)
        {
            var type = GetTypeString(query.QueryType);
            string qUnits = GetUnitString(query.QueryUnits);
            string qValue = query.QueryValue.ToString();
            string dUnits = GetUnitString(query.UnitsDesired);
            return $"{type}{qValue}{qUnits}[{dUnits}]";
        }

        private static string GetTypeString(QueryType queryType)
        {
            switch (queryType)
            {
                case QueryType.COMPLIMENT_VOLUME: return "CV";
                case QueryType.DOSE: return "D";
                case QueryType.DOSE_COMPLIMENT: return "DC";
                case QueryType.MAX: return "MAX";
                case QueryType.MEAN: return "MEAN";
                case QueryType.MIN: return "MIN";
                case QueryType.VOLUME: return "V";
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
