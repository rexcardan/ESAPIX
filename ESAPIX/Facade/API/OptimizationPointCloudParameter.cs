using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationPointCloudParameter : ESAPIX.Facade.API.OptimizationParameter
    {
        public OptimizationPointCloudParameter() { }
        public OptimizationPointCloudParameter(dynamic client) { _client = client; }
        public System.Double PointResolutionInMM
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.PointResolutionInMM; });
            }
        }
        public ESAPIX.Facade.API.Structure Structure
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Structure(local._client.Structure);
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