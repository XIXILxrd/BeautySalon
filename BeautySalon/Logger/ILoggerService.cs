using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Logger
{
    public interface ILoggerService
    {
        void Log(LogLevel level, string message, short traceId = 0, Exception exception = null);

        void Trace(string message);

        void LogInformation(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogCritical(string message);
    }
}