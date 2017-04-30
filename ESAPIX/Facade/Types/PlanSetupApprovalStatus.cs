using System;
using System.Collections.Generic;
using System.Collections;

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