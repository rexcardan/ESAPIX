#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class BrachyPlanSetup : PlanSetup, System.Xml.Serialization.IXmlSerializable
    {
        public BrachyPlanSetup()
        {
            _client = new ExpandoObject();
        }

        public BrachyPlanSetup(dynamic client)
        {
            _client = client;
        }

        public string ApplicationSetupType
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ApplicationSetupType"))
                        return _client.ApplicationSetupType;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ApplicationSetupType; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ApplicationSetupType = value;
            }
        }

        public IEnumerable<Catheter> Catheters
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Catheters"))
                        foreach (var item in _client.Catheters)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Catheters;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Catheter();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Catheters = value;
            }
        }

        public int? NumberOfPdrPulses
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("NumberOfPdrPulses"))
                        return _client.NumberOfPdrPulses;
                    else
                        return default(int?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.NumberOfPdrPulses; }
                    );
                return default(int?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.NumberOfPdrPulses = value;
            }
        }

        public double? PdrPulseInterval
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("PdrPulseInterval"))
                        return _client.PdrPulseInterval;
                    else
                        return default(double?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.PdrPulseInterval; }
                    );
                return default(double?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.PdrPulseInterval = value;
            }
        }

        public IEnumerable<SeedCollection> SeedCollections
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("SeedCollections"))
                        foreach (var item in _client.SeedCollections)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.SeedCollections;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new SeedCollection();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SeedCollections = value;
            }
        }

        public IEnumerable<BrachySolidApplicator> SolidApplicators
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("SolidApplicators"))
                        foreach (var item in _client.SolidApplicators)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.SolidApplicators;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new BrachySolidApplicator();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.SolidApplicators = value;
            }
        }

        public DateTime? TreatmentDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TreatmentDateTime"))
                        return _client.TreatmentDateTime;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TreatmentDateTime; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TreatmentDateTime = value;
            }
        }

        public string TreatmentTechnique
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("TreatmentTechnique"))
                        return _client.TreatmentTechnique;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.TreatmentTechnique; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.TreatmentTechnique = value;
            }
        }
    }
}