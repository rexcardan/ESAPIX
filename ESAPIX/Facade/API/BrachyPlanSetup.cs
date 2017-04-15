using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class BrachyPlanSetup : ESAPIX.Facade.API.PlanSetup
    {
        public BrachyPlanSetup() { }
        public BrachyPlanSetup(dynamic client) { _client = client; }
        public System.String ApplicationSetupType
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ApplicationSetupType; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.Catheter> Catheters
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.Catheter>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.Catheters).Select(s => new ESAPIX.Facade.API.Catheter(s));
                });
            }
        }
        public System.Nullable<System.Int32> NumberOfPdrPulses
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.Int32>>((sc) => { return local._client.NumberOfPdrPulses; });
            }
        }
        public System.Nullable<System.Double> PdrPulseInterval
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.Double>>((sc) => { return local._client.PdrPulseInterval; });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.SeedCollection> SeedCollections
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.SeedCollection>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.SeedCollections).Select(s => new ESAPIX.Facade.API.SeedCollection(s));
                });
            }
        }
        public IEnumerable<ESAPIX.Facade.API.BrachySolidApplicator> SolidApplicators
        {
            get
            {
                return X.Instance.CurrentContext.GetValue<IEnumerable<ESAPIX.Facade.API.BrachySolidApplicator>>(sc =>
                {
                    return ((IEnumerable<dynamic>)_client.SolidApplicators).Select(s => new ESAPIX.Facade.API.BrachySolidApplicator(s));
                });
            }
        }
        public System.Nullable<System.DateTime> TreatmentDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.TreatmentDateTime; });
            }
        }
        public System.String TreatmentTechnique
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TreatmentTechnique; });
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