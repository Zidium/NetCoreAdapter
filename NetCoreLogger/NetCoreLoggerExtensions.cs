using System;
using Microsoft.Extensions.Logging;

namespace Zidium
{
    public static class NetCoreLoggerExtensions
    {
        public static ILoggerFactory AddZidiumLog(this ILoggerFactory loggerFactory, Guid? componentId = null, string expectedCategoryName = null)
        {
            loggerFactory.AddProvider(new NetCoreLoggerLogProvider(componentId, expectedCategoryName));
            return loggerFactory;
        }

        public static ILoggerFactory AddZidiumErrors(this ILoggerFactory loggerFactory, Guid? componentId = null, string expectedCategoryName = null)
        {
            loggerFactory.AddProvider(new NetCoreLoggerErrorsProvider(componentId, expectedCategoryName));
            return loggerFactory;
        }

        public static ILoggingBuilder AddZidiumLog(this ILoggingBuilder builder, Guid? componentId = null, string expectedCategoryName = null)
        {
            builder.AddProvider(new NetCoreLoggerLogProvider(componentId, expectedCategoryName));
            return builder;
        }

        public static ILoggingBuilder AddZidiumErrors(this ILoggingBuilder builder, Guid? componentId = null, string expectedCategoryName = null)
        {
            builder.AddProvider(new NetCoreLoggerErrorsProvider(componentId, expectedCategoryName));
            return builder;
        }
    }
}
