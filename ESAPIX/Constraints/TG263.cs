using ESAPIX.Helpers.Strings;
using ESAPIX.Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESAPIX.Constraints
{
    public class TG263
    {
        public static (bool nameCompliant, bool typeCompliant, List<string> recommendNames, List<string> recommendedTypes) IsCompliant(string id, string type)
        {

            var (isNameMatch, recommendedNames) = TG263Dictionary.GetNameCompliance(id);
            if (isNameMatch)
            {
                var (isTypeMatch, recommendedTypes) = TG263Dictionary.GetTypeCompliance(id, type);
                //Good enough. Stop here
                if (isNameMatch && isTypeMatch) { return (true, true, recommendedNames, recommendedTypes); }
            }
            return (isNameMatch, false, recommendedNames, new List<string>());
        }
    }
}
