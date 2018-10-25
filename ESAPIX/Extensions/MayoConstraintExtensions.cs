using ESAPIX.Constraints;
using ESAPIX.Constraints.DVH.Query;
using ESAPIX.DVH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Extensions
{
    public static class MayoConstraintExtensions
    {
        public static IConstraint ToDVHConstraint(this MayoConstraint mc, string structureName, PriorityType priority)
        {
            return MayoConstraintConverter.ConvertToDVHConstraint(structureName, priority, mc);
        }
    }
}
