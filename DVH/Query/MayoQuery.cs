using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.DVH.Query
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
    }
}
