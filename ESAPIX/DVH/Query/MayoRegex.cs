using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.DVH.Query
{
    public class MayoRegex
    {
        public const string UnitsDesired = @"\[(cc|%|(c?Gy))\]";
        public static string Valid = $"(((V|CV|DC|D)({QueryValue}{QueryUnits}))|(Mean|Max|Min)){UnitsDesired}";
        public const string QueryType = @"^(V|CV|DC|D|Mean|Max|Min)";
        public const string QueryValue = @"\d+";
        public const string QueryUnits = @"((cc)|%|(c?Gy))";
    }
}
