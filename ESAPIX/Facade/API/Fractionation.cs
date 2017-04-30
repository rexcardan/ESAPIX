using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Fractionation : ESAPIX.Facade.API.ApiDataObject
    {
        public Fractionation() { _client = new ExpandoObject(); }
        public Fractionation(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CreationDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CreationDateTime = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue DosePerFractionInPrimaryRefPoint
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DosePerFractionInPrimaryRefPoint; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { if (DefaultHelper.IsDefault(local._client.DosePerFractionInPrimaryRefPoint)) { return default(ESAPIX.Facade.Types.DoseValue); } else { return new ESAPIX.Facade.Types.DoseValue(local._client.DosePerFractionInPrimaryRefPoint); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DosePerFractionInPrimaryRefPoint = value; }
            }
        }
        public System.Nullable<System.Int32> NumberOfFractions
        {
            get
            {
                if (_client is ExpandoObject) { return _client.NumberOfFractions; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.Int32>>((sc) => { return local._client.NumberOfFractions; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.NumberOfFractions = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue PrescribedDosePerFraction
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PrescribedDosePerFraction; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { if (DefaultHelper.IsDefault(local._client.PrescribedDosePerFraction)) { return default(ESAPIX.Facade.Types.DoseValue); } else { return new ESAPIX.Facade.Types.DoseValue(local._client.PrescribedDosePerFraction); } });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PrescribedDosePerFraction = value; }
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