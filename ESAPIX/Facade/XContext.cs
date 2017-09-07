#region

using ESAPIX.Interfaces;

#endregion

namespace ESAPIX.Facade
{
    /// <summary>
    /// A singleton class which allows a contact point to find the current context (script or standalone) from within
    /// any class or method. Call XContext.Instance.CurrentContext for current context.
    /// </summary>
    public class XContext
    {
        private static readonly object syncRoot = new object();
        private static volatile XContext instance;

        private XContext()
        {
        }

        public static XContext Instance
        {
            get
            {
                if (instance == null)
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new XContext();
                    }

                return instance;
            }
        }

        /// <summary>
        ///     Holds the thread for facade conversions
        /// </summary>
        public IScriptContext CurrentContext { get; set; }
    }
}