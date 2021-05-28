namespace RecipeApp.Core.Services.Logging
{
    public interface ILogger
    {
        void Log(string message, LogLevel logLevel = LogLevel.Info);
    }
}