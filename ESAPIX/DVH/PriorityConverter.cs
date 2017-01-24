using ESAPIX.DVH.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.DVH
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
