using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Facade
{
    public class DefaultHelper
    {
        public static bool IsDefault(dynamic input)
        {
            if (input == null)
            {
                return true;
            }
            else if (input.GetType().IsValueType)
            {
                return input == Activator.CreateInstance(input.GetType());
            }
            else
            {
                return false;
            }
        }
    }
}
