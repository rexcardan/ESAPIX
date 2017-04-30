#region

using System;

#endregion

namespace ESAPIX.Facade
{
    public class DefaultHelper
    {
        public static bool IsDefault(dynamic input)
        {
            if (input == null)
                return true;
            if (input.GetType().IsValueType)
                return input == Activator.CreateInstance(input.GetType());
            return false;
        }
    }
}