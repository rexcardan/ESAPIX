using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ApiDataObject : ESAPIX.Facade.API.SerializableObject
    {
        public ApiDataObject() { }
        public ApiDataObject(dynamic client) { _client = client; }
        public System.String Id
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Id; });
            }
        }
        public System.String Name
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Name; });
            }
        }
        public System.String Comment
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.Comment; });
            }
        }
        public System.String HistoryUserName
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.HistoryUserName; });
            }
        }
        public System.DateTime HistoryDateTime
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.DateTime>((sc) => { return local._client.HistoryDateTime; });
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