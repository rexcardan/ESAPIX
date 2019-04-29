using ESAPIX.Helpers.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ESAPIX.Helpers.Structures.TG263Dictionary;

namespace ESAPIX.Helpers.Structures
{
    public class StructureIdRecommender
    {
        public static async Task<List<StringMetrics>> GetClosestNames(string id, int numberOfRecommendations)
        {
            return await Task.Run(() =>
            {
                List<string> closest = new List<string>();

                var twoDigit = Regex.Match(id, @"\d{2}").Value;
                var fourDigit = Regex.Match(id, @"\d{4}").Value;

                var dict = TG263Dictionary.Instance.GetDictionary();

                var targetWords = WordSplitter.Split(id);

                var commentPermutations = GetCommentedPermutations(id);
                var commented = commentPermutations
                    .Where(c =>
                    {
                        var isOkay = TG263Dictionary.Instance.GetNameCompliance(c, false).GetAwaiter().GetResult();
                        return isOkay.IsNameOk;
                    })
                    .Select(c =>
                    {
                        var commentWords = WordSplitter.Split(c);
                        return new ConcreteStructureId()
                        {
                            StructureId = c,
                            StructIdWords = commentWords
                        };
                    }).ToList();

                var concreteIds = dict.Where(d => d.StructureIds != null && d.StructureIds.Any())
                    .SelectMany(s => s.StructureIds)
                    .Concat(commented).ToList();

                var candidates = concreteIds.Select(s =>
                {
                    var strId = s.StructureId;
                    var words = s.StructIdWords.ToArray();
                    if (strId.Contains("00") && !string.IsNullOrEmpty(twoDigit))
                    {
                        strId = strId.Replace("00", twoDigit);
                        words = words.Select(w => w.Replace("00", twoDigit)).ToArray();
                    }
                    var metric = new StringMetrics()
                    {
                        Id = strId,
                        Dice = Dice.ComputeDistance(strId.ToUpper(), id.ToUpper()),
                        Levenshtein = Levenshtein.ComputeDistance(strId.ToUpper(), id.ToUpper())
                    };
                    return metric;
                }).ToList();

                //SORT
                var ordered = candidates
                    .OrderBy(s => (s.Dice*s.Levenshtein));

                return ordered.Take(numberOfRecommendations).ToList();
            });
        }

        /// <summary>
        /// Calculates commented permutations of an input structure Id by inserting a ^ into each 
        /// character space after 3 (eg. PTV4500 => PTV^4500, PTV4^500...)
        /// </summary>
        /// <param name="id">the input structure id to be manipulated</param>
        /// <returns></returns>
        private static List<string> GetCommentedPermutations(string id)
        {
            List<string> permutations = new List<string>();
            for (int i = 3; i < id.Length; i++)
            {
                var newId = id.Substring(0, i) + "^" + id.Substring(i, id.Length - i);
                //Remove whitespace
                newId = Regex.Replace(newId, @"\s+", "");
                permutations.Add(newId);
            }
            if (id.Contains("_"))
                permutations.Add(id.Replace("_", "^"));
            return permutations;
        }
    }
}
