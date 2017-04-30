using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Course : ESAPIX.Facade.API.ApiDataObject
    {
        public Course() { _client = new ExpandoObject(); }
        public Course(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.Nullable<System.DateTime> CompletedDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CompletedDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CompletedDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CompletedDateTime = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Diagnosis> Diagnoses
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Diagnoses;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Diagnosis();
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
        public System.String Intent
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Intent; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Intent; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Intent = value; }
            }
        }
        public ESAPIX.Facade.API.Patient Patient
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Patient; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Patient>((sc) => { if (DefaultHelper.IsDefault(local._client.Patient)) { return default(ESAPIX.Facade.API.Patient); } else { return new ESAPIX.Facade.API.Patient(local._client.Patient); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Patient = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PlanSum> PlanSums
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.PlanSums;
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
        public System.Nullable<System.DateTime> StartDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StartDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.StartDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StartDateTime = value; }
            }
        }
        public System.String Id
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Id; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Id = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PlanSetup> PlanSetups
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.PlanSetups;
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
        public IEnumerable<ESAPIX.Facade.API.ExternalPlanSetup> ExternalPlanSetups
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.ExternalPlanSetups;
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
        public IEnumerable<ESAPIX.Facade.API.BrachyPlanSetup> BrachyPlanSetups
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.BrachyPlanSetups;
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
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public ESAPIX.Facade.API.ExternalPlanSetup AddExternalPlanSetup(ESAPIX.Facade.API.StructureSet structureSet)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.ExternalPlanSetup(local._client.AddExternalPlanSetup(structureSet._client)); });
            return retVal;

        }
        public ESAPIX.Facade.API.ExternalPlanSetup AddExternalPlanSetupAsVerificationPlan(ESAPIX.Facade.API.StructureSet structureSet, ESAPIX.Facade.API.ExternalPlanSetup verifiedPlan)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return new ESAPIX.Facade.API.ExternalPlanSetup(local._client.AddExternalPlanSetupAsVerificationPlan(structureSet._client, verifiedPlan._client)); });
            return retVal;

        }
        public System.Boolean CanAddPlanSetup(ESAPIX.Facade.API.StructureSet structureSet)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanAddPlanSetup(structureSet._client); });
            return retVal;

        }
        public System.Boolean CanRemovePlanSetup(ESAPIX.Facade.API.PlanSetup planSetup)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.CanRemovePlanSetup(planSetup._client); });
            return retVal;

        }
        public void RemovePlanSetup(ESAPIX.Facade.API.PlanSetup planSetup)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.RemovePlanSetup(planSetup._client);
            });

        }
    }
}