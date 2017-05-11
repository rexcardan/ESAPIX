using ESAPIX.Facade.API;
using ESAPIX.Facade.Serialization;
using ESAPIX.OfflineObjects.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.OfflineObjects
{
    public class Samples
    {
        public static PlanSetup GetProstatePlanSetup()
        {
            var json = ASCIIEncoding.ASCII.GetString(Resources.plan);
            return JsonConvert.DeserializeObject<PlanSetup>(json, FacadeSerializer.DeserializeSettings);
        }
    }
}
