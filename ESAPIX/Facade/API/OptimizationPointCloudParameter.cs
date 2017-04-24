using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationPointCloudParameter : ESAPIX.Facade.API.OptimizationParameter
    {
        public OptimizationPointCloudParameter() { _client = new ExpandoObject(); }
        public OptimizationPointCloudParameter(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.Double PointResolutionInMM
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PointResolutionInMM; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PointResolutionInMM; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PointResolutionInMM = value; }
            }
        }
        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Structure; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.Structure>((sc) => { return new ESAPIX.Facade.API.Structure(local._client.Structure); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Structure = value; }
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