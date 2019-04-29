using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Strings
{
    public class Dice
    {
        private static int k = 3;
        /// <summary>
        /// Pattern for finding multiple following spaces
        /// </summary>
        private static readonly Regex SPACE_REG = new Regex("\\s+");
        /// <summary>
        /// Similarity is computed as 2 * |A inter B| / (|A| + |B|).
        /// </summary>
        /// <param name="s1">The first string to compare.</param>
        /// <param name="s2">The second string to compare.</param>
        /// <returns>The computed Sorensen-Dice similarity.</returns>
        /// <exception cref="ArgumentNullException">If s1 or s2 is null.</exception>
        public static double Similarity(string s1, string s2)
        {
            if (s1 == null)
            {
                throw new ArgumentNullException(nameof(s1));
            }

            if (s2 == null)
            {
                throw new ArgumentNullException(nameof(s2));
            }

            if (s1.Equals(s2))
            {
                return 1;
            }

            var profile1 = GetProfile(s1);
            var profile2 = GetProfile(s2);

            var union = new HashSet<string>();
            union.UnionWith(profile1.Keys);
            union.UnionWith(profile2.Keys);

            int inter = 0;

            foreach (var key in union)
            {
                if (profile1.ContainsKey(key) && profile2.ContainsKey(key))
                    inter++;
            }

            return 2.0 * inter / (profile1.Count + profile2.Count);
        }

        protected static IDictionary<string, int> GetProfile(string s)
        {
            var shingles = new Dictionary<string, int>();

            var string_no_space = SPACE_REG.Replace(s, " ");

            for (int i = 0; i < (string_no_space.Length - k + 1); i++)
            {
                var shingle = string_no_space.Substring(i, k);

                if (shingles.TryGetValue(shingle, out var old))
                {
                    shingles[shingle] = old + 1;
                }
                else
                {
                    shingles[shingle] = 1;
                }
            }

            return new ReadOnlyDictionary<string, int>(shingles);
        }

        /// <summary>
        /// Returns 1 - similarity.
        /// </summary>
        /// <param name="s1">The first string to compare.</param>
        /// <param name="s2">The second string to compare.</param>
        /// <returns>1.0 - the computed similarity</returns>
        /// <exception cref="ArgumentNullException">If s1 or s2 is null.</exception>
        public static double ComputeDistance(string s1, string s2)
            => 1 - Similarity(s1, s2);
    }
}

