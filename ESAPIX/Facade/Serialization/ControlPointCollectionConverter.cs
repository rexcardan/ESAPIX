using ESAPIX.Facade.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Facade.Serialization
{
    public class ControlPointCollectionConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ControlPointCollection);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            var jo = JArray.Load(reader);
            var list = jo.Select(i => (ControlPoint)serializer.Deserialize(((JObject)i).CreateReader(), typeof(ControlPoint)))
                            .ToList();

            return new ControlPointCollection(list);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
