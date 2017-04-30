using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class Applicator : AddOn
    {
        public Applicator()
        {
            _client = new ExpandoObject();
        }

        public Applicator(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}