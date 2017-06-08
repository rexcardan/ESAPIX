#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Hospital : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Hospital()
        {
            _client = new ExpandoObject();
        }

        public Hospital(dynamic client)
        {
            _client = client;
        }

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("CreationDateTime"))
                        return _client.CreationDateTime;
                    else
                        return default(DateTime?);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.CreationDateTime; }
                    );
                return default(DateTime?);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.CreationDateTime = value;
            }
        }

        public string Location
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Location"))
                        return _client.Location;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Location; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Location = value;
                }
            }
        }
    }
}