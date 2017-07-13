#region

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VMS.TPS.Common.Model.Types;
using static VMS.TPS.Common.Model.Types.DoseValue;

#endregion

namespace ESAPIX.Facade.Serialization
{
    public class DoseProfileConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DoseProfile);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            var jo = JObject.Load(reader);
            var unitJO = (JValue) jo[nameof(DoseProfile.Unit)];
            var unit = serializer.Deserialize<DoseUnit>(unitJO.CreateReader());

            // Load the JSON for the Result into a JObject
            var ja = JArray.Load(jo["Points"].CreateReader());

            var points = ja
                .Select(j => serializer.Deserialize<ProfilePoint>(((JObject) j).CreateReader()))
                .ToList();

            var first = points[0];
            var second = points[1];

            var values = points.Select(p => p.Value).ToList();

            // Construct the Result object using the non-default constructor
            var dp = new DoseProfile(first.Position, second.Position - first.Position, values.ToArray(), unit);

            // Return the result
            return dp;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dp = value as DoseProfile;
            var unitProperty = new JProperty(nameof(DoseProfile.Unit), dp.Unit);
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(DoseProfile.Unit));
            serializer.Serialize(writer, dp.Unit);

            writer.WritePropertyName("Points");
            serializer.Serialize(writer, dp.ToArray());
            writer.WriteEndObject();
        }
    }
}