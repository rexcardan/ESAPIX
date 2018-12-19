using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Strings
{
    public class StringHelper
    {
        public static string[] SplitCamelCase(string input)
        {
            return Regex.Split(input, @"(?=\p{Lu}\p{Ll})|(?<=\p{Ll})(?=\p{Lu})");
        }
    }
}
