using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ScriptContext
    {
        internal dynamic _client;
        public ScriptContext() { }
        public ScriptContext(dynamic client) { _client = client; }
        public ScriptContext(System.Object context, System.Object user, System.String appName) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructScriptContext(context, user, appName)); }
        public ESAPIX.Facade.API.User CurrentUser
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.User(local._client.CurrentUser);
            }
        }
        public ESAPIX.Facade.API.Course Course
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Course(local._client.Course);
            }
        }
        public ESAPIX.Facade.API.Image Image
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Image(local._client.Image);
            }
        }
        public ESAPIX.Facade.API.StructureSet StructureSet
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.StructureSet(local._client.StructureSet);
            }
        }
        public ESAPIX.Facade.API.Patient Patient
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Patient(local._client.Patient);
            }
        }
        public ESAPIX.Facade.API.PlanSetup PlanSetup
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.PlanSetup(local._client.PlanSetup);
            }
        }
        public ESAPIX.Facade.API.ExternalPlanSetup ExternalPlanSetup
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.ExternalPlanSetup(local._client.ExternalPlanSetup);
            }
        }
        public ESAPIX.Facade.API.BrachyPlanSetup BrachyPlanSetup
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.BrachyPlanSetup(local._client.BrachyPlanSetup);
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PlanSetup> PlansInScope
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.PlanSetup>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.PlansInScope).Select(s => new ESAPIX.Facade.API.PlanSetup(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.ExternalPlanSetup> ExternalPlansInScope
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.ExternalPlanSetup>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.ExternalPlansInScope).Select(s => new ESAPIX.Facade.API.ExternalPlanSetup(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.BrachyPlanSetup> BrachyPlansInScope
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.BrachyPlanSetup>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.BrachyPlansInScope).Select(s => new ESAPIX.Facade.API.BrachyPlanSetup(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PlanSum> PlanSumsInScope
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.PlanSum>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.PlanSumsInScope).Select(s => new ESAPIX.Facade.API.PlanSum(s));
                });
            }
        }
        public System.String ApplicationName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ApplicationName; });
            }
        }
        public System.String VersionInfo
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.VersionInfo; });
            }
        }
    }
}