using System;
using Microsoft.Extensions.Logging;

namespace Zidium
{
    public class NetCoreLoggerErrorsProvider : ILoggerProvider
    {
        public NetCoreLoggerErrorsProvider(Guid? componentId, string expectedCategoryName = null)
        {
            _componentId = componentId;
            _expectedCategoryName = expectedCategoryName;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new NetCoreLoggerErrors(categoryName, _componentId, _expectedCategoryName);
        }

        public void Dispose()
        {
        }

        private Guid? _componentId;

        private string _expectedCategoryName;
    }
}
