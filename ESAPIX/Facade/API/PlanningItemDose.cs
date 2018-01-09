#region

using System.Dynamic;

#endregion

namespace ESAPIX.Facade.API
{
    public class PlanningItemDose : Dose, System.Xml.Serialization.IXmlSerializable
    {
        public PlanningItemDose()
        {
            _client = new ExpandoObject();
        }

        public PlanningItemDose(dynamic client)
        {
            _client = client;
        }
    }
}