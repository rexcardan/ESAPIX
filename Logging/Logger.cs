using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Logging
{
    public class Logger
    {
        public delegate void LogHandler(string toLog);

        public event LogHandler LogRequested;

        public void Log(string toLogMessage, params object[] args)
        {
            if (LogRequested != null)
            {
                LogRequested(string.Format(toLogMessage, args));
            }
        }
    }
}
