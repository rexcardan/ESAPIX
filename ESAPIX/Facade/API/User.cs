using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class User : ApiDataObject
    {
        public User()
        {
            _client = new ExpandoObject();
        }

        public User(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public string Language
        {
            get
            {
                if (_client is ExpandoObject) return _client.Language;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.Language; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Language = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}