using Microsoft.Extensions.Logging;

namespace Zidium
{
    internal static class LogLevelHelper
    {
        public static Api.LogLevel GetLogLevel(LogLevel logLevel)
        {
            if (logLevel == LogLevel.Trace)
                return Api.LogLevel.Trace;

            if (logLevel == LogLevel.Debug)
                return Api.LogLevel.Debug;

            if (logLevel == LogLevel.Information || logLevel == LogLevel.None)
                return Api.LogLevel.Info;

            if (logLevel == LogLevel.Warning)
                return Api.LogLevel.Warning;

            if (logLevel == LogLevel.Error)
                return Api.LogLevel.Error;
            
            return Api.LogLevel.Fatal;
        }
    }
}
