using System;
using Twitter.Core.Interfaces;

namespace Twitter.Core.Implementation
{
    public class LogManager : ILogManager
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void LogError(string message)
        {
            if (Log.IsErrorEnabled)
                Log.Error(message);
        }

        public void LogError(string message, Exception ex)
        {
            if (Log.IsErrorEnabled)
                Log.Error(message, ex);
        }

        public void LogWarning(string message)
        {
            if (Log.IsWarnEnabled)
                Log.Warn(message);
        }

        public void LogInfo(string message)
        {
            if (Log.IsInfoEnabled)
                Log.Info(message);
        }
    }
}
