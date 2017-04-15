using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationIMRTBeamParameter : ESAPIX.Facade.API.OptimizationParameter
    {
        public OptimizationIMRTBeamParameter() { }
        public OptimizationIMRTBeamParameter(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.Beam Beam
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.Beam(local._client.Beam);
            }
        }
        public System.String BeamId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.BeamId; });
            }
        }
        public System.Boolean Excluded
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.Excluded; });
            }
        }
        public System.Boolean FixedJaws
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Boolean>((sc) => { return local._client.FixedJaws; });
            }
        }
        public System.Double SmoothX
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SmoothX; });
            }
        }
        public System.Double SmoothY
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.SmoothY; });
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