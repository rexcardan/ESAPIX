using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;

namespace ESAPIX.DVH.Constraints
{
    public interface IPriorityConstraint : IConstraint
    {
        PriorityType Priority { get; set; }

        /// <summary>
        /// The result type associated with this priority level
        /// </summary>
        /// <returns></returns>
        ResultType GetFailedResultType();
    }
}
