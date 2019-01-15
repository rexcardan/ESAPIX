using ESAPIX.Helpers.Strings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Structures
{
    public class TG263Dictionary
    {
        private static TG263Dictionary instance = null;
        private static readonly object padlock = new object();

        TG263Dictionary()
        {
            LoadDictionaryFromResources();
            IsLoaded = true;
        }

        public static TG263Dictionary Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new TG263Dictionary();
                        }
                    }
                }
                return instance;
            }
        }

        public bool IsLoaded { get; private set; }

        private List<TG263Structure> tg263Structures;

        public List<TG263Structure> GetDictionary()
        {
            if (tg263Structures == null) { LoadDictionaryFromResources(); }
            return tg263Structures;
        }

        private void LoadDictionaryFromResources()
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

            var test = tg263Structures.ToList();

            var append = new List<TG263Structure>();
            //LOAD CONCRETE NAMES
            for (int i = 0; i < tg263Structures.Count; i++)
            {
                var tg263 = tg263Structures[i];
                var lines = Properties.Resources.StructureNamesConcrete.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();
                lines = lines.Select(l => l.Replace("xx", "00")).ToList();

                var matches = lines.Where(l => (new Regex(tg263.StructureIdPattern, RegexOptions.IgnoreCase).IsMatch(l)));
                if (matches.Any())
                {
                    tg263.StructureIds = matches.Select(m =>
                    {
                        return new ConcreteStructureId()
                        {
                            StructureId = m,
                            StructIdWords = WordSplitter.Split(m)
                        };
                    }).ToArray();
                    
                 }
            }
        }

        /// <summary>
        /// Checks DICOM type by looking up all types which match the input structure Id
        /// </summary>
        /// <param name="id">the id of the structure in question</param>
        /// <param name="type">the user set type of the structure which will be validated</param>
        /// <returns>tuple of whether the type is correct and a list of valid types for this structure id</returns>
        public Task<(bool IsTypeOk, List<string> RecommendedTypes)> GetTypeCompliance(string id, string type)
        {
            return Task.Run(() =>
            {
                List<string> recommendedTypes = new List<string>();
                if (tg263Structures == null) { LoadDictionaryFromResources(); }
                foreach (var tg263 in tg263Structures)
                {
                    Regex nameValidator = new Regex(tg263.StructureIdPattern, RegexOptions.IgnoreCase);
                    bool isNameMatch = nameValidator.IsMatch(id);
                    if (isNameMatch)
                    {
                        if (!string.IsNullOrEmpty(tg263.DICOMType))
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
            });
        }

        public async Task<(bool IsNameOk, List<string> RecommendedNames)> GetNameCompliance(string id, bool doFetchRecommendations = true, int numIdRecommendations = 5)
        {
            if (id == null) { return (false, new List<string>()); }
            if (tg263Structures == null) { LoadDictionaryFromResources(); }
            foreach (var allowedPatternAndType in tg263Structures)
            {
                Regex nameValidator = new Regex(allowedPatternAndType.StructureIdPattern, RegexOptions.IgnoreCase);
                bool isNameMatch = nameValidator.IsMatch(id);
                if (isNameMatch) { return (true, new List<string>()); }
            }
            var recommendations = new List<string>();
            if (doFetchRecommendations)
            {
                var orderedConcrete = await StructureIdRecommender.GetClosestNames(id, numIdRecommendations);
                recommendations.AddRange(orderedConcrete.Select(o=>o.Id));
            }
             
            return (false, recommendations);
        }

        public class TG263Structure
        {
            public string StructureIdPattern { get; set; }
            public ConcreteStructureId[] StructureIds { get; set; }
            public string DICOMType { get; set; }

            public override string ToString()
            {
                return $"{string.Join(",",StructureIds.Select(s=>s.StructureId))} | {DICOMType} | {StructureIdPattern}";
            }
        }

        public class ConcreteStructureId
        {
            public string StructureId { get; set; }
            public List<string> StructIdWords { get; set; } = new List<string>();

            public override string ToString()
            {
                return $"{StructureId}";
            }
        }


    }
}
