using ESAPIX.Facade.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Extensions
{
    public static class PatientExtensions
    {
        public static void Serialize(this Patient pat, string path)
        {
            string json = JsonConvert.SerializeObject(pat, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            File.WriteAllText(path, json);
        }
    }
}
