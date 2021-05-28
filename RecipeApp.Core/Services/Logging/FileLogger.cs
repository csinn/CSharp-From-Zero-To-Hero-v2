using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecipeApp.Core.Services.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _logFile;

        public FileLogger(string logFile)
        {
            _logFile = logFile;
        }

        public void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            File.AppendAllText(_logFile, $"[{DateTime.Now:T}] {logLevel}: {message}{Environment.NewLine}");
        }
    }
}
