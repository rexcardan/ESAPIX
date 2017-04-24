using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class MLC : ESAPIX.Facade.API.AddOn
    {
        public MLC() { _client = new ExpandoObject(); }
        public MLC(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.String ManufacturerName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ManufacturerName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ManufacturerName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ManufacturerName = value; }
            }
        }
        public System.Double MinDoseDynamicLeafGap
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MinDoseDynamicLeafGap; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Double>((sc) => { return local._client.MinDoseDynamicLeafGap; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MinDoseDynamicLeafGap = value; }
            }
        }
        public System.String Model
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Model; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Model; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Model = value; }
            }
        }
        public System.String SerialNumber
        {
            get
            {
                if (_client is ExpandoObject) { return _client.SerialNumber; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.SerialNumber; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.SerialNumber = value; }
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