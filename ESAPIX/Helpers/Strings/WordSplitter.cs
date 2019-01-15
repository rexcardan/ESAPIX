using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Strings
{
    public class WordSplitter
    {
        public static List<string> Split(string input)
        {
            var words = Regex.Split(input, @"\W|_").ToList();
            words.AddRange(input.Split(' '));
            words.AddRange(StringHelper.SplitCamelCase(input));
            return words.Distinct().Where(w=>w!=input).ToList();
        }
    }
}
