using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ESAPIX.Facade.API;

namespace ESAPIX.Facade.Serialization
{
    public class FacadeSerializer
    {
        public static JsonSerializerSettings DeserializeSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.None,
                    Converters = new List<JsonConverter>() { new IEnumerableJsonConverter() }
                };
            }
        }

        public static JsonSerializerSettings SerializeSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.None,
                    ContractResolver = new InfiniteLoopResolver()
                };
            }
        }

        public static Patient DeserializePatient(string jsonPatient)
        {
            return JsonConvert.DeserializeObject<Patient>(jsonPatient, DeserializeSettings);
        }

        public static PlanSetup DeserializePlan(string jsonPlan)
        {
            return JsonConvert.DeserializeObject<PlanSetup>(jsonPlan, DeserializeSettings);
        }

        public static string SerializePlan(PlanSetup plan)
        {
            return JsonConvert.SerializeObject(plan, SerializeSettings);
        }

        public static string SerializePatient(Patient patient)
        {
            return JsonConvert.SerializeObject(patient, SerializeSettings);
        }
    }

}
