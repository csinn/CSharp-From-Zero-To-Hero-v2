using System;

namespace RecipeApp.Core.Services.Logging
{
    class ConsoleLogging : iLogger
    {
        public void Log(string message, LoggingLevels.levels level)
        {
            Console.WriteLine($"{DateTime.Now} :: {level} :: {message}");
        }
    }
}