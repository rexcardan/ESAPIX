using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Interfaces;

namespace ESAPIX.Proxies
{
    public class PlanSum : PlanningItem, IPlanSum
    {
        public IStructureSet StructureSet
        {
            get
            {
                return Wrap<StructureSet>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IEnumerable<IPlanSetup> PlanSetups
        {
            get
            {
                return WrapEnumerable<PlanSetup>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }
    }
}