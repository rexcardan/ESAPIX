#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;
using ESAPIX.Facade.API;
using ESAPIX.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#endregion

namespace ESAPIX.Facade.Serialization
{
    public class ESAPIContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            //INFINITE LOOP
            var excludingNames = new List<string>();
            switch (type.Name)
            {
                case nameof(IScriptContext.Course):
                    excludingNames.Add(nameof(Course.Patient));
                    break;
                case nameof(IScriptContext.ExternalPlanSetup):
                    excludingNames.Add(nameof(ExternalPlanSetup.Course));
                    break;
                case nameof(IScriptContext.BrachyPlanSetup):
                    excludingNames.Add(nameof(BrachyPlanSetup.Course));
                    break;
                case nameof(IScriptContext.PlanSetup):
                    excludingNames.Add(nameof(PlanSetup.Course));
                    break;
                case nameof(PlanSum):
                    excludingNames.Add(nameof(PlanSum.Course));
                    break;
                case nameof(Image.Series):
                    excludingNames.Add(nameof(Series.Images));
                    break;
                case nameof(Series.Study):
                    excludingNames.Add(nameof(Study.Series));
                    break;
            }

            //MESH GEOMETRY
            if (type == typeof(MeshGeometry3D))
            {
                var mesh = new MeshGeometry3D();
                excludingNames.Add(nameof(mesh.Bounds));
                excludingNames.Add(nameof(mesh.CanFreeze));
                excludingNames.Add(nameof(mesh.DependencyObjectType));
                excludingNames.Add(nameof(mesh.Dispatcher));
                excludingNames.Add(nameof(mesh.HasAnimatedProperties));
                excludingNames.Add(nameof(mesh.IsFrozen));
                excludingNames.Add(nameof(mesh.IsSealed));
            }

            //IVMS Thread
            excludingNames.Add(nameof(IScriptContext.Thread));

            var props = base.CreateProperties(type, memberSerialization);
            return props.Where(p => !excludingNames.Contains(p.PropertyName)).ToList();
        }
    }
}