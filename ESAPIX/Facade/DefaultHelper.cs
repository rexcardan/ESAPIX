#region

using System;

#endregion

namespace ESAPIX.Facade
{
    public class DefaultHelper
    {
        public static bool IsDefault(dynamic input)
        {
            if (Object.ReferenceEquals(null, input)
                return true;
            return false;
        }
    }
}