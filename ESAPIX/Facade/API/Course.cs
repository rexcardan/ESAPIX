using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Course : ESAPIX.Facade.API.ApiDataObject
    {
        public Course() { }
        public Course(dynamic client) { _client = client; }
        public System.Nullable<System.DateTime> CompletedDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CompletedDateTime; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Diagnosis> Diagnoses
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Diagnosis>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Diagnoses).Select(s => new ESAPIX.Facade.API.Diagnosis(s));
                });
            }
        }
        public System.String Intent
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Intent; });
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
        public IEnumerable<ESAPIX.Facade.API.PlanSum> PlanSums
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.PlanSum>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.PlanSums).Select(s => new ESAPIX.Facade.API.PlanSum(s));
                });
            }
        }
        public System.Nullable<System.DateTime> StartDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.StartDateTime; });
            }
        }
        public System.String Id
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.PlanSetup> PlanSetups
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var test = _client.PlanSetups.GetEnumerator();
                    Console.WriteLine(test);
                });
                do
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
                    {
                        yield return facade;
                    }
                }
                while (enumerator.MoveNext());
            }
        }
        public IEnumerable<ESAPIX.Facade.API.ExternalPlanSetup> ExternalPlanSetups
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.ExternalPlanSetup>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.ExternalPlanSetups).Select(s => new ESAPIX.Facade.API.ExternalPlanSetup(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.BrachyPlanSetup> BrachyPlanSetups
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.BrachyPlanSetup>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.BrachyPlanSetups).Select(s => new ESAPIX.Facade.API.BrachyPlanSetup(s));
                });
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