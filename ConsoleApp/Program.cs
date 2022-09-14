using System;
using Microsoft.Extensions.Logging;
using Zidium;
using Zidium.Api;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddZidiumLog();
            });

            try
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogInformation("My message");
                throw new Exception("Test");
            }
            catch (Exception exception)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(1, exception, "My error");
            }

            Console.ReadKey();
            Client.Instance.Flush();
        }
    }
}
