#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Slot : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Slot()
        {
            _client = new ExpandoObject();
        }

        public Slot(dynamic client)
        {
            _client = client;
        }

        public int Number
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Number"))
                        return _client.Number;
                    else
                        return default(int);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Number; }
                    );
                return default(int);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.Number = value;
                }
            }
        }
    }
}