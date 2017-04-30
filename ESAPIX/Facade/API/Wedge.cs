#region

using System.Dynamic;
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
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public double Direction
        {
            get
            {
                if (_client is ExpandoObject) return _client.Direction;
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
                if (_client is ExpandoObject) return _client.WedgeAngle;
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