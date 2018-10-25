using System;

namespace ESAPIX.Constraints.DVH.Query
{
    public class MayoQuery
    {
        public QueryType QueryType { get; set; }
        public Units QueryUnits { get; set; }
        public double QueryValue { get; set; }
        public Units UnitsDesired { get; set; }

        public override string ToString()
        {
            return MayoQueryWriter.Write(this);
        }

        public static MayoQuery Read(string query)
        {
            return MayoQueryReader.Read(query);
        }
    }
}