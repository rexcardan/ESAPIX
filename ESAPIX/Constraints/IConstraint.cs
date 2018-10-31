#region

using VMS.TPS.Common.Model.API;

#endregion

namespace ESAPIX.Constraints
{
    /// <summary>
    /// Main IConstraint interface for planning items
    /// </summary>
    public interface IConstraint
    {
        string Name { get; }
        string FullName { get; }

        ConstraintResult Constrain(PlanningItem pi);
        ConstraintResult CanConstrain(PlanningItem pi);
    }

    /// <summary>
    /// Generic form of IConstraint
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IConstraint<T>
    {
        string Name { get; }
        string FullName { get; }

        ConstraintResult Constrain(T pi);
        ConstraintResult CanConstrain(T pi);
    }
}