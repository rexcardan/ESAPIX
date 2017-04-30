using System;
using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class AddOn : ApiDataObject
    {
        public AddOn()
        {
            _client = new ExpandoObject();
        }

        public AddOn(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public DateTime? CreationDateTime
        {
            get
            {
                if (_client is ExpandoObject) return _client.CreationDateTime;
                var local = this;
                return X.Instance.CurrentContext.GetValue<DateTime?>(sc => { return local._client.CreationDateTime; });
            }
            set
            {
                if (_client is ExpandoObject) _client.CreationDateTime = value;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}