using System;
using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Interfaces;

namespace ESAPIX.Fakes
{
    public class PlanSum : PlanningItem, IPlanSum
    {
        public IStructureSet StructureSet
        {
            get; set; 
        }

        public IEnumerable<IPlanSetup> PlanSetups
        {
            get;
            set; 
        }
    }
}