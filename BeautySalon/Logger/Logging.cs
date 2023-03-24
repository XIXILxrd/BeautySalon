using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Logger
{
    public enum LogLevel
    {
        Trace = 0,
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Critical = 5
    }

    public delegate void fileService(string message);

    public class Logging<T> : ILoggerService
    {
        private readonly string currentTime = DateTime.Now.ToLongTimeString();

        private readonly string nameSpace;

        public event fileService? Display;

        public Logging() => this.nameSpace = typeof(T).FullName;

        private string CastMessage(string message, LogLevel level, short traceId, Exception exception)
        {
            return exception != null
                ? $"{currentTime}|{traceId}|{nameSpace}|{level.ToString()}|{message}{exception}"
                : $"{currentTime}|{traceId}|{nameSpace}|{level.ToString()}|{message}";
        }

        public void Log(LogLevel level, string message, short traceId = 0, Exception exception = null)
        {
            var response = CastMessage(message, level, traceId, exception);

            switch (level)
            {
                case LogLevel.Information:
                    LogInformation(response);

                    break;
                case LogLevel.Warning:
                    LogWarning(response);

                    break;
                case LogLevel.Error:
                    LogError(response);

                    break;
                case LogLevel.Critical:
                    LogCritical(response);

                    break;
            }
        }

        public void Trace(string message)
        {
            Display?.Invoke(message);
        }

        public void LogInformation(string message)
        {
            Display?.Invoke(message);
        }

        public void LogWarning(string message)
        {
            Display?.Invoke(message);
        }

        public void LogError(string message)
        {
            Display?.Invoke(message);
        }

        public void LogCritical(string message)
        {
            Display?.Invoke(message);
        }
    }
}
