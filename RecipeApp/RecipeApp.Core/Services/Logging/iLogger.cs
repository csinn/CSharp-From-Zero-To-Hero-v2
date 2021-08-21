
namespace RecipeApp.Core.Services.Logging
{
    public interface iLogger
    {
        public void Log(string message, LoggingLevels.levels level);
    }
}