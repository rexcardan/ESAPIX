using System;

namespace ESAPIX.AppKit.Exceptions
{
    public class ScriptException : Exception
    {
        static string msg = $"ESAPIX thread tried and failed to invoke a method. See inner exception for details";

        public ScriptException(Exception baseException) : base(msg, baseException) { }

        public override string Message
        {
            get
            {
                return msg + $"=> {InnerException.Message} @ " + InnerException.ToString();
            }
        }
    }
}
