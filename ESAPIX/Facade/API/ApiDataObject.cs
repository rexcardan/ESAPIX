using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ApiDataObject : ESAPIX.Facade.API.SerializableObject
    {
        public ApiDataObject() { _client = new ExpandoObject(); }
        public ApiDataObject(dynamic client) { _client = client; }
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
        public System.String Comment
        {
            get
            {
                if (_client is ExpandoObject) { return _client.Comment; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Comment; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.Comment = value; }
            }
        }
        public System.String HistoryUserName
        {
            get
            {
                if (_client is ExpandoObject) { return _client.HistoryUserName; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.HistoryUserName; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.HistoryUserName = value; }
            }
        }
        public System.DateTime HistoryDateTime
        {
            get
            {
                if (_client is ExpandoObject) { return _client.HistoryDateTime; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.DateTime>((sc) => { return local._client.HistoryDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.HistoryDateTime = value; }
            }
        }
        public System.String ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue((sc) => { return local._client.ToString(); });
            return retVal;

        }
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