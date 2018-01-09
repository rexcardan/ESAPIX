#region

using System.Dynamic;

#endregion

namespace ESAPIX.Facade.API
{
    public class ReferencePoint : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public ReferencePoint()
        {
            _client = new ExpandoObject();
        }

        public ReferencePoint(dynamic client)
        {
            _client = client;
        }
    }
}