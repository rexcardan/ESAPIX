using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class StructureCodeInfo
    {
        internal dynamic _client;
        public StructureCodeInfo() { _client = new ExpandoObject(); }
        public StructureCodeInfo(dynamic client) { _client = client; }
        public StructureCodeInfo(System.String codingScheme, System.String code) { X.Instance.CurrentContext.Thread.Invoke(() => { _client = VMSConstructor.ConstructStructureCodeInfo(codingScheme, code); }); }
        public System.String CodingScheme
        {
            get
            {
                if (_client is ExpandoObject) { return _client.CodingScheme; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.CodingScheme; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.CodingScheme = value; }
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
        public System.String ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.ToString(); });
            return retVal;

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
        public System.Boolean Equals(ESAPIX.Facade.Types.StructureCodeInfo other)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.Equals(other._client); });
            return retVal;

        }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.GetSchema(); });
            return retVal;

        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() =>
            {
                local._client.ReadXml(reader);
            });

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