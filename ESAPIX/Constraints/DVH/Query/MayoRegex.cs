namespace ESAPIX.Constraints.DVH.Query
{
    public class MayoRegex
    {
        public const string UnitsDesired = @"\[(cc|%|(c?Gy))\]";
        public const string QueryType = @"^(V|CV|DC|D|Mean|Max|Min)";
        public const string QueryValue = @"\d+(\.?)(\d+)?";
        public const string QueryUnits = @"((cc)|%|(c?Gy))";
        public static string Valid = $"(((V|CV|DC|D)({QueryValue}{QueryUnits}))|(Mean|Max|Min)){UnitsDesired}";
    }
}