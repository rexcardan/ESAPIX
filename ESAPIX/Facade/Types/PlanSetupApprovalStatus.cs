using System;
using System.Collections.Generic;

namespace ESAPIX.Facade.Types
{
    public enum PlanSetupApprovalStatus
    {
        Rejected,
        UnApproved,
        Reviewed,
        PlanningApproved,
        TreatmentApproved,
        CompletedEarly,
        Completed,
        Retired,
        UnPlannedTreatment,
        ExternallyApproved,
        Unknown
    }
}