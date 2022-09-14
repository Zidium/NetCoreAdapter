using Microsoft.Extensions.Logging;

namespace Zidium
{
    internal static class LogLevelHelper
    {
        public static Api.Dto.LogLevel GetLogLevel(LogLevel logLevel)
        {
            if (logLevel == LogLevel.Trace)
                return Api.Dto.LogLevel.Trace;

            if (logLevel == LogLevel.Debug)
                return Api.Dto.LogLevel.Debug;

            if (logLevel == LogLevel.Information || logLevel == LogLevel.None)
                return Api.Dto.LogLevel.Info;

            if (logLevel == LogLevel.Warning)
                return Api.Dto.LogLevel.Warning;

            if (logLevel == LogLevel.Error)
                return Api.Dto.LogLevel.Error;

            return Api.Dto.LogLevel.Fatal;
        }
    }
}
