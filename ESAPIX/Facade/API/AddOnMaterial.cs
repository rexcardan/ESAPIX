#region

using System.Dynamic;

#endregion

namespace ESAPIX.Facade.API
{
    public class AddOnMaterial : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public AddOnMaterial()
        {
            _client = new ExpandoObject();
        }

        public AddOnMaterial(dynamic client)
        {
            _client = client;
        }
    }
}