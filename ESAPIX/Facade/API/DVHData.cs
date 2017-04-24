using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class DVHData : ESAPIX.Facade.API.SerializableObject
    {
        public DVHData() { _client = new ExpandoObject(); }
        public DVHData(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.Double Coverage
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Coverage; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Coverage; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Coverage = value; }
            }
        }
        public ESAPIX.Facade.Types.DVHPoint[] CurveData
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CurveData; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DVHPoint[]>((sc) => { return ArrayHelper.GenerateDVHPointArray(local._client.CurveData); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CurveData = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue MaxDose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MaxDose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.MaxDose); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MaxDose = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue MeanDose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MeanDose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.MeanDose); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MeanDose = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue MedianDose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MedianDose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.MedianDose); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MedianDose = value; }
            }
        }
        public ESAPIX.Facade.Types.DoseValue MinDose
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MinDose; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.Types.DoseValue>((sc) => { return new ESAPIX.Facade.Types.DoseValue(local._client.MinDose); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MinDose = value; }
            }
        }
        public System.Double SamplingCoverage
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SamplingCoverage; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SamplingCoverage; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SamplingCoverage = value; }
            }
        }
        public System.Double StdDev
        {
            get
            {
                if (_client is ExpandoObject) { return _client.StdDev; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.StdDev; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.StdDev = value; }
            }
        }
        public System.Double Volume
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Volume; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Volume; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Volume = value; }
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