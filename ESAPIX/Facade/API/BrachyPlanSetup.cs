using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BrachyPlanSetup : PlanSetup
    {
        public BrachyPlanSetup()
        {
            _client = new ExpandoObject();
        }

        public BrachyPlanSetup(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public string ApplicationSetupType
        {
            get
            {
                if (_client is ExpandoObject) return _client.ApplicationSetupType;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ApplicationSetupType; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ApplicationSetupType = value;
            }
        }

        public IEnumerable<Catheter> Catheters
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.Catheters;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new Catheter();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade._client = vms;
                    });
                    if (facade._client != null)
                        yield return facade;
                }
            }
        }

        public int? NumberOfPdrPulses
        {
            get
            {
                if (_client is ExpandoObject) return _client.NumberOfPdrPulses;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int?>(sc => { return local._client.NumberOfPdrPulses; });
            }
            set
            {
                if (_client is ExpandoObject) _client.NumberOfPdrPulses = value;
            }
        }

        public double? PdrPulseInterval
        {
            get
            {
                if (_client is ExpandoObject) return _client.PdrPulseInterval;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double?>(sc => { return local._client.PdrPulseInterval; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PdrPulseInterval = value;
            }
        }

        public IEnumerable<SeedCollection> SeedCollections
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.SeedCollections;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new SeedCollection();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade._client = vms;
                    });
                    if (facade._client != null)
                        yield return facade;
                }
            }
        }

        public IEnumerable<BrachySolidApplicator> SolidApplicators
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.SolidApplicators;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new BrachySolidApplicator();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade._client = vms;
                    });
                    if (facade._client != null)
                        yield return facade;
                }
            }
        }

        public DateTime? TreatmentDateTime
        {
            get
            {
                if (_client is ExpandoObject) return _client.TreatmentDateTime;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.TreatmentDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.TreatmentDateTime = value;
            }
        }

        public string TreatmentTechnique
        {
            get
            {
                if (_client is ExpandoObject) return _client.TreatmentTechnique;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.TreatmentTechnique; });
            }
            set
            {
                if (_client is ExpandoObject) _client.TreatmentTechnique = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}