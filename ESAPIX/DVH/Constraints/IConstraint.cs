#region

using ESAPIX.Facade.API;

#endregion

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