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
                case PriorityType.PRIORITY_1: return ResultType.ACTION_LEVEL_3;
                case PriorityType.PRIORITY_2: return ResultType.ACTION_LEVEL_2;
                case PriorityType.PRIORITY_3: return ResultType.ACTION_LEVEL_1;
                default: return ResultType.ACTION_LEVEL_1;
            }
        }
    }
}