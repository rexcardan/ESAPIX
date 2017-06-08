#region

using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Wedge : AddOn, System.Xml.Serialization.IXmlSerializable
    {
        public Wedge()
        {
            _client = new ExpandoObject();
        }

        public Wedge(dynamic client)
        {
            _client = client;
        }

        public double Direction
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Direction"))
                        return _client.Direction;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.Direction; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Direction = value;
            }
        }

        public double WedgeAngle
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("WedgeAngle"))
                        return _client.WedgeAngle;
                    else
                        return default(double);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.WedgeAngle; }
                    );
                return default(double);
            }

            set
            {
                if (_client is ExpandoObject)
                {
                    _client.WedgeAngle = value;
                }
            }
        }
    }
}