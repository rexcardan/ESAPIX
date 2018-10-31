namespace ESAPIX.Facade
{
    public class DefaultHelper
    {
        public static bool IsDefault(dynamic input)
        {
            if (object.ReferenceEquals(null, input))
                return true;
            return false;
        }
    }
}