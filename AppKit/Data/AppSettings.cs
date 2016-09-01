using ESAPIX.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.AppKit.Data
{
    public class AppSettings
    {
        private Dictionary<string, object> Settings { get; set; } = new Dictionary<string, object>();

        public static async Task<AppSettings> LoadAsync(string settingsPath = "")
        {
            var path = string.IsNullOrEmpty(settingsPath) ? StorageHelper.GetSettingsPath() : settingsPath;
            if (File.Exists(path))
            {
                var read = File.ReadAllText(path);
                return await Task.Run<AppSettings>(() => JsonConvert.DeserializeObject<AppSettings>(read));
            }
            else
            {
                return new AppSettings();
            }
        }

        public void Save(string settingsPath = "")
        {
            var path = string.IsNullOrEmpty(settingsPath) ? StorageHelper.GetSettingsPath() : settingsPath;
            StorageHelper.CreateBasePathIfNotExists(path);
            var json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, json);
        }

        public T Get<T>(string key)
        {
            if (Settings.ContainsKey(key))
            {
                if (Settings[key] is T)
                {
                    return (T)Settings[key];
                }
                else { throw new InvalidCastException($"Object not of type {default(T).GetType()}"); }
            }
            return default(T) ;
        }

        public void Set(string key, object value)
        {
            if (Settings.ContainsKey(key))
            {
                Settings[key] = value;
            }
            else { Settings.Add(key, value); }
        }
    }
}
