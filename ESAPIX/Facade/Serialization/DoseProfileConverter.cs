using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.Types;
using static VMS.TPS.Common.Model.Types.DoseValue;

namespace ESAPIX.Facade.Serialization
{
    public class DoseProfileConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DoseProfile);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        { 
            
            // Load the JSON for the Result into a JObject
            JObject jo = JObject.Load(reader);
            double value = (double)jo["Dose"];
            // Load the JSON for the Result into a JObject
            JArray ja = JArray.Load(reader);

            var points = ja
                .Select(j => serializer.Deserialize<ProfilePoint>(((JObject)j).CreateReader()))
                .ToList();

            var first = points[0];
            var second = points[1];

            var values = points.Select(p => p.Value).ToList();

            // Construct the Result object using the non-default constructor
            DoseProfile dp = new DoseProfile(first.Position, second.Position - first.Position, values.ToArray(), DoseValue.DoseUnit.Gy);

            // Return the result
            return dp;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dp = value as DoseProfile;
            JProperty unitProperty = new JProperty(nameof(DoseProfile.Unit), dp.Unit);
            JObject jo = new JObject();
            jo.Add(unitProperty);
            jo.Add(new JProperty("Points", dp));
            jo.WriteTo(writer);
        }
    }
}
