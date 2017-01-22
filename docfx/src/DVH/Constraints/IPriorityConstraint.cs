using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.DVH.Constraints
{
    public interface IPriorityConstraint : IConstraint
    {
        PriorityType Priority { get; set; }
    }
}
