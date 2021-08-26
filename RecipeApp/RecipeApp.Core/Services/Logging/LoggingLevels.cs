namespace RecipeApp.Core.Services.Logging
{
    public class LoggingLevels
    {
        public enum levels
        {
            Info, // Based on logs it should be clear what happened throughout the program
            Warn, // Every exception thrown should also be logged as warning
            Error // Unhandled exception should be logged as error
        }
    }
}