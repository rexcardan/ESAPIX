using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BrachyPlanSetup : ESAPIX.Facade.API.PlanSetup
    {
        public BrachyPlanSetup() { _client = new ExpandoObject(); }
        public BrachyPlanSetup(dynamic client) { _client = client; }
        public System.String ApplicationSetupType
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ApplicationSetupType; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ApplicationSetupType; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ApplicationSetupType = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Catheter> Catheters
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.Catheters;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.Catheter();
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
        public System.Nullable<System.Int32> NumberOfPdrPulses
        {
            get
            {
                if (_client is ExpandoObject) { return _client.NumberOfPdrPulses; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.Int32>>((sc) => { return local._client.NumberOfPdrPulses; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.NumberOfPdrPulses = value; }
            }
        }
        public System.Nullable<System.Double> PdrPulseInterval
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PdrPulseInterval; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.Double>>((sc) => { return local._client.PdrPulseInterval; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PdrPulseInterval = value; }
            }
        }
        public IEnumerable<ESAPIX.Facade.API.SeedCollection> SeedCollections
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.SeedCollections;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.SeedCollection();
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
        public IEnumerable<ESAPIX.Facade.API.BrachySolidApplicator> SolidApplicators
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable)_client.SolidApplicators;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue<bool>(sc => enumerator.MoveNext()))
                {
                    var facade = new ESAPIX.Facade.API.BrachySolidApplicator();
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
        public System.Nullable<System.DateTime> TreatmentDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TreatmentDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.TreatmentDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TreatmentDateTime = value; }
            }
        }
        public System.String TreatmentTechnique
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TreatmentTechnique; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TreatmentTechnique; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TreatmentTechnique = value; }
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
    }
}