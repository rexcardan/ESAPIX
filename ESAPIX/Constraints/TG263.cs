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
        public static async Task<(bool nameCompliant, bool typeCompliant, List<string> recommendNames, List<string> recommendedTypes)> IsCompliant(string id, string type, int numIdRecommendations = 5)
        {
            var (isNameMatch, recommendedNames) = await TG263Dictionary.Instance.GetNameCompliance(id, true, numIdRecommendations);
            if (isNameMatch)
            {
                var (isTypeMatch, recommendedTypes) = await TG263Dictionary.Instance.GetTypeCompliance(id, type);
                //Good enough. Stop here
                if (isNameMatch && isTypeMatch) { return (true, true, recommendedNames, recommendedTypes); }
            }
            return (isNameMatch, false, recommendedNames, new List<string>());
        }
    }
}
