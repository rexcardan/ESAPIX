using System;

namespace ESAPIX.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception GetRootException(this Exception e)
        {
            var root = e;
            while (root.InnerException != null) { root = root.InnerException; }
            return root;
        }
    }
}
