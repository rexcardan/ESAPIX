using System.Dynamic;
using System.Xml;
using System.Xml.Schema;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class SerializableObject
    {
        internal dynamic _client;

        public SerializableObject()
        {
            _client = new ExpandoObject();
        }

        public SerializableObject(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public XmlSchema GetSchema()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetSchema(); });
            return retVal;
        }

        public void ReadXml(XmlReader reader)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.ReadXml(reader); });
        }

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public static void ClearSerializationHistory()
        {
            StaticHelper.SerializableObject_ClearSerializationHistory();
        }
    }
}