#region

using System;
using System.Collections.Generic;
using System.Linq;
using ESAPIX.Facade.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace ESAPIX.Facade.Serialization
{
    public class IEnumerableJsonConverter : JsonConverter
    {
        private readonly List<Type> neededTypes = new List<Type>
        {
            typeof(IEnumerable<Block>),
            typeof(IEnumerable<Beam>),
            typeof(IEnumerable<Block>),
            typeof(IEnumerable<Bolus>),
            typeof(IEnumerable<BeamCalculationLog>),
            typeof(IEnumerable<FieldReferencePoint>),
            typeof(IEnumerable<Tray>),
            typeof(IEnumerable<Wedge>),
            typeof(IEnumerable<EstimatedDVH>),
            typeof(IEnumerable<Course>),
            typeof(IEnumerable<PlanSetup>),
            typeof(IEnumerable<PlanSum>),
            typeof(IEnumerable<ExternalPlanSetup>),
            typeof(IEnumerable<BrachyPlanSetup>),
            typeof(IEnumerable<Diagnosis>),
            typeof(IEnumerable<Image>),
            typeof(IEnumerable<Catheter>),
            typeof(IEnumerable<BrachySolidApplicator>),
            typeof(IEnumerable<SeedCollection>),
            typeof(IEnumerable<ControlPointParameters>),
            typeof(IEnumerable<PatientSummary>),
            typeof(IEnumerable<Structure>)
        };

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            var interfaces = objectType.GetInterfaces();
            foreach (var intf in interfaces)
                if (neededTypes.Contains(intf))
                    return true;
            return neededTypes.Contains(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var typ = objectType.GenericTypeArguments.FirstOrDefault();
            if (typ != null)
                if (objectType != typeof(string))
                {
                    var listGenericType = typeof(List<>);

                    var listType = listGenericType.MakeGenericType(typ);
                    dynamic list = Activator.CreateInstance(listType);

                    JArray.Load(reader)
                        .Select(i =>
                        {
                            dynamic ins = Activator.CreateInstance(typ);
                            JsonConvert.PopulateObject(i.ToString(), ins, new JsonSerializerSettings
                            {
                                Converters = new List<JsonConverter> {this}
                            });
                            return ins;
                        })
                        .ToList()
                        .ForEach(i => { list.Add(i); });

                    return list;
                }

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}