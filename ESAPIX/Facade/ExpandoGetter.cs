namespace ESAPIX.Facade
{
    /// <summary>
    /// This class helps pull the ExpandoObject client if needed from a facade
    /// </summary>
    public class ExpandoGetter
    {
        public static dynamic GetClient(object o)
        {
            var fieldInfo = o.GetType()
                .GetField("_client",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return fieldInfo?.GetValue(o);
        }
    }
}