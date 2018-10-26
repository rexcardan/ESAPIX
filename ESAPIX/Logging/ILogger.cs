using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Logging
{
    public interface ILogger
    {
        void Info(string message);
        void Trace(string message);
        void Warn(string message);
        void Error(Exception e, string message);
        void Error(Exception e);
    }
}
