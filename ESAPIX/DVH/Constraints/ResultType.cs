using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.DVH.Constraints
{
    public enum ResultType
    {
        [Description("PASSED")]
        PASSED,

        [Description("REVIEW")]
        ACTION_LEVEL_1,

        [Description("URGENT REVIEW")]
        ACTION_LEVEL_2,

        [Description("NO TREAT")]
        ACTION_LEVEL_3,

        [Description("N/A")]
        NOT_APPLICABLE
    }
}
