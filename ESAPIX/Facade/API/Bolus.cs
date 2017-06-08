#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Bolus : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public Bolus()
        {
            _client = new ExpandoObject();
        }

        public Bolus(dynamic client)
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

        public double MaterialCTValue
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MaterialCTValue"))
                        return _client.MaterialCTValue;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MaterialCTValue; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MaterialCTValue = value;
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
                {
                    _client.Name = value;
                }
            }
        }
    }
}