using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ScriptContext
    {
        internal dynamic _client;
        public ScriptContext() { _client = new ExpandoObject(); }
        public ScriptContext(dynamic client) { _client = client; }
        public ScriptContext(System.Object context, System.Object user, System.String appName) { X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructScriptContext(context, user, appName); }); }
        public ESAPIX.Facade.API.User CurrentUser
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CurrentUser; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.User>((sc) => { return new ESAPIX.Facade.API.User(local._client.CurrentUser); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CurrentUser = value; }
            }
        }
        public ESAPIX.Facade.API.Course Course
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Course; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Course>((sc) => { return new ESAPIX.Facade.API.Course(local._client.Course); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Course = value; }
            }
        }
        public ESAPIX.Facade.API.Image Image
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Image; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Image>((sc) => { return new ESAPIX.Facade.API.Image(local._client.Image); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Image = value; }
            }
        }
        public ESAPIX.Facade.API.StructureSet StructureSet
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StructureSet; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.StructureSet>((sc) => { return new ESAPIX.Facade.API.StructureSet(local._client.StructureSet); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StructureSet = value; }
            }
        }
        public ESAPIX.Facade.API.Patient Patient
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Patient; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Patient>((sc) => { return new ESAPIX.Facade.API.Patient(local._client.Patient); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Patient = value; }
            }
        }
        public ESAPIX.Facade.API.PlanSetup PlanSetup
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PlanSetup; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.PlanSetup>((sc) => { return new ESAPIX.Facade.API.PlanSetup(local._client.PlanSetup); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PlanSetup = value; }
            }
        }
        public ESAPIX.Facade.API.ExternalPlanSetup ExternalPlanSetup
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ExternalPlanSetup; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.ExternalPlanSetup>((sc) => { return new ESAPIX.Facade.API.ExternalPlanSetup(local._client.ExternalPlanSetup); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ExternalPlanSetup = value; }
            }
        }
        public ESAPIX.Facade.API.BrachyPlanSetup BrachyPlanSetup
        {
            get
            {
                if (_client is ExpandoObject) { return _client.BrachyPlanSetup; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.BrachyPlanSetup>((sc) => { return new ESAPIX.Facade.API.BrachyPlanSetup(local._client.BrachyPlanSetup); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.BrachyPlanSetup = value; }
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
                if (_client is ExpandoObject) { return _client.ApplicationName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ApplicationName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ApplicationName = value; }
            }
        }
        public System.String VersionInfo
        {
            get
            {
                if (_client is ExpandoObject) { return _client.VersionInfo; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.VersionInfo; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.VersionInfo = value; }
            }
        }
    }
}