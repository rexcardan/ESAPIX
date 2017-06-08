#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class User : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public User()
        {
            _client = new ExpandoObject();
        }

        public User(dynamic client)
        {
            _client = client;
        }

        public string Language
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Language"))
                        return _client.Language;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Language; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Language = value;
                }
            }
        }
    }
}