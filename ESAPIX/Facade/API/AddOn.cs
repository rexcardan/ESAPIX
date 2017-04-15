using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class AddOn : ESAPIX.Facade.API.ApiDataObject
    {
        public AddOn() { _client = new ExpandoObject(); }
        public AddOn(dynamic client) { _client = client; }
        public System.Nullable<System.DateTime> CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CreationDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Nullable<System.DateTime>>((sc) => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CreationDateTime = value; }
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