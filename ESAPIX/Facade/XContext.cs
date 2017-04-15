using ESAPIX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Facade
{
    public class XContext
    {
        private static object syncRoot = new Object();
        private static volatile XContext instance;

        private XContext() { }

        public static XContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new XContext();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Holds the thread for facade conversions
        /// </summary>
        public IScriptContext CurrentContext { get; set; }
    }
}
