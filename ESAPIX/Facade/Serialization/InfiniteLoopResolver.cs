using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ESAPIX.Facade.Serialization
{
    /// <summary>
    /// This class prevents infinite looping (stack overflow) from occuring from circular references during serialization
    /// </summary>
    public class InfiniteLoopResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            Console.WriteLine(type.Name);
            var excludingNames = new List<string>();
            excludingNames.Add("MeshGeometry");
            switch (type.Name)
            {
                case "Course": excludingNames.Add("Patient"); break;
                case "ExternalPlanSetup": excludingNames.Add("Course"); break;
                case "BrachyPlanSetup": excludingNames.Add("Course"); break;
                case "PlanSetup": excludingNames.Add("Course"); break;
                case "PlanSum": excludingNames.Add("Course"); break;
                case "Image": excludingNames.Add("Series"); break;
                case "Series": excludingNames.Add("Study"); break;
            }
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            return props.Where(p => !excludingNames.Contains(p.PropertyName)).ToList();
        }
    }
}
