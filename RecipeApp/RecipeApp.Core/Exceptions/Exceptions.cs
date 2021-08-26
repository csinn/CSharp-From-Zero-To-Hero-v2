using System;
using RecipeApp.Core.Services.Logging;

namespace RecipeApp.Core
{
    public class InvalidRecipeException : Exception
    {
        public InvalidRecipeException(string reason) : base(reason)
        {
            Instance.Logger.Log(reason, LoggingLevels.levels.Warn);
        }
    }

    public class NoNonRecipeFilesException : Exception
    {
        public NoNonRecipeFilesException(string reason) : base(reason)
        {
            Instance.Logger.Log(reason, LoggingLevels.levels.Warn);
        }
    }
}