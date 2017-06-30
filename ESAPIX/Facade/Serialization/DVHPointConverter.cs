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
    public class DVHPointConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DVHPoint);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            JObject jo = JObject.Load(reader);

            // Read the properties which will be used as constructor parameters
            JObject jValue = (JObject)jo[nameof(DVHPoint.DoseValue)];
            var value = serializer.Deserialize<DoseValue>(jValue.CreateReader());
            double vol = (double)jo[nameof(DVHPoint.Volume)];
            string unit = (string)jo[nameof(DVHPoint.VolumeUnit)];

            // Construct the Result object using the non-default constructor
            DVHPoint dp = new DVHPoint(value, vol, unit);

            // Return the result
            return dp;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
