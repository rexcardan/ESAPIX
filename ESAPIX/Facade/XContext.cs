using ESAPIX.Interfaces;

namespace ESAPIX.Facade
{
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