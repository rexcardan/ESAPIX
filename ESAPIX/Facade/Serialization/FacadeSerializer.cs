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
                    Converters = new List<JsonConverter> {
                        new IEnumerableJsonConverter(),
                        new MeshGeometryConverter() ,
                        new DoseValueConverter()},

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

        /// <summary>
        /// Serialize to JSON string
        /// </summary>
        /// <param name="o">object to be serialized</param>
        /// <returns>json string of object</returns>
        public static string Serialize(object o)
        {
            var json = JsonConvert.SerializeObject(o, FacadeSerializer.SerializeSettings);
            return json;
        }

        /// <summary>
        /// Serialize to text file (json)
        /// </summary>
        /// <param name="o">object to be serialized</param>
        /// <param name="jsonPath">file path to save object file</param>
        public static void SerializeToFile(object o, string jsonPath)
        {
            var json = Serialize(o);
            File.WriteAllText(jsonPath, json);
        }

        /// <summary>
        /// Deserialize from JSON string
        /// </summary>
        /// <typeparam name="T">the type of object to be returned</typeparam>
        /// <param name="json">json string of object</param>
        /// <returns>object</returns>
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, FacadeSerializer.DeserializeSettings);
        }

        /// <summary>
        /// Deserialize from JSON string
        /// </summary>
        /// <typeparam name="T">the type of object to be returned</typeparam>
        /// <param name="jsonPath">file path to save object file</param>
        /// <returns>object</returns>
        public static T DeserializeFromFile<T>(string jsonPath)
        {
            var json = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<T>(json, FacadeSerializer.DeserializeSettings);
        }

        public static void SerializeContext(IScriptContext ctx, string jsonPath)
        {
            SerializeToFile(ctx, jsonPath);
        }

        public static OfflineContext DeserializeContext(string jsonPath)
        {
            var ctx = DeserializeFromFile<OfflineContext>(jsonPath);
            //BRACHY
            if (ctx.BrachyPlanSetup != null) { ctx.BrachyPlanSetup.Course = ctx.Course; }
            if (ctx.BrachyPlansInScope != null)
            {
                foreach (var ps in ctx.BrachyPlansInScope)
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