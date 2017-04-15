using System;
using System.Collections.Generic;
using System.Collections;
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
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.PlansInScope;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.PlanSetup();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.ExternalPlanSetup> ExternalPlansInScope
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.ExternalPlansInScope;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.ExternalPlanSetup();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.BrachyPlanSetup> BrachyPlansInScope
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.BrachyPlansInScope;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.BrachyPlanSetup();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PlanSum> PlanSumsInScope
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.PlanSumsInScope;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.PlanSum();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                        {
                            facade._client = vms;
                        }
                    });
                    if (facade._client != null)
                    { yield return facade; }
                }
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