using System.ComponentModel;

namespace ESAPIX.DVH.Constraints
{
    public enum PriorityType
    {
        [Description("Ideal")]
        IDEAL,
        [Description("Acceptable")]
        ACCEPTABLE,
        [Description("Minor Deviation")]
        MINOR_DEVIATION,
        [Description("Major Deviation")]
        MAJOR_DEVIATION,
        [Description("Goal")]
        GOAL,
        [Description("Optional")]
        OPTIONAL,
        [Description("Report")]
        REPORT,
        [Description("Priority 1")]
        PRIORITY_1,
        [Description("Priority 2")]
        PRIORITY_2,
    }
}