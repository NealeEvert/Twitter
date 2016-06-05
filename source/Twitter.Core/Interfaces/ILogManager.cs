using System;

namespace Twitter.Core.Interfaces
{
    public interface ILogManager
    {
        void LogError(string message);
        void LogError(string message, Exception ex);
        void LogInfo(string message);
        void LogWarning(string message);
    }
}