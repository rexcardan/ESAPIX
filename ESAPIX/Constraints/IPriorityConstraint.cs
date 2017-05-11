namespace ESAPIX.Constraints
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