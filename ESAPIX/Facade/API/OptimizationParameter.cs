#region

using System.Dynamic;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationParameter : SerializableObject, System.Xml.Serialization.IXmlSerializable
    {
        public OptimizationParameter()
        {
            _client = new ExpandoObject();
        }

        public OptimizationParameter(dynamic client)
        {
            _client = client;
        }
    }
}