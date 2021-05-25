using BootCamp.Chapter;
using System;

namespace RecipeApp
{
    public class InvalidRecipeException : Exception
    {
        public InvalidRecipeException(string reason) : base(reason)
        {
            GlobalSettings.currentLogger.LogMessage(LogLevel.Warning, $"Cannot convert recipe because: {reason}");
        }
    }

}
