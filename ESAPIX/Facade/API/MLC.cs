#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class MLC : AddOn, System.Xml.Serialization.IXmlSerializable
    {
        public MLC()
        {
            _client = new ExpandoObject();
        }

        public MLC(dynamic client)
        {
            _client = client;
        }

        public string ManufacturerName
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("ManufacturerName"))
                        return _client.ManufacturerName;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.ManufacturerName; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.ManufacturerName = value;
            }
        }

        public double MinDoseDynamicLeafGap
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("MinDoseDynamicLeafGap"))
                        return _client.MinDoseDynamicLeafGap;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.MinDoseDynamicLeafGap; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.MinDoseDynamicLeafGap = value;
            }
        }

        public string Model
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Model"))
                        return _client.Model;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Model; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Model = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("SerialNumber"))
                        return _client.SerialNumber;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.SerialNumber; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.SerialNumber = value;
                }
            }
        }
    }
}