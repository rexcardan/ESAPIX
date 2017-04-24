using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Wedge : ESAPIX.Facade.API.AddOn
    {
        public Wedge() { _client = new ExpandoObject(); }
        public Wedge(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.Double Direction
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Direction; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.Direction; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Direction = value; }
            }
        }
        public System.Double WedgeAngle
        {
            get
            {
                if (_client is ExpandoObject) { return _client.WedgeAngle; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.WedgeAngle; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.WedgeAngle = value; }
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