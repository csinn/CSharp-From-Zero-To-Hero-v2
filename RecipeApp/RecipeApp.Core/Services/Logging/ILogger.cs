namespace RecipeApp.Core.Services.Logging
{
    public interface ILogger
    {
        void Log(string message, LoggingLevels.levels level);
    }
}