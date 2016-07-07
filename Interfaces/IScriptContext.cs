using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Interfaces
{
    public interface IScriptContext
    {
        IUser CurrentUser { get; }

        ICourse Course { get; }

        IImage Image { get; }

        IPatient Patient { get; }

        IPlanSetup PlanSetup { get; }

        IEnumerable<IPlanSetup> PlansInScope { get; }

        IEnumerable<IPlanSum> PlanSumsInScope{ get; }

        IStructureSet StructureSet { get; }
    }
}
