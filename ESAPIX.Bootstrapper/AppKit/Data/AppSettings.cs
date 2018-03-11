#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

#endregion

namespace ESAPIX.AppKit.Data
{
    public class AppSettings
    {
        public Dictionary<string, object> Settings { get; set; } = new Dictionary<string, object>();

        public static AppSettings Load(string settingsPath = "")
        {
            var path = string.IsNullOrEmpty(settingsPath) ? StorageHelper.GetSettingsPath() : settingsPath;
            if (File.Exists(path))
            {
                var read = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<AppSettings>(read);
            }
            return new AppSettings();
        }

        public bool Save(string settingsPath = "")
        {
            try
            {
                var path = string.IsNullOrEmpty(settingsPath) ? StorageHelper.GetSettingsPath() : settingsPath;
                StorageHelper.CreateBasePathIfNotExists(path);
                var json = JsonConvert.SerializeObject(this);
                File.WriteAllText(path, json);
                return true;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
        }

        public T Get<T>(string key)
        {
            if (Settings.ContainsKey(key))
                if (typeof(T) == typeof(string))
                    return (T) Settings[key];
                else
                    return JsonConvert.DeserializeObject<T>(Settings[key].ToString());
            return default(T);
        }

        public void Set(string key, object value)
        {
            if (Settings.ContainsKey(key))
                Settings[key] = value;
            else Settings.Add(key, value);
        }
    }
}