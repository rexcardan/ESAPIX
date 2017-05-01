#region

using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Wedge : AddOn
    {
        public Wedge()
        {
            _client = new ExpandoObject();
        }

        public Wedge(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public double Direction
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("Direction") ? _client.Direction : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.Direction; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Direction = value;
            }
        }

        public double WedgeAngle
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("WedgeAngle") ? _client.WedgeAngle : default(double);
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.WedgeAngle; });
            }
            set
            {
                if (_client is ExpandoObject) _client.WedgeAngle = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}