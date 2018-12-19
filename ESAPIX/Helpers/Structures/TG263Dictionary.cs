using ESAPIX.Helpers.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Structures
{
    public class TG263Dictionary
    {
        private static List<TG263Structure> tg263Structures;

        public static List<TG263Structure> GetDictionary()
        {
            if (tg263Structures == null) { LoadDictionaryFromResources(); }
            return tg263Structures;
        }

        private static void LoadDictionaryFromResources()
        {
            //LOAD REGEX PATTERNS AND TYPES
            var structureNamesStringBlob = Properties.Resources.AllowedStructureNames;
            string[] structureNamesLines = structureNamesStringBlob.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            tg263Structures = new List<TG263Structure>();
            foreach (string l in structureNamesLines)
            {
                var keyvalue = l.Split('\t');
                if (keyvalue.Length == 2)
                {
                    var str = new TG263Structure()
                    {
                        StructureIdPattern = keyvalue[0].Trim(),
                        DICOMType = keyvalue[1].Trim().ToUpper(),
                    };
                    tg263Structures.Add(str);
                }
            }

            //LOAD CONCRETE NAMES
            foreach (var tg263 in tg263Structures)
            {
                var lines = Properties.Resources.StructureNamesConcrete.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                var match = lines.FirstOrDefault(l => (new Regex(tg263.StructureIdPattern, RegexOptions.IgnoreCase).IsMatch(l)));
                if (match != null)
                {
                    tg263.StructureId = match;
                    var sourceWords = tg263.StructureId.Split('_').ToList();
                    sourceWords.AddRange(StringHelper.SplitCamelCase(tg263.StructureId));
                    sourceWords = sourceWords.Distinct().ToList();
                    tg263.StructIdWords.AddRange(sourceWords);
                }
            }
        }

        /// <summary>
        /// Checks DICOM type by looking up all types which match the input structure Id
        /// </summary>
        /// <param name="id">the id of the structure in question</param>
        /// <param name="type">the user set type of the structure which will be validated</param>
        /// <returns>tuple of whether the type is correct and a list of valid types for this structure id</returns>
        public static (bool IsTypeOk, List<string> RecommendedTypes) GetTypeCompliance(string id, string type)
        {
            List<string> recommendedTypes = new List<string>();
            if (tg263Structures == null) { LoadDictionaryFromResources(); }
            foreach (var tg263 in tg263Structures)
            {
                Regex nameValidator = new Regex(tg263.StructureIdPattern, RegexOptions.IgnoreCase);
                bool isNameMatch = nameValidator.IsMatch(id);
                if (isNameMatch)
                {
                    recommendedTypes.Add(tg263.DICOMType);
                }
            }

            var matchedType = recommendedTypes.Any(rt =>
           {
               //Check type
               if (rt.Equals("None", StringComparison.OrdinalIgnoreCase))
                   return string.IsNullOrEmpty(type);
               else
               {
                   Regex regex = new Regex(@"[\s_]");
                   string expectedDicomType = regex.Replace(rt, string.Empty);
                   string actualDicomType = regex.Replace(type, string.Empty);
                   return actualDicomType.Equals(expectedDicomType, StringComparison.OrdinalIgnoreCase);
               }
           });

            return (matchedType, recommendedTypes);
        }

        public static (bool IsNameOk, List<string> RecommendedNames) GetNameCompliance(string id, bool doFetchRecommendations = true)
        {
            if (tg263Structures == null) { LoadDictionaryFromResources(); }
            foreach (var allowedPatternAndType in tg263Structures)
            {
                Regex nameValidator = new Regex(allowedPatternAndType.StructureIdPattern, RegexOptions.IgnoreCase);
                bool isNameMatch = nameValidator.IsMatch(id);
                if (isNameMatch) { return (true, new List<string>()); }
            }
            var recommendations = new List<string>();
            if (doFetchRecommendations)
                recommendations.AddRange(StructureIdRecommender.GetClosestNames(id, 5));
            return (false, recommendations);
        }

        public class TG263Structure
        {
            public string StructureIdPattern { get; set; }
            public string StructureId { get; set; }
            public string DICOMType { get; set; }
            public List<string> StructIdWords { get; set; } = new List<string>();
        }
    }
}
