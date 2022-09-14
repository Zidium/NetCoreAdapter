using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Zidium.Api;

namespace Zidium
{
    public class NetCoreLoggerErrors : ILogger
    {
        public NetCoreLoggerErrors(string categoryName, Guid? componentId, string expectedCategoryName = null)
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
            if (level <= Api.Dto.LogLevel.Info)
                return;

            var message = formatter(state, exception);

            Dictionary<string, object> properties;
            if (eventId.Id != 0 || !string.IsNullOrEmpty(eventId.Name))
            {
                properties = new Dictionary<string, object>
                {
                    {"EventId", eventId.ToString()}
                };
            }
            else
            {
                properties = new Dictionary<string, object>();
            }

            var data = Component.Client.ExceptionRender.CreateEventFromLog(Component, level, exception, message, properties);
            data.Add();
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
