#region

using System.Dynamic;

#endregion

namespace ESAPIX.Facade.API
{
    public class Technique : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public Technique()
        {
            _client = new ExpandoObject();
        }

        public Technique(dynamic client)
        {
            _client = client;
        }
    }
}