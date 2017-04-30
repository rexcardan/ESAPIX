using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class ControlPointCollection : SerializableObject
    {
        public ControlPointCollection()
        {
            _client = new ExpandoObject();
        }

        public ControlPointCollection(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public ControlPoint Item
        {
            get
            {
                if (_client is ExpandoObject) return _client.Item;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Item)) return default(ControlPoint);
                    return new ControlPoint(local._client.Item);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Item = value;
            }
        }

        public int Count
        {
            get
            {
                if (_client is ExpandoObject) return _client.Count;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.Count; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Count = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}