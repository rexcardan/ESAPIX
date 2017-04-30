#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

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

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

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

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}