using ESAPIX.Constraints.DVH.Query;
using ESAPIX.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Constraints.DVH
{
    public class ConstraintBuilder
    {
        public static IConstraint Build(string structureName, string mayoConstraint, PriorityType priority = PriorityType.IDEAL)
        {
            var mayo = MayoConstraint.Read(mayoConstraint);
            return mayo.ToDVHConstraint(structureName, priority);
        }
    }
}
