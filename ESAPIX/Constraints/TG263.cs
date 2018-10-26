using ESAPIX.Helpers.Strings;
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
        private static List<KeyValuePair<string, string>> _allowedPatternsAndTypes;
        private static List<string> _recommendedNames;

        public static (bool nameCompliant, bool typeCompliant, List<string> recommendNames, List<string> recommendedTypes) IsCompliant(string id, string type)
        {
            if (_allowedPatternsAndTypes == null) { LoadAllowances(); }

            List<string> recommendNames = new List<string>();
            List<string> recommendedTypes = new List<string>();

            //At least one name matches
            bool isAnyNameMatch = false;

            foreach (var allowedPatternAndType in _allowedPatternsAndTypes)
            {
                Regex nameValidator = new Regex(allowedPatternAndType.Key, RegexOptions.IgnoreCase);
                bool isNameMatch = nameValidator.IsMatch(id);
                bool isTypeMatch;
                if (allowedPatternAndType.Value.Equals("None", StringComparison.OrdinalIgnoreCase))
                    isTypeMatch = string.IsNullOrEmpty(type);
                else
                {
                    Regex regex = new Regex(@"[\s_]");
                    string expectedDicomType = regex.Replace(allowedPatternAndType.Value, string.Empty);
                    string actualDicomType = regex.Replace(type, string.Empty);
                    isTypeMatch = actualDicomType.Equals(expectedDicomType, StringComparison.OrdinalIgnoreCase);
                }

                //Good enough. Stop here
                if (isNameMatch && isTypeMatch) { return (true, true, recommendNames, recommendedTypes); }
                //Didn't match a type but remember we have at least one name match
                else if (isNameMatch)
                {
                    isAnyNameMatch = true;
                    recommendedTypes.Add(allowedPatternAndType.Value);
                }
            }

            if (!isAnyNameMatch)
            {
                //Get top 3 closest names to recommend
                recommendNames.AddRange(GetClosestNames(id, 5));
                //Return true on DICOM types because we can't evaluate here
                return (isAnyNameMatch, true, recommendNames, recommendedTypes);
            }

            return (isAnyNameMatch, false, recommendNames, recommendedTypes);
        }

        public static List<string> GetClosestNames(string id, int numberOfRecommendations)
        {
            if (_recommendedNames == null) { LoadRecommendedNames(); }

            var candidates = _recommendedNames.Select(s =>
            {
                var sourceWords = s.Split('_');
                var words = id.Split('_');
                return new
                {
                    RecommendedId = s,
                    Distance = Levenshtein.ComputeDistance(s.ToUpper(), id.ToUpper()),
                    BestWordDistance = BestWordDistance.Calculate(sourceWords, words)
                };
            })
           .OrderBy(s => Math.Min(s.BestWordDistance, s.Distance))
           .Take(numberOfRecommendations)
           .Select(s => s.RecommendedId).ToList();
            return candidates;
        }

        private static void LoadRecommendedNames()
        {
            _recommendedNames = new List<string>();
            var lines = Properties.Resources.StructureNamesConcrete.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            _recommendedNames.AddRange(lines);
        }

        private static void LoadAllowances()
        {
            var structureNamesStringBlob = Properties.Resources.AllowedStructureNames;
            string[] structureNamesLines = structureNamesStringBlob.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            _allowedPatternsAndTypes = new List<KeyValuePair<string, string>>();
            foreach (string l in structureNamesLines)
            {
                var keyvalue = l.Split('\t');
                if (keyvalue.Length == 2)
                    _allowedPatternsAndTypes.Add(new KeyValuePair<string, string>(keyvalue[0].Trim(), keyvalue[1].Trim().ToUpper()));
            }
        }
    }
}
