using System;
using System.Collections.Generic;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ControlPointCollection : ESAPIX.Facade.API.SerializableObject
    {
        public ControlPointCollection() { }
        public ControlPointCollection(dynamic client) { _client = client; }
        public ESAPIX.Facade.API.ControlPoint Item
        {
            get
            {
                var local = this;
                return new ESAPIX.Facade.API.ControlPoint(local._client.Item);
            }
        }
        public System.Int32 Count
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Count; });
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