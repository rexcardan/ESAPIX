using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Diagnosis : ESAPIX.Facade.API.ApiDataObject
    {
        public Diagnosis() { _client = new ExpandoObject(); }
        public Diagnosis(dynamic client) { _client = client; }
        public bool IsLive { get { return !DefaultHelper.IsDefault(_client); } }
        public System.String ClinicalDescription
        {
            get
            {
                if (_client is ExpandoObject) { return _client.ClinicalDescription; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.ClinicalDescription; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.ClinicalDescription = value; }
            }
        }
        public System.String Code
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Code; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Code; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Code = value; }
            }
        }
        public System.String CodeTable
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CodeTable; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.CodeTable; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CodeTable = value; }
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