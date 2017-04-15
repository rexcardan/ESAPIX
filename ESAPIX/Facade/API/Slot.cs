using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Slot : ESAPIX.Facade.API.ApiDataObject
    {
        public Slot() { _client = new ExpandoObject(); }
        public Slot(dynamic client) { _client = client; }
        public System.Int32 Number
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Number; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.Number; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Number = value; }
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