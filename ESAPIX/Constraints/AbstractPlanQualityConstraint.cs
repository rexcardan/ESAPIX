using ESAPIX.Constraints.DVH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;

namespace ESAPIX.Constraints
{
    public abstract class AbstractPlanQualityConstraint : IConstraint
    {
        public abstract string Name { get; }
        public virtual string FullName { get { return Name; } }
        public virtual string Value { get; protected set; }

        public abstract ConstraintResult CanConstrain(PlanningItem pi);

        public abstract ConstraintResult Constrain(PlanningItem pi);

        public delegate void StatusUpdateHandler(string status);

        public event StatusUpdateHandler StatusChanged;

        public void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(status);
        }
    }
}
