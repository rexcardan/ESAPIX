using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.DVH
{
    public class StructureQuery
    {
        public StructureQuery(string structId, params string[] queries)
        {
            StructureId = structId;
            Queries = queries.ToList();
        }

        public string StructureId { get; private set; }
        public List<string> Queries { get; private set; }
    }
}
