using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;

namespace ESAPIX.DVH.Constraints
{
    public interface IConstraint
    {
        string Name { get; }
        string FullName { get; }

        ConstraintResult Constrain(PlanningItem pi);
        ConstraintResult CanConstrain(PlanningItem pi);
    }
}
