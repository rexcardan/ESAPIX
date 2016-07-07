using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Interfaces;

namespace ESAPIX.Fakes
{
    public class ScriptContext : IScriptContext
    {
        public IUser CurrentUser
        {
             get; set; 
        }

        public ICourse Course
        {
            get; set; 
        }

        public IImage Image
        {
            get; set; 
        }

        public IPatient Patient
        {
            get; set; 
        }

        public IPlanSetup PlanSetup
        {
             get; set; 
        }

        public IEnumerable<IPlanSetup> PlansInScope
        {
            get; set; 
        }

        public IEnumerable<IPlanSum> PlanSumsInScope
        {
             get; set; 
        }

        public IStructureSet StructureSet
        {
            get;
            set; 
        }
    }
}
