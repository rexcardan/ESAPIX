#region

using System.Collections.Generic;
using System.Dynamic;

#endregion

namespace ESAPIX.Extensions
{
    public static class ExpandoExtensions
    {
        public static bool HasProperty(this ExpandoObject expando, string propName)
        {
            return ((IDictionary<string, object>) expando).ContainsKey(propName);
        }
    }
}