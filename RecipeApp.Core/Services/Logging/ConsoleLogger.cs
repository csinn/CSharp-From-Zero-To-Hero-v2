using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RecipeApp.Core.Services.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            Debug.WriteLine($"[{DateTime.Now:T}] {logLevel}: {message}");
        }
    }
}
