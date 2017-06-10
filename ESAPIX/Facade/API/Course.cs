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
    public class Course : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Course()
        {
            _client = new ExpandoObject();
        }

        public Course(dynamic client)
        {
            _client = client;
        }

        public DateTime? CompletedDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CompletedDateTime"))
                        return _client.CompletedDateTime;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CompletedDateTime; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CompletedDateTime = value;
            }
        }

        public IEnumerable<Diagnosis> Diagnoses
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Diagnoses"))
                        foreach (var item in _client.Diagnoses)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Diagnoses;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Diagnosis();
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
                    _client.Diagnoses = value;
            }
        }

        public string Intent
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Intent"))
                        return _client.Intent;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Intent; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Intent = value;
            }
        }

        public Patient Patient
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Patient"))
                        return _client.Patient;
                    else
                        return default(Patient);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Patient(_client.Patient); }
                    );
                return default(Patient);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Patient = value;
            }
        }

        public IEnumerable<PlanSum> PlanSums
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSums"))
                        foreach (var item in _client.PlanSums)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.PlanSums;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PlanSum();
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
                    _client.PlanSums = value;
            }
        }

        public DateTime? StartDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("StartDateTime"))
                        return _client.StartDateTime;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.StartDateTime; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.StartDateTime = value;
            }
        }

        public string Id
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Id"))
                        return _client.Id;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Id; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Id = value;
            }
        }

        public IEnumerable<PlanSetup> PlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("PlanSetups"))
                        foreach (var item in _client.PlanSetups)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.PlanSetups;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new PlanSetup();
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
                    _client.PlanSetups = value;
            }
        }

        public IEnumerable<ExternalPlanSetup> ExternalPlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("ExternalPlanSetups"))
                        foreach (var item in _client.ExternalPlanSetups)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.ExternalPlanSetups;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new ExternalPlanSetup();
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
                    _client.ExternalPlanSetups = value;
            }
        }

        public IEnumerable<BrachyPlanSetup> BrachyPlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("BrachyPlanSetups"))
                        foreach (var item in _client.BrachyPlanSetups)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.BrachyPlanSetups;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new BrachyPlanSetup();
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
                    _client.BrachyPlanSetups = value;
            }
        }

        public ExternalPlanSetup AddExternalPlanSetup(StructureSet structureSet)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new ExternalPlanSetup(_client.AddExternalPlanSetup(structureSet._client));
                    }
                );
                return vmsResult;
            }
            return _client.AddExternalPlanSetup(structureSet);
        }

        public ExternalPlanSetup AddExternalPlanSetupAsVerificationPlan(StructureSet structureSet,
            ExternalPlanSetup verifiedPlan)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(sc =>
                    {
                        return new ExternalPlanSetup(
                            _client.AddExternalPlanSetupAsVerificationPlan(structureSet._client, verifiedPlan._client));
                    }
                );
                return vmsResult;
            }
            return _client.AddExternalPlanSetupAsVerificationPlan(structureSet, verifiedPlan);
        }

        public bool CanAddPlanSetup(StructureSet structureSet)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.CanAddPlanSetup(structureSet._client); }
                );
                return vmsResult;
            }
            return (bool) _client.CanAddPlanSetup(structureSet);
        }

        public bool CanRemovePlanSetup(PlanSetup planSetup)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.CanRemovePlanSetup(planSetup._client); }
                );
                return vmsResult;
            }
            return (bool) _client.CanRemovePlanSetup(planSetup);
        }

        public void RemovePlanSetup(PlanSetup planSetup)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.RemovePlanSetup(planSetup._client); }
                );
            else
                _client.RemovePlanSetup(planSetup);
        }
    }
}