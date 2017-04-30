using System.Dynamic;
using System.Xml;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.API
{
    public class OptimizationParameter : SerializableObject
    {
        public OptimizationParameter()
        {
            _client = new ExpandoObject();
        }

        public OptimizationParameter(dynamic client)
        {
            _client = client;
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public void WriteXml(XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }

        public bool Equals(object obj)
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.Equals(obj); });
            return retVal;
        }

        public int GetHashCode()
        {
            var local = this;
            var retVal = X.Instance.CurrentContext.GetValue(sc => { return local._client.GetHashCode(); });
            return retVal;
        }
    }
}