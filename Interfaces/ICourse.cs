using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Interfaces
{
    public interface ICourse : IApiDataObject
    {
        string CompletedByUserName { get; }

        DateTime? CompletedDateTime { get; }

        IEnumerable<IPlanSetup> PlanSetups { get; }

        IEnumerable<IPlanSum> PlanSums { get; }

        DateTime? StartDateTime { get; }
    }
}
