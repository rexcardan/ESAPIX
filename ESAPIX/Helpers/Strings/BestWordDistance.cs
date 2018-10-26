using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Strings
{
    public class BestWordDistance
    {
        public static int Calculate(string[] sourceWords, string[] words)
        {
            List<int> wordDistances = new List<int>();
            foreach (var w in words)
            {
                int minDistance = int.MaxValue;
                foreach (var sw in sourceWords)
                {
                    var distance = Levenshtein.ComputeDistance(w.ToUpper(), sw.ToUpper());
                    minDistance = Math.Min(minDistance, distance);
                }
                wordDistances.Add(minDistance);
            }
            return (int)Math.Round(wordDistances.Average());
        }
    }
}
