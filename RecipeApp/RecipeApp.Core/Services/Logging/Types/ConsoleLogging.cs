using System;

namespace RecipeApp.Core.Services.Logging
{
    public class ConsoleLogging : ILogger
    {
        public void Log(string message, LoggingLevels.levels level)
        {
            Console.WriteLine($"{DateTime.Now} :: {level} :: {message}");
        }
    }
}