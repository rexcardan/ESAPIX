using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Fractionation : ESAPIX.Facade.API.ApiDataObject
    {
        public Fractionation() { }
        public Fractionation(dynamic client) { _client = client; }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
        }
        public ESAPIX.Facade.Types.DoseValue DosePerFractionInPrimaryRefPoint
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.DosePerFractionInPrimaryRefPoint);
            }
        }
        public System.Nullable<System.Int32> NumberOfFractions
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.Int32>>((sc) => { return local._client.NumberOfFractions; });
            }
        }
        public ESAPIX.Facade.Types.DoseValue PrescribedDosePerFraction
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.PrescribedDosePerFraction);
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
        public void SetPrescription(System.Int32 numberOfFractions, ESAPIX.Facade.Types.DoseValue prescribedDosePerFraction, System.Double prescribedPercentage)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.SetPrescription(numberOfFractions, prescribedDosePerFraction._client, prescribedPercentage);
            });

        }
    }
}