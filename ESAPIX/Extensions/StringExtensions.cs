using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
