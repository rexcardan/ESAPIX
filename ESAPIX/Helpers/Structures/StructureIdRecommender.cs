using ESAPIX.Helpers.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Structures
{
    public class StructureIdRecommender
    {
        public static List<string> GetClosestNames(string id, int numberOfRecommendations)
        {
            List<string> closest = new List<string>();

            var dict = TG263Dictionary.GetDictionary();

            var candidates = dict.Where(d => d.StructureId != null).Select(s =>
                {
                    var sourceWords = s.StructIdWords;

                    var words = id.Split('_').ToList();
                    words.AddRange(id.Split(' '));
                    words.AddRange(StringHelper.SplitCamelCase(id));
                    words = words.Distinct().ToList();

                    return new
                    {
                        RecommendedId = s.StructureId,
                        Distance = Levenshtein.ComputeDistance(s.StructureId.ToUpper(), id.ToUpper()),
                        BestWordDistance = BestWordDistance.Calculate(sourceWords.ToArray(), words.ToArray())
                    };
                }).ToList();


            var bestMatch = candidates.Min(c => Math.Min(c.BestWordDistance, c.Distance));

            var commentPermutations = GetCommentedPermutations(id);
            var commented = commentPermutations
                .FirstOrDefault(c => TG263Dictionary.GetNameCompliance(c, false).IsNameOk);
            if (commented != null)
            {
                var distance = Levenshtein.ComputeDistance(commented.ToUpper(), id.ToUpper());
                candidates.Add(new
                {
                    RecommendedId = commented,
                    Distance = Levenshtein.ComputeDistance(commented.ToUpper(), id.ToUpper()),
                    BestWordDistance = int.MaxValue
                });
            }

            //SORT
            candidates = candidates.Where(c => !string.IsNullOrEmpty(c.RecommendedId))
                .OrderBy(s => Math.Min(s.BestWordDistance, s.Distance))
                .ThenBy(s => Math.Max(s.BestWordDistance, s.Distance)).ToList();

            return candidates
           .Take(numberOfRecommendations).Select(c => c.RecommendedId).ToList();
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
            return permutations;
        }
    }
}
