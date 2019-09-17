#region

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace ESAPIX.Constraints
{
    public enum PriorityType
    {
        [Display(Name = "I")] PRIORITY_1,
        [Display(Name = "II")] PRIORITY_2,
        [Display(Name = "III")] PRIORITY_3,
    }
}