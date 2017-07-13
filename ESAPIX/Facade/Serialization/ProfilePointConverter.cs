#region

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Facade.Serialization
{
    public class ProfilePointConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ProfilePoint);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            var jo = JObject.Load(reader);

            // Read the properties which will be used as constructor parameters
            var jValue = (JObject) jo[nameof(ProfilePoint.Position)];
            var vect = serializer.Deserialize<VVector>(jValue.CreateReader());
            var value = (double) jo[nameof(ProfilePoint.Value)];

            // Construct the Result object using the non-default constructor
            var pp = new ProfilePoint(vect, value);
            // Return the result
            return pp;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}