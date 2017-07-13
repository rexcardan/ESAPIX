#region

using ESAPIX.Facade.API;

#endregion

namespace ESAPIX.Constraints
{
    public abstract class AbstractPlanQualityConstraint : IConstraint
    {
        public delegate void StatusUpdateHandler(string status);

        public virtual string Value { get; protected set; }
        public abstract string Name { get; }

        public virtual string FullName
        {
            get { return Name; }
        }

        public abstract ConstraintResult CanConstrain(PlanningItem pi);

        public abstract ConstraintResult Constrain(PlanningItem pi);

        public event StatusUpdateHandler StatusChanged;

        public void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(status);
        }
    }
}