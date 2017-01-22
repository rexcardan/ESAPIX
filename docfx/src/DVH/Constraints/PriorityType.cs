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
    }
}