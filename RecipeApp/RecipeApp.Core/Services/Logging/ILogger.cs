namespace RecipeApp.Core.Services.Logging
{
    public interface ILogger
    {
        public abstract void Log(string message, LoggingLevels.levels level);
    }
}