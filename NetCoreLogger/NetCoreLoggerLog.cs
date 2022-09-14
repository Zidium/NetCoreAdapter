using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Zidium.Api;

namespace Zidium
{
    public class NetCoreLoggerLog : ILogger
    {
        public NetCoreLoggerLog(string categoryName, Guid? componentId, string expectedCategoryName = null)
        {
            _categoryName = categoryName;
            _componentId = componentId;
            _isEnabled = expectedCategoryName == null || string.Equals(expectedCategoryName, _categoryName, StringComparison.OrdinalIgnoreCase);
        }

        private string _categoryName;

        private bool _isEnabled;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!_isEnabled)
                return;

            var level = LogLevelHelper.GetLogLevel(logLevel);
            var message = formatter(state, exception);

            Dictionary<string, object> properties = null;
            if (eventId.Id != 0 || !string.IsNullOrEmpty(eventId.Name))
            {
                properties = new Dictionary<string, object>
                {
                    {"EventId", eventId.ToString()}
                };
            }

            var log = Component.Log.GetTaggedCopy(_categoryName);
            log.Write(level, message, exception, properties);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _isEnabled;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        private IComponentControl _component;

        private IComponentControl Component
        {
            get
            {
                if (_component == null)
                {
                    _component = _componentId != null ? Client.Instance.GetComponentControl(_componentId.Value) : Client.Instance.GetDefaultComponentControl();
                }
                return _component;
            }
        }

        private Guid? _componentId;
    }
}
