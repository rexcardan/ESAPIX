using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.Types;

namespace ESAPIX.Facade.Serialization
{
    public class DoseValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DoseValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            JObject jo = JObject.Load(reader);

            // Read the properties which will be used as constructor parameters
            double value = (double)jo["Dose"];
            var unit = jo["Unit"].ToObject<DoseValue.DoseUnit>();

            // Construct the Result object using the non-default constructor
            DoseValue dv = new DoseValue(value, unit);

            // Return the result
            return dv;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
