#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class PlanningItemDose : Dose
    {
        public PlanningItemDose()
        {
            _client = new ExpandoObject();
        }

        public PlanningItemDose(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}