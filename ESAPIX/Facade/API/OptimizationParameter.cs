using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationParameter : ESAPIX.Facade.API.SerializableObject
    {
        public OptimizationParameter() { }
        public OptimizationParameter(dynamic client) { _client = client; }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.WriteXml(writer);
            });

        }
        public System.Boolean Equals(System.Object obj)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.Equals(obj); });
            return retVal;

        }
        public System.Int32 GetHashCode()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetHashCode(); });
            return retVal;

        }
    }
}