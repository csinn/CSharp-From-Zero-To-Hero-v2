using System;
using System.Collections.Generic;
using System.IO;

namespace BootCamp.Chapter
{
    public class FileLogger : ILogger
    {
        public void LogMessage(LogLevel loglevel, string message)
        {
            string fullFileName = GlobalSettings.filePath + @"\log.txt";

            string preText = $"{DateTime.Now}, {loglevel}:";

            List<string> logEntry = new List<string>
            {
                preText,
                message
            };

            try
            {
                File.AppendAllLines(fullFileName, logEntry);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}