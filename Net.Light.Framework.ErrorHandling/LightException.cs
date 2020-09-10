using System;
using System.Runtime.Serialization;

namespace Net.Light.Framework.ErrorHandling
{
    public class LightException : Exception
    {
        private LightLogger _logEntry;

        public LightException(Exception exc, LightLogger log)
        {
            _logEntry = log;
            if (exc != null)
            {
                _logEntry.StackTrace = exc.StackTrace;
                _logEntry.Message = exc.Message;
            }
            _logEntry.Write();
        }


        public LightException()
        {
        }

        public LightException(string message)
            : base(message)
        {
        }

        public LightException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected LightException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }

    }
}