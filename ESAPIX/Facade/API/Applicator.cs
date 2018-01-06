#region

using System.Dynamic;

#endregion

namespace ESAPIX.Facade.API
{
    public class Applicator : AddOn, System.Xml.Serialization.IXmlSerializable
    {
        public Applicator()
        {
            _client = new ExpandoObject();
        }

        public Applicator(dynamic client)
        {
            _client = client;
        }
    }
}