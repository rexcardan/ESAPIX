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
    public class ProfilePointConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ProfilePoint);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            JObject jo = JObject.Load(reader);

            // Read the properties which will be used as constructor parameters
            JObject jValue = (JObject)jo[nameof(ProfilePoint.Position)];
            var vect = serializer.Deserialize<VVector>(jValue.CreateReader());
            double value = (double)jo[nameof(ProfilePoint.Value)];

            // Construct the Result object using the non-default constructor
            ProfilePoint pp = new ProfilePoint(vect, value);
            // Return the result
            return pp;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
