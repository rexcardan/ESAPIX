using ESAPIX.Facade.API;
using ESAPIX.Facade.Serialization;
using ESAPIX.OfflineObjects.Properties;
using Newtonsoft.Json;
using System.Text;
using ESAPIX.Facade;

namespace ESAPIX.OfflineObjects
{
    public class Samples
    {
        public static PlanSetup GetProstatePlanSetup()
        {
            var json = ASCIIEncoding.ASCII.GetString(Resources.plan);
            var ps = JsonConvert.DeserializeObject<PlanSetup>(json, FacadeSerializer.DeserializeSettings);
            var client = ExpandoGetter.GetClient(ps);
            return ps;
            //ps.GetDoseAtVolume()
        }
    }
}
