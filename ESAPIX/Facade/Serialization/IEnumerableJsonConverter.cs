#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ESAPIX.Facade.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VMS.TPS.Common.Model.Types;

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
            typeof(IEnumerable<Study>),
            typeof(IEnumerable<Structure>),
            typeof(IEnumerable<StructureSet>),
            typeof(IEnumerable<OptimizationObjective>),
            typeof(IEnumerable<Registration>),
            typeof(IEnumerable<OptimizationParameter>),
            typeof(IEnumerable<StructureCodeInfo>),
            typeof(IEnumerable<Isodose>),
            typeof(IEnumerable<string>)
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

                    try
                    {
                        Activator.CreateInstance(listType);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine($"Can't create type {listType}");
                    }
                    dynamic list = Activator.CreateInstance(listType);

                    try
                    {
                        JArray.Load(reader)
                            .Select(i => (dynamic) serializer.Deserialize(((JObject) i).CreateReader(), typ))
                            .ToList()
                            .ForEach(i => { list.Add(i); });
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                        reader.Skip();
                    }
                    return list;
                }

            return existingValue;
        }

        private dynamic Populate(JToken i, Type typ)
        {
            if (typ == typeof(string))
            {
                var value = i.Value<string>();
                return value;
            }
            dynamic ins = Activator.CreateInstance(typ);
            JsonConvert.PopulateObject(i.ToString(), ins, FacadeSerializer.DeserializeSettings);
            return ins;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}