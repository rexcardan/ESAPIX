using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class ScriptContext : VMSProxy, IScriptContext
    {
        public IUser CurrentUser
        {
            get
            {
                return Wrap<User>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public ICourse Course
        {
            get
            {
                return Wrap<Course>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IImage Image
        {
            get
            {
                return Wrap<Image>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IPatient Patient
        {
            get
            {
                return Wrap<Patient>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IPlanSetup PlanSetup
        {
            get
            {
                return Wrap<PlanSetup>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IEnumerable<IPlanSetup> PlansInScope
        {
            get
            {
                return WrapEnumerable<PlanSetup>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IEnumerable<IPlanSum> PlanSumsInScope
        {
            get
            {
                return WrapEnumerable<PlanSum>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }

        public IStructureSet StructureSet
        {
            get
            {
                return Wrap<StructureSet>(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
        }
    }
}