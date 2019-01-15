using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Strings
{
    public class AverageWordDistance
    {
        public static double Calculate(string[] sourceWords, string[] words)
        {
            if (!words.Any()) { return 0; } // Cannot evaluate
            List<double> wordDistances = new List<double>();
            foreach (var w in words)
            {
                double minDistance = int.MaxValue;
                foreach (var sw in sourceWords)
                {
                    var distance = Levenshtein.ComputeDistance(w.ToUpper(), sw.ToUpper());
                    minDistance = Math.Min(minDistance, distance);
                }
                wordDistances.Add(minDistance);
            }
            return wordDistances.Average();
        }
    }
}
