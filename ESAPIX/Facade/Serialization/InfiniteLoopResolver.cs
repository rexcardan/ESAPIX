#region

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;

#endregion

namespace ESAPIX.Facade.Serialization
{
    /// <summary>
    /// This class prevents infinite looping (stack overflow) from occuring from circular references during serialization
    /// </summary>
    public class InfiniteLoopResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            Debug.WriteLine(type.Name);
            var excludingNames = new List<string>();
            switch (type.Name)
            {
                case "Course":
                    excludingNames.Add("Patient");
                    break;
                case "ExternalPlanSetup":
                    excludingNames.Add("Course");
                    break;
                case "BrachyPlanSetup":
                    excludingNames.Add("Course");
                    break;
                case "PlanSetup":
                    excludingNames.Add("Course");
                    break;
                case "PlanSum":
                    excludingNames.Add("Course");
                    break;
                case "Image":
                    excludingNames.Add("Series");
                    break;
                case "Series":
                    excludingNames.Add("Study");
                    break;
            }
            var props = base.CreateProperties(type, memberSerialization);
            return props.Where(p => !excludingNames.Contains(p.PropertyName)).ToList();
        }
    }
}