using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Enums
{
    public enum PlanSetupApprovalStatus
    {
        Rejected = 0,
        UnApproved = 1,
        Reviewed = 2,
        PlanningApproved = 3,
        TreatmentApproved = 4,
        CompletedEarly = 5,
        Completed = 6,
        Retired = 7,
        UnPlannedTreatment = 8,
        ExternallyApproved = 9,
        Unknown = 999,
    }
}
