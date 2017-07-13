#region



#endregion

namespace ESAPIX.Constraints
{
    public static class PriorityConverter
    {
        public static ResultType GetFailedResult(PriorityType priority)
        {
            switch (priority)
            {
                case PriorityType.MAJOR_DEVIATION:
                case PriorityType.PRIORITY_1: return ResultType.ACTION_LEVEL_3;
                default: return ResultType.ACTION_LEVEL_1;
            }
        }
    }
}