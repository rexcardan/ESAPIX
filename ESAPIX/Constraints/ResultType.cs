#region

using System.ComponentModel;

#endregion

namespace ESAPIX.Constraints
{
    public enum ResultType
    {
        [Description("PASSED")] PASSED,

        [Description("REVIEW")] ACTION_LEVEL_1,

        [Description("URGENT REVIEW")] ACTION_LEVEL_2,

        [Description("NO TREAT")] ACTION_LEVEL_3,

        [Description("N/A")] NOT_APPLICABLE,

        [Description("N/A - MISSING STRUCTURE")] NOT_APPLICABLE_MISSING_STRUCTURE,

        [Description("N/A - MISSING DOSE")] NOT_APPLICABLE_MISSING_DOSE,

        [Description("INCONCLUSIVE")] INCONCLUSIVE
    }
}