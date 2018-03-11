#region

using System;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;

#endregion

namespace ESAPIX.AppKit.Data
{
    public class JsonDataStore<T> : AbstractStringDataStore<T>
    {
        private readonly JsonSerializerSettings _settings;

        public JsonDataStore(string fileExtension, Func<T, string> fileNamingMethod, string storePath = "") : base(
            fileExtension, fileNamingMethod, storePath)
        {
            _settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            };
        }

        public override SecureStorage<T> Deserialize(string serial)
        {
            AppDomain.CurrentDomain.AssemblyResolve += ESAPI_APPDOMAIN_HANDLER;
            var converted = JsonConvert.DeserializeObject<SecureStorage<T>>(serial, _settings);
            AppDomain.CurrentDomain.AssemblyResolve -= ESAPI_APPDOMAIN_HANDLER;
            return converted;
        }

        /// <summary>
        ///     This is a hack to help resolve issues when loading plugin scripts. Occaisionally, an assembly might
        ///     not be loaded in the current AppDomain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly ESAPI_APPDOMAIN_HANDLER(object sender, ResolveEventArgs args)
        {
            if (args.Name == typeof(T).Assembly.GetName().Name)
                return typeof(T).Assembly;
            return null;
        }

        public override string Serialize(SecureStorage<T> toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize, Formatting.Indented, _settings);
        }

        public override string Serialize(T toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize, Formatting.Indented, _settings);
        }
    }
}