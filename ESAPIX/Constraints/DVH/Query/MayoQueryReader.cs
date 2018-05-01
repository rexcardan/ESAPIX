#region

using System;
using System.Text.RegularExpressions;

#endregion

namespace ESAPIX.Constraints.DVH.Query
{
    /// <summary>
    ///     Class with methods to read a DVH query in "Mayo Format" (https://www.ncbi.nlm.nih.gov/pubmed/26825250)
    /// </summary>
    public class MayoQueryReader
    {
        /// <summary>
        ///     Reads a full Mayo query string and converts it to a MayoQuery object
        /// </summary>
        /// <param name="query">the query string</param>
        /// <returns>the MayoQuery condensed object for programmatic use</returns>
        public static MayoQuery Read(string query)
        {
            if (!IsValid(query)) throw new ArgumentException($"Not a valid Mayo format => {query}");
            return new MayoQuery
            {
                QueryType = ReadQueryType(query),
                QueryUnits = ReadQueryUnits(query),
                UnitsDesired = ReadUnitsDesired(query),
                QueryValue = ReadQueryValue(query)
            };
        }

        /// <summary>
        ///     Reads only the numerical value in the query (if one exists)
        /// </summary>
        /// <param name="query">the full string of the query</param>
        /// <returns>the numerical queried value, the x in Dxcc[Gy]</returns>
        public static double ReadQueryValue(string query)
        {
            var match = Regex.Match(query, MayoRegex.QueryValue);
            if (!match.Success) return double.NaN;
            return double.Parse(match.Value);
        }

        public static bool IsValid(string query)
        {
            var isMatch = Regex.IsMatch(query, MayoRegex.Valid, RegexOptions.IgnoreCase);
            return isMatch;
        }

        public static QueryType ReadQueryType(string query)
        {
            var match = Regex.Match(query, MayoRegex.QueryType);
            if (!match.Success) throw new ArgumentException($"Not a valid query type {query}!");
            switch (match.Value)
            {
                case "DC": return QueryType.DOSE_COMPLEMENT;
                case "V": return QueryType.VOLUME_AT_DOSE;
                case "D": return QueryType.DOSE_AT_VOLUME;
                case "CV": return QueryType.COMPLEMENT_VOLUME;
                case "Min": return QueryType.MIN_DOSE;
                case "Max": return QueryType.MAX_DOSE;
                case "Mean": return QueryType.MEAN_DOSE;
                default: return QueryType.VOLUME_AT_DOSE;
            }
        }

        public static Units ReadQueryUnits(string query)
        {
            var filtered = Regex.Replace(query, MayoRegex.UnitsDesired, string.Empty);
            var match = Regex.Match(filtered, MayoRegex.QueryUnits, RegexOptions.IgnoreCase);
            if (!match.Success) return Units.NA;
            return ConvertStringToUnit(match.Value);
        }

        public static Units ReadUnitsDesired(string query)
        {
            var match = Regex.Match(query, MayoRegex.UnitsDesired, RegexOptions.IgnoreCase);
            if (!match.Success) throw new ArgumentException($"Not valid units -> {query}!");
            return ConvertStringToUnit(match.Value.Replace("[", "").Replace("]", ""));
        }

        private static Units ConvertStringToUnit(string value)
        {
            switch (value)
            {
                case "cc": return Units.CC;
                case "CC": return Units.CC;
                case "cGy": return Units.CGY;
                case "cGY": return Units.CGY;
                case "CGY": return Units.CGY;
                case "cgy": return Units.CGY;
                case "gy": return Units.GY;
                case "Gy": return Units.GY;
                case "GY": return Units.GY;
                case "%": return Units.PERC;
            }
            throw new ArgumentException("Unknown query units!");
        }
    }
}