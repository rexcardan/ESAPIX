using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ControlPointCollection : ESAPIX.Facade.API.SerializableObject
    {
        public ControlPointCollection() { _client = new ExpandoObject(); }
        public ControlPointCollection(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public ESAPIX.Facade.API.ControlPoint Item
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Item; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<ESAPIX.Facade.API.ControlPoint>((sc) => { return new ESAPIX.Facade.API.ControlPoint(local._client.Item); });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Item = value; }
            }
        }
        public System.Int32 Count
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Count; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Count; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Count = value; }
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