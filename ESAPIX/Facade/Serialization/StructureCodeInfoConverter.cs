#region

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VMS.TPS.Common.Model.Types;

#endregion

namespace ESAPIX.Facade.Serialization
{
#if !VMS110
    public class StructureCodeInfoConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(StructureCodeInfo);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            var jo = JObject.Load(reader);

            // Read the properties which will be used as constructor parameters
            var codingScheme = (string) jo["CodingScheme"];
            var code = (string) jo["Code"];

            // Construct the Result object using the non-default constructor
            var ci = new StructureCodeInfo(codingScheme, code);

            // Return the result
            return ci;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
#endif
}