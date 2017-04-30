using System.Linq;
using System.Text.RegularExpressions;

namespace ESAPIX.Extensions
{
    public static class StringExtensions
    {
        public static string[] SplitOnWhiteSpace(this string s)
        {
            return Regex.Split(s, @"\s+").Where(r => !string.IsNullOrEmpty(r)).ToArray();
        }
    }
}