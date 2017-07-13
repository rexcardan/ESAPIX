#region

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Facade.Serialization
{
    public class DVHPointConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DVHPoint);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            var jo = JObject.Load(reader);

            // Read the properties which will be used as constructor parameters
            var jValue = (JObject) jo[nameof(DVHPoint.DoseValue)];
            var value = serializer.Deserialize<DoseValue>(jValue.CreateReader());
            var vol = (double) jo[nameof(DVHPoint.Volume)];
            var unit = (string) jo[nameof(DVHPoint.VolumeUnit)];

            // Construct the Result object using the non-default constructor
            var dp = new DVHPoint(value, vol, unit);

            // Return the result
            return dp;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}