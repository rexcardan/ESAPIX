using System;

namespace ESAPIX.Logging
{
    public class Logger : ILogger
    {
        public delegate void LogHandler(string toLog);
        public delegate void LogExceptionHandler(Exception e, string toLog);
        public event LogHandler LogInfoRequested;
        public event LogHandler LogTraceRequested;
        public event LogHandler LogWarnRequested;
        public event LogExceptionHandler LogErrorRequested;

        public void Log(string toLogMessage, params object[] args)
        {
            if (LogInfoRequested != null)
                LogInfoRequested(string.Format(toLogMessage, args));
        }

        public void Info(string message)
        {
            if (LogInfoRequested != null)
                LogInfoRequested(message);
        }

        public void Trace(string message)
        {
            if (LogTraceRequested != null)
                LogTraceRequested(message);
        }

        public void Warn(string message)
        {
            if (LogWarnRequested != null)
                LogWarnRequested(message);
        }

        public void Error(Exception e, string message)
        {
            if (LogErrorRequested != null)
                LogErrorRequested(e, message);
        }

        public void Error(Exception e)
        {
            if (LogErrorRequested != null)
                LogErrorRequested(e, string.Empty);
        }
    }
}