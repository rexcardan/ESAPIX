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
#if !VMS110
            typeof(IEnumerable<EstimatedDVH>),
            typeof(IEnumerable<ExternalPlanSetup>),
            typeof(IEnumerable<BrachyPlanSetup>),
            typeof(IEnumerable<Diagnosis>),
            typeof(IEnumerable<Catheter>),
            typeof(IEnumerable<BrachySolidApplicator>),
            typeof(IEnumerable<SeedCollection>),
            typeof(IEnumerable<ControlPointParameters>),
            typeof(IEnumerable<OptimizationObjective>),
            typeof(IEnumerable<OptimizationParameter>),
            typeof(IEnumerable<StructureCodeInfo>),
#endif
            typeof(IEnumerable<Course>),
            typeof(IEnumerable<PlanSetup>),
            typeof(IEnumerable<PlanSum>),
            typeof(IEnumerable<Image>),
            typeof(IEnumerable<PatientSummary>),
            typeof(IEnumerable<Study>),
            typeof(IEnumerable<Structure>),
            typeof(IEnumerable<StructureSet>),
            typeof(IEnumerable<Registration>),
            typeof(IEnumerable<Isodose>),
            typeof(IEnumerable<string>),
            typeof(IEnumerable<ReferencePoint>),
#if VMS155
            typeof(IEnumerable<ImageApprovalHistoryEntry>),
            typeof(IEnumerable<PlanTreatmentSession>),
            typeof(IEnumerable<StructureApprovalHistoryEntry>)
#endif
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
                        var item = JObject.Load(reader);
                        var val = item.Value<JObject>();
                       

                        try
                        {
                            var arrayr = val.First.CreateReader();
                            var tempList2 = JArray.Load(arrayr)
                            .Select(i => (dynamic)serializer.Deserialize(((JObject)i).CreateReader(), typ))
                            .ToList();
                            tempList2.ForEach(i => { list.Add(i); });
                        }
                        catch(Exception e)
                        {
                            var arrayr = val.First.First.CreateReader();
                            var tempList2 = JArray.Load(arrayr)
                            .Select(i => (dynamic)serializer.Deserialize(((JObject)i).CreateReader(), typ))
                            .ToList();
                            tempList2.ForEach(i => { list.Add(i); });
                        }
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