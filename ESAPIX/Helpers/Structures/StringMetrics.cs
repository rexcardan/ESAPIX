using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Structures
{
    public class StringMetrics
    {
        public string Id { get; set; }
        public double Damerau { get; set; }
        public double Levenshtein { get; set; }
        public double AverageWord { get; set; }
        public double Weighted
        {
            get { return Damerau; }
        }

        public double LongestCommon { get; internal set; }
        public double Dice { get; internal set; }

        public override string ToString()
        {
            return $"{Id}: {Weighted} | {Levenshtein} {AverageWord}";
        }
    }
}
