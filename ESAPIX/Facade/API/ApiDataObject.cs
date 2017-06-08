#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class ApiDataObject : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public ApiDataObject()
        {
            _client = new ExpandoObject();
        }

        public ApiDataObject(dynamic client)
        {
            _client = client;
        }

        public string Id
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Id"))
                        return _client.Id;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Id; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Id = value;
            }
        }

        public string Name
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Name"))
                        return _client.Name;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Name; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Name = value;
            }
        }

        public string Comment
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Comment"))
                        return _client.Comment;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Comment; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Comment = value;
            }
        }

        public string HistoryUserName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("HistoryUserName"))
                        return _client.HistoryUserName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.HistoryUserName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.HistoryUserName = value;
            }
        }

        public DateTime HistoryDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("HistoryDateTime"))
                        return _client.HistoryDateTime;
                    else
                        return default(DateTime);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.HistoryDateTime; }
                    );
                return default(DateTime);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.HistoryDateTime = value;
                }
            }
        }
    }
}