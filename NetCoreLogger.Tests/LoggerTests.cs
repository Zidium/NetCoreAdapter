using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.Extensions.Logging;
using Zidium;
using Zidium.Api;

namespace NetCoreLogger.Tests
{
    public class LoggerTests
    {
        [Fact]
        public void LogTraceTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddZidiumLog(ComponentId);
            loggerFactory.AddZidiumErrors(ComponentId);

            var logger = loggerFactory.CreateLogger<LoggerTests>();
            var text = "Message." + Guid.NewGuid();
            logger.LogTrace(text);

            Assert.Single(logMessages);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.Dto.LogLevel.Trace, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal("NetCoreLogger.Tests.LoggerTests", logMessage.Item2.Context);

            Assert.Empty(events);

            Client.Instance.Flush();
        }

        [Fact]
        public void LogDebugTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddZidiumLog(ComponentId);
            loggerFactory.AddZidiumErrors(ComponentId);

            var logger = loggerFactory.CreateLogger<LoggerTests>();
            var text = "Message." + Guid.NewGuid();
            logger.LogDebug(text);

            Assert.Single(logMessages);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.Dto.LogLevel.Debug, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal("NetCoreLogger.Tests.LoggerTests", logMessage.Item2.Context);

            Assert.Empty(events);

            Client.Instance.Flush();
        }

        [Fact]
        public void LogInfoTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddZidiumLog(ComponentId);
            loggerFactory.AddZidiumErrors(ComponentId);

            var logger = loggerFactory.CreateLogger<LoggerTests>();
            var text = "Message." + Guid.NewGuid();
            logger.LogInformation(text);

            Assert.Single(logMessages);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.Dto.LogLevel.Info, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal("NetCoreLogger.Tests.LoggerTests", logMessage.Item2.Context);

            Assert.Empty(events);

            Client.Instance.Flush();
        }

        [Fact]
        public void LogWarningTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddZidiumLog(ComponentId);
            loggerFactory.AddZidiumErrors(ComponentId);

            var logger = loggerFactory.CreateLogger<LoggerTests>();
            var text = "Message." + Guid.NewGuid();
            logger.LogWarning(text);

            Assert.Single(logMessages);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.Dto.LogLevel.Warning, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal("NetCoreLogger.Tests.LoggerTests", logMessage.Item2.Context);

            Assert.Single(events);

            Client.Instance.Flush();
        }

        [Fact]
        public void LogErrorTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddZidiumLog(ComponentId);
            loggerFactory.AddZidiumErrors(ComponentId);

            var logger = loggerFactory.CreateLogger<LoggerTests>();
            var text = "Message." + Guid.NewGuid();
            logger.LogError(text);

            Assert.Single(logMessages);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.Dto.LogLevel.Error, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal("NetCoreLogger.Tests.LoggerTests", logMessage.Item2.Context);

            Assert.Single(events);

            Client.Instance.Flush();
        }

        [Fact]
        public void LogCriticalTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddZidiumLog(ComponentId);
            loggerFactory.AddZidiumErrors(ComponentId);

            var logger = loggerFactory.CreateLogger<LoggerTests>();
            var text = "Message." + Guid.NewGuid();
            logger.LogCritical(text);

            Assert.Single(logMessages);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.Dto.LogLevel.Fatal, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal("NetCoreLogger.Tests.LoggerTests", logMessage.Item2.Context);

            Assert.Single(events);

            Client.Instance.Flush();
        }

        [Fact]
        public void LogExceptionTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddZidiumLog(ComponentId);
            loggerFactory.AddZidiumErrors(ComponentId);

            var logger = loggerFactory.CreateLogger<LoggerTests>();

            Exception exception;
            try
            {
                throw new Exception("Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            logger.LogError(100, exception, exception.Message);

            Assert.Single(logMessages);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.Dto.LogLevel.Error, logMessage.Item2.Level);
            Assert.Equal("Test", logMessage.Item2.Message);
            Assert.Equal("NetCoreLogger.Tests.LoggerTests", logMessage.Item2.Context);

            Assert.Equal(2, logMessage.Item2.Properties.Count);
            var prop = logMessage.Item2.Properties.FirstOrDefault(t => t.Name == "Stack");
            Assert.NotNull(prop);

            prop = logMessage.Item2.Properties.First(t => t.Name == "EventId");
            Assert.NotNull(prop);
            Assert.Equal("100", prop.Value.Value);

            Assert.Single(events);

            Client.Instance.Flush();
        }

        [Fact]
        public void LogDefaultComponentTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddZidiumLog();
            loggerFactory.AddZidiumErrors();

            var logger = loggerFactory.CreateLogger<LoggerTests>();
            var text = "Message." + Guid.NewGuid();
            logger.LogInformation(text);

            Assert.Single(logMessages);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.Dto.LogLevel.Info, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal("NetCoreLogger.Tests.LoggerTests", logMessage.Item2.Context);

            Assert.Empty(events);

            Client.Instance.Flush();
        }

        [Fact]
        public void LogExpectedCategoryTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddZidiumLog(ComponentId, "Application");
            loggerFactory.AddZidiumErrors(ComponentId, "Application");
            loggerFactory.AddZidiumLog(ComponentId, "CustomCategory");
            loggerFactory.AddZidiumErrors(ComponentId, "CustomCategory");

            var logger = loggerFactory.CreateLogger("CustomCategory");
            var text = "Message." + Guid.NewGuid();
            logger.LogCritical(text);

            Assert.Single(logMessages);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.Dto.LogLevel.Fatal, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal("CustomCategory", logMessage.Item2.Context);

            Assert.Single(events);

            Client.Instance.Flush();
        }

        private static Guid ComponentId
        {
            get
            {
                var component = Client.Instance.GetDefaultComponentControl();
                return component.Info?.Id ?? Guid.Empty;
            }
        }
    }
}
