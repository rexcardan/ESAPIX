using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Bolus : ESAPIX.Facade.API.SerializableObject
    {
        public Bolus() { _client = new ExpandoObject(); }
        public Bolus(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.String Id
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Id; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Id = value; }
            }
        }
        public System.Double MaterialCTValue
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MaterialCTValue; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MaterialCTValue; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MaterialCTValue = value; }
            }
        }
        public System.String Name
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Name; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Name; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Name = value; }
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