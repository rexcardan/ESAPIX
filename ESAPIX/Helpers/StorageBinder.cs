using ESAPIX.AppKit.Data;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers
{
    public class StorageBinder<T> : DefaultSerializationBinder
    {
        /// <summary>
        /// This is a hack to get the storage service to work with wrapped content. Currently a bug in JSON.net
        /// relying on assembles to be in current app domain.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (typeName.StartsWith("ESAPIX.AppKit.Data.SecureStorage"))
                return typeof(SecureStorage<T>);
            else
            {
                return base.BindToType(assemblyName, typeName);
            }
        }
    }
}
