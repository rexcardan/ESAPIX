#region

using System.Collections.Generic;
using ESAPIX.Facade.API;
using Newtonsoft.Json;

#endregion

namespace ESAPIX.Facade.Serialization
{
    public class FacadeSerializer
    {
        public static JsonSerializerSettings DeserializeSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                    Converters = new List<JsonConverter> {new IEnumerableJsonConverter(), new MeshGeometryConverter()}
                };
            }
        }

        public static JsonSerializerSettings SerializeSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                    ContractResolver = new ESAPIContractResolver()
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