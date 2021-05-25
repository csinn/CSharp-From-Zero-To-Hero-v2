using System;

namespace BootCamp.Chapter
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(LogLevel loglevel, string message)
        {
            string preText = $"{DateTime.Now}, {loglevel}:";

            Console.WriteLine($"{preText}{Environment.NewLine}{message}");
        }
    }
}