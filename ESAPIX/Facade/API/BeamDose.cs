#region

using System.Dynamic;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class BeamDose : Dose, System.Xml.Serialization.IXmlSerializable
    {
        public BeamDose()
        {
            _client = new ExpandoObject();
        }

        public BeamDose(dynamic client)
        {
            _client = client;
        }
    }
}