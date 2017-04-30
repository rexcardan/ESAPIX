#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class ApiDataObject : SerializableObject
    {
        public ApiDataObject()
        {
            _client = new ExpandoObject();
        }

        public ApiDataObject(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public string Id
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Id") ? _client.Id : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Id; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Id = value;
            }
        }

        public string Name
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Name") ? _client.Name : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Name; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Name = value;
            }
        }

        public string Comment
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Comment") ? _client.Comment : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Comment; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Comment = value;
            }
        }

        public string HistoryUserName
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("HistoryUserName")
                        ? _client.HistoryUserName
                        : default(string);
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.HistoryUserName; });
            }
            set
            {
                if (_client is ExpandoObject) _client.HistoryUserName = value;
            }
        }

        public DateTime HistoryDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("HistoryDateTime")
                        ? _client.HistoryDateTime
                        : default(DateTime);
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime>(sc => { return local._client.HistoryDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.HistoryDateTime = value;
            }
        }

        public string ToString()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.ToString(); });
            return retVal;
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public bool Equals(object obj)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.Equals(obj); });
            return retVal;
        }

        public int GetHashCode()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetHashCode(); });
            return retVal;
        }
    }
}