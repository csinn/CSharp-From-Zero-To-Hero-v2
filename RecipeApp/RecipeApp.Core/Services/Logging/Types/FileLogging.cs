using System;
using System.IO;

namespace RecipeApp.Core.Services.Logging
{
    public class FileLogging : ILogger
    {
        private readonly string LogsFile = Directory.GetCurrentDirectory() + @".\logs.txt";

        public void Log(string message, LoggingLevels.levels level)
        {
            string log = $"{DateTime.Now} :: {level} :: {message}";

            string PreviousLogs = File.ReadAllText(LogsFile);

            File.WriteAllText(LogsFile, $"{PreviousLogs}\n{log}");
        }
    }
}