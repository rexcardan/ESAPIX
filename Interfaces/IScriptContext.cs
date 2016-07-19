using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;

namespace ESAPIX.Interfaces
{
    public interface IScriptContext
    {
        string ApplicationName { get; }

        BrachyPlanSetup BrachyPlanSetup { get; }

        IEnumerable<BrachyPlanSetup> BrachyPlansInScope { get;}

        User CurrentUser { get; }

        Course Course { get; }

        Image Image { get; }

        Patient Patient { get; }

        ExternalPlanSetup ExternalPlanSetup { get; }

        IEnumerable<ExternalPlanSetup> ExternalPlansInScope { get; }

        PlanSetup PlanSetup { get; }

        IEnumerable<PlanSetup> PlansInScope { get; }

        IEnumerable<PlanSum> PlanSumsInScope{ get; }

        StructureSet StructureSet { get; }

        IVMSThread Thread { get; }
    }
}
