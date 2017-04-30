#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Course : ApiDataObject
    {
        public Course()
        {
            _client = new ExpandoObject();
        }

        public Course(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public DateTime? CompletedDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("CompletedDateTime")
                        ? _client.CompletedDateTime
                        : default(DateTime?);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CompletedDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CompletedDateTime = value;
            }
        }

        public IEnumerable<Diagnosis> Diagnoses
        {
            get
            {
                if (_client is ExpandoObject)
                    yield return (_client as ExpandoObject).HasProperty("Diagnoses")
                        ? _client.Diagnoses
                        : default(IEnumerable<Diagnosis>);
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.Diagnoses;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new Diagnosis();
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
            set
            {
                if (_client is ExpandoObject) _client.Diagnoses = value;
            }
        }

        public string Intent
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Intent") ? _client.Intent : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Intent; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Intent = value;
            }
        }

        public Patient Patient
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Patient") ? _client.Patient : default(Patient);
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Patient)) return default(Patient);
                    return new Patient(local._client.Patient);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Patient = value;
            }
        }

        public IEnumerable<PlanSum> PlanSums
        {
            get
            {
                if (_client is ExpandoObject)
                    yield return (_client as ExpandoObject).HasProperty("PlanSums")
                        ? _client.PlanSums
                        : default(IEnumerable<PlanSum>);
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.PlanSums;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new PlanSum();
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
            set
            {
                if (_client is ExpandoObject) _client.PlanSums = value;
            }
        }

        public DateTime? StartDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("StartDateTime")
                        ? _client.StartDateTime
                        : default(DateTime?);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.StartDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.StartDateTime = value;
            }
        }

        public string Id
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Id") ? _client.Id : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Id = value;
            }
        }

        public IEnumerable<PlanSetup> PlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                    yield return (_client as ExpandoObject).HasProperty("PlanSetups")
                        ? _client.PlanSetups
                        : default(IEnumerable<PlanSetup>);
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.PlanSetups;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new PlanSetup();
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
            set
            {
                if (_client is ExpandoObject) _client.PlanSetups = value;
            }
        }

        public IEnumerable<ExternalPlanSetup> ExternalPlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                    yield return (_client as ExpandoObject).HasProperty("ExternalPlanSetups")
                        ? _client.ExternalPlanSetups
                        : default(IEnumerable<ExternalPlanSetup>);
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.ExternalPlanSetups;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new ExternalPlanSetup();
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
            set
            {
                if (_client is ExpandoObject) _client.ExternalPlanSetups = value;
            }
        }

        public IEnumerable<BrachyPlanSetup> BrachyPlanSetups
        {
            get
            {
                if (_client is ExpandoObject)
                    yield return (_client as ExpandoObject).HasProperty("BrachyPlanSetups")
                        ? _client.BrachyPlanSetups
                        : default(IEnumerable<BrachyPlanSetup>);
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.BrachyPlanSetups;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new BrachyPlanSetup();
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
            set
            {
                if (_client is ExpandoObject) _client.BrachyPlanSetups = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public ExternalPlanSetup AddExternalPlanSetup(StructureSet structureSet)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new ExternalPlanSetup(local._client.AddExternalPlanSetup(structureSet._client));
            });
            return retVal;
        }

        public ExternalPlanSetup AddExternalPlanSetupAsVerificationPlan(StructureSet structureSet,
            ExternalPlanSetup verifiedPlan)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return new ExternalPlanSetup(
                    local._client.AddExternalPlanSetupAsVerificationPlan(structureSet._client,
                        verifiedPlan._client));
            });
            return retVal;
        }

        public bool CanAddPlanSetup(StructureSet structureSet)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.CanAddPlanSetup(structureSet._client);
            });
            return retVal;
        }

        public bool CanRemovePlanSetup(PlanSetup planSetup)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc =>
            {
                return local._client.CanRemovePlanSetup(planSetup._client);
            });
            return retVal;
        }

        public void RemovePlanSetup(PlanSetup planSetup)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.RemovePlanSetup(planSetup._client); });
        }
    }
}