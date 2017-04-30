using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Slot : ApiDataObject
    {
        public Slot()
        {
            _client = new ExpandoObject();
        }

        public Slot(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public int Number
        {
            get
            {
                if (_client is ExpandoObject) return _client.Number;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.Number; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Number = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}