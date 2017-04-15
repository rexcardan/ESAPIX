using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class RadioactiveSourceModel : ESAPIX.Facade.API.ApiDataObject
    {
        public RadioactiveSourceModel() { }
        public RadioactiveSourceModel(dynamic client) { _client = client; }
        public ESAPIX.Facade.Types.VVector ActiveSize
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.VVector(local._client.ActiveSize);
            }
        }
        public System.Double ActivityConversionFactor
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.ActivityConversionFactor; });
            }
        }
        public System.String CalculationModel
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.CalculationModel; });
            }
        }
        public System.Double DoseRateConstant
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.DoseRateConstant; });
            }
        }
        public System.Double HalfLife
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.HalfLife; });
            }
        }
        public System.String LiteratureReference
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.LiteratureReference; });
            }
        }
        public System.String Manufacturer
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Manufacturer; });
            }
        }
        public System.String SourceType
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SourceType; });
            }
        }
        public System.String Status
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Status; });
            }
        }
        public System.Nullable<System.DateTime> StatusDate
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.StatusDate; });
            }
        }
        public System.String StatusUserName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.StatusUserName; });
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