#region

using System.Collections.Generic;
using ESAPIX.Facade.API;
using Newtonsoft.Json;
using ESAPIX.Interfaces;
using ESAPIX.AppKit;
using System.IO;
using System.Linq.Expressions;
using System;

#endregion

namespace ESAPIX.Facade.Serialization
{
    public static class FacadeSerializer
    {
        public static JsonSerializerSettings DeserializeSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                    Converters = new List<JsonConverter> { new IEnumerableJsonConverter(), new MeshGeometryConverter() },
                    ContractResolver = new ESAPIContractResolver()
                };
            }
        }

        public static JsonSerializerSettings SerializeSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                    ContractResolver = new ESAPIContractResolver()
                };
            }
        }

        public static void SerializeContext(IScriptContext ctx, string jsonPath)
        {
            var json = JsonConvert.SerializeObject(ctx, FacadeSerializer.SerializeSettings);
            File.WriteAllText(@"C:\Users\vision\Desktop\fakeContext.json", json);
        }

        public static OfflineContext DeserializeContext(string jsonPath)
        {
            var json = File.ReadAllText(jsonPath);
            var ctx = JsonConvert.DeserializeObject<OfflineContext>(json, Facade.Serialization.FacadeSerializer.DeserializeSettings);
            //BRACHY
            if (ctx.BrachyPlanSetup != null) { ctx.BrachyPlanSetup.Course = ctx.Course; }
            if (ctx.BrachyPlansInScope != null)
            {
                foreach(var ps in ctx.BrachyPlansInScope)
                {
                    ps.Course = ctx.Course;
                }
            }
            //PLAN SETUPS
            if (ctx.PlanSetup != null) { ctx.PlanSetup.Course = ctx.Course; }
            if (ctx.PlansInScope != null)
            {
                foreach (var ps in ctx.PlansInScope)
                {
                    ps.Course = ctx.Course;
                }
            }
            //EXTERNAL PLAN SETUPS
            if (ctx.ExternalPlanSetup != null) { ctx.ExternalPlanSetup.Course = ctx.Course; }
            if (ctx.ExternalPlansInScope != null)
            {
                foreach (var ps in ctx.PlansInScope)
                {
                    ps.Course = ctx.Course;
                }
            }

            //PLAN SUMS
            if (ctx.PlanSumsInScope != null)
            {
                foreach (var ps in ctx.PlanSumsInScope)
                {
                    ps.Course = ctx.Course;
                }
            }

            return ctx;
        }

    }
}