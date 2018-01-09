#region

using System.Dynamic;

#endregion

namespace ESAPIX.Facade.API
{
    public class Tray : AddOn, System.Xml.Serialization.IXmlSerializable
    {
        public Tray()
        {
            _client = new ExpandoObject();
        }

        public Tray(dynamic client)
        {
            _client = client;
        }
    }
}