using System;
using System.IO;

namespace RecipeApp.Core.Services.Logging
{
    internal class FileLogging : ILogger
    {
        private readonly string LogsFile = Directory.GetCurrentDirectory() + @".\logs.txt";

        public void Log(string message, LoggingLevels.levels level)
        {
            string log = $"{DateTime.Now} :: {level} :: {message}";
            Write(log);
        }

        private void Write(string log)
        {
            string logs = Read();

            using (StreamWriter writer = new StreamWriter(LogsFile))
            {
                writer.Write($"{logs}\n{log}");
            }
        }

        private string Read()
        {
            using (StreamReader reader = new StreamReader(LogsFile))
            {
                return reader.ReadToEnd();
            }
        }
    }
}