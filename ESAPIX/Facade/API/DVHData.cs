using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class DVHData : ESAPIX.Facade.API.SerializableObject
    {
        public DVHData() { }
        public DVHData(dynamic client) { _client = client; }
        public System.Double Coverage
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Coverage; });
            }
        }
        public ESAPIX.Facade.Types.DVHPoint[] CurveData
        {
            get
            {
                var local = this;
                return ArrayHelper.GenerateDVHPointArray(local._client.CurveData);
            }
        }
        public ESAPIX.Facade.Types.DoseValue MaxDose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.MaxDose);
            }
        }
        public ESAPIX.Facade.Types.DoseValue MeanDose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.MeanDose);
            }
        }
        public ESAPIX.Facade.Types.DoseValue MedianDose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.MedianDose);
            }
        }
        public ESAPIX.Facade.Types.DoseValue MinDose
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.Types.DoseValue(local._client.MinDose);
            }
        }
        public System.Double SamplingCoverage
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SamplingCoverage; });
            }
        }
        public System.Double StdDev
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.StdDev; });
            }
        }
        public System.Double Volume
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Volume; });
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