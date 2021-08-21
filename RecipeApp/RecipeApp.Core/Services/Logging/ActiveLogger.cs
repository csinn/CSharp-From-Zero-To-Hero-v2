
namespace RecipeApp.Core.Services.Logging
{
    public class ActiveLogger
    {
        public static iLogger iLogger = new ConsoleLogging(); // enable for Console Logging
        // public static iLogger iLogger = new FileLogging(); // enable for File Logging
    }
}
